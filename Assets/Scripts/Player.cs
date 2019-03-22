using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All (Ben) expect restart 
public class Player : MonoBehaviour
{
    public int id;
    public int num_wins;
    public Weapon weapon;
    public bool ready;

    //Constructor

    public Player(int new_id)
    {
        id = new_id;
    }

    //id getter and setter

    public int get_id()
    {
        return id;
    }

    public void set_id(int num)
    {
        id = num;
    }

    //ready getter and setter

    public bool get_ready_status()
    {
        return ready;
    }

    public void set_ready_status(bool new_ready)
    {
        ready = new_ready;
    }


    //Weapon getter and setter

    public void set_weapon(Weapon new_weapon)
    {
        weapon = new_weapon;
    }

    public Weapon get_weapon()
    {
        return weapon;
    }




    //Wins getters, setters, adjusters

    public void add_win()
    {
        num_wins++;
    }

    public void add_amount_wins(int amount)
    {
        num_wins += amount;
    }

    public void set_wins(int new_wins)
    {
        num_wins = new_wins;
    }

    public int get_wins()
    {
        return num_wins;
    }


    //Compares weapon values of this player and another
    //Returns the id of the winning player or a negative number for ready/ restart
    //-1 in a tie
    public int get_winning_player(Player other)
    {
        Weapon.WeaponType my_weapon = get_weapon().get_type();
        Weapon.WeaponType opponent_weapon = other.get_weapon().get_type();

        if (my_weapon.Equals(Weapon.WeaponType.Rock) && opponent_weapon.Equals(Weapon.WeaponType.Scissors) 
            || my_weapon.Equals(Weapon.WeaponType.Paper) && opponent_weapon.Equals(Weapon.WeaponType.Rock) 
            || my_weapon.Equals(Weapon.WeaponType.Scissors) && opponent_weapon.Equals(Weapon.WeaponType.Paper)) {
            return id;

        } else if (opponent_weapon.Equals(Weapon.WeaponType.Rock) && my_weapon.Equals(Weapon.WeaponType.Scissors)
            || opponent_weapon.Equals(Weapon.WeaponType.Paper) && my_weapon.Equals(Weapon.WeaponType.Rock)
            || opponent_weapon.Equals(Weapon.WeaponType.Scissors) && my_weapon.Equals(Weapon.WeaponType.Paper)) {
            return other.get_id();
   
        } else if (my_weapon == Weapon.WeaponType.Ready || opponent_weapon == Weapon.WeaponType.Ready)
        {
            return -2;

        } else if (my_weapon == Weapon.WeaponType.Restart || opponent_weapon == Weapon.WeaponType.Restart)
        {
            return -3;

        } else
        {
            return -1;
        }
    }

    
    //Gets the loser based on the winner
    //Returns -1 in a tie
    public int get_losing_player(Player other)
    {
        if (get_winning_player(other) == get_id())
        {
            return other.get_id();
        } else if (get_winning_player(other) == other.get_id())
        {
            return get_id();
        } else
        {
            return -1;
        }
    }
}
