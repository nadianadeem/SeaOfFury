using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerClass : shipClass
{
    //A damage property is created and is set to read only.
    //This is for encapsulation purposes, to decreases chances of manipulation.
    private int Damage = 50;
    public int damage{
        get{
            return Damage;
        }
    }
}
