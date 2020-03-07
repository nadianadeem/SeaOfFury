using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The attacker class is used by all enemy ships.
//The attacker class inherits the ship class.
//The take health method is overriden so the damage is doubled.
public class attackerClass : shipClass
{
    //A damage property is created and is set to read only.
    //This is for encapsulation purposes, to decreases chances of manipulation.
    private int Damage = 25;
    public int damage{
        get{
            return Damage;
        }
    }

    //The take health method is overriden so the damage that is dealt is
    //doubled.
    public override int takeHealth(int health, int damage){
        return health -= (damage * 2);
    }
}
