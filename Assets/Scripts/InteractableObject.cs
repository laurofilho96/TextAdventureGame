using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="TextAdventure/Objects")]
public class InteractableObject : ScriptableObject {

    public string noun = "name";

    [TextArea]
    public string description = "description in room";
	
}
