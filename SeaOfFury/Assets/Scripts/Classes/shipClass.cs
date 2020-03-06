using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipClass
{
    private int Health = 100;

    public int health{
        get{
            return Health;
        }
        set{
            Health = value;
        }
    }

    public virtual int takeHealth(int health, int damage){
        return health -= damage;
    }
}
