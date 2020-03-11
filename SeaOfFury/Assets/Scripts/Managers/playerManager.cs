using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    //Singleton is created to hold an instance of the player object at all times.
    //This is used when the enemy AI are looking for the ships and 
    //checking whether it's in the radius of the enemy ships.
    #region Singleton

    public static playerManager instance;
    
    void Awake(){
        instance = this;
    }

    #endregion

    public GameObject player;

}
