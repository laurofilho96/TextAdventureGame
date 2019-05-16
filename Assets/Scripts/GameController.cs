using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInTheRoom = new List<string>();
    [HideInInspector] public InteractableItems interactableItems;

    List<string> actionLog = new List<string>();

    public Text displayText;

    public InputAction[] inputActions;
	
	void Awake () {

        interactableItems = GetComponent<InteractableItems>();
        roomNavigation = GetComponent<RoomNavigation>();
	}

        void Start()
    {
        DisplayRoomText();
        DisplayLogText();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void DisplayRoomText()
    {

        ClearCollectionsForNewRoom();

        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInTheRoom.ToArray());

        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;

        LogStringWithReturn(combinedText);
    }

    public void LogStringWithReturn(string StringToAdd)
    {
        actionLog.Add(StringToAdd + "\n");
    }

    public void DisplayLogText()
    {

        string logAsText = string.Join("\n", actionLog.ToArray());

        displayText.text = logAsText;
    }

     void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
        PrepareObjectsToTakeOrExamine(roomNavigation.currentRoom);

    }

    void PrepareObjectsToTakeOrExamine(Room currentRoom)
    {
        for (int i = 0; i < currentRoom.objectsInRoom.Length; i++)
        {
            string descriptionNotInInventory = interactableItems.GetObjectsNotInInventory(currentRoom, i);
            if(descriptionNotInInventory != null)
            {
                interactionDescriptionsInTheRoom.Add(descriptionNotInInventory);
            }
        }
    }

    void ClearCollectionsForNewRoom()
    {

        interactionDescriptionsInTheRoom.Clear();
        roomNavigation.ClearExits();
    }
}
