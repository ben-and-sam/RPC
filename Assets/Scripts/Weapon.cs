using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All (Ben) expect restart 
[Serializable]
public class Weapon
{   
    //the options avalible to the player
    public enum WeaponType {Rock, Paper, Scissors, Ready, Restart};
    WeaponType type;

    //Weapon constructor
    public Weapon(WeaponType new_type)
    {
        type = new_type;
    }

    //Type getter
    public WeaponType get_type()
    {
        return type;
    }
}
