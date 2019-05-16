using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Exit {

    //para aonde estamos olhando.
    public string keyString;
    //vai dizer aonde tem saidas.
    public string exitDescription;
    //Sala para qual a sala irá.
    public Room valueRoom;
}
