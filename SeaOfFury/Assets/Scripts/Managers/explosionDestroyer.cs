using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDestroyer : MonoBehaviour
{
    //Once the explosion is instantiated it is then destoryed a second after
    //so there is not explosions evrywhere.
    void Start()
    {
        Destroy(gameObject, 1.0f);
    }
}
