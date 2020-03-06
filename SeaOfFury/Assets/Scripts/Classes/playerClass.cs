using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerClass : shipClass
{
    private int Damage = 50;
    public int damage{
        get{
            return Damage;
        }
        set{
            Damage = value;
        }
    }
}
