using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackerClass : shipClass
{
    private int Damage = 25;
    public int damage{
        get{
            return Damage;
        }
        set{
            Damage = value;
        }
    }

     public int takeScore(int score, int damage){
        return score -= damage;
    }

    public override int takeHealth(int health, int damage){
        return health -= (damage * 2);
    }
}
