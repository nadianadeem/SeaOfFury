using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipClass
{
    //A read-write property is created for the variable health.
    //This allows various scripts to take away damage from enemy and player ships.
    private int Health = 100;

    public int health{
        get{
            return Health;
        }
        set{
            Health = value;
        }
    }

    //This method takes away damage from the health of an enemy or
    //player ship and returns the value.
    public virtual int takeHealth(int health, int damage){
        return health -= damage;
    }
}
