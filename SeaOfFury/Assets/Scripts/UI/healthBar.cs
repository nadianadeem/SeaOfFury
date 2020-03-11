using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    //Stores the slider of the health bar.
    public Slider slider;

    //Thisthod set max health changes the max value of the slider to the parameter.
    //the value of the slider is also set to the parameter so the slider is full.
    public void SetMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
    }

    //This method changes the value of the slider to the value given in the parameter.
    public void SetHealth(int health){
        slider.value = health;
    }
}
