using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

// (Sam) ripped off the code from a site called noob-programmer but (Ben) added OnEnable to make reset work properly.
public class CountDown : MonoBehaviour
{
    public static int initialTime = 5;
    public static int timeLeft = initialTime; //Seconds Overall
    public Text countdown; //UI Text Object
    void OnEnable()
    {
        StartCoroutine("LoseTime");
    }
    void Start()
    {
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }
    void Update()
    {
        countdown.text = "" + timeLeft; //Showing the Score on the Canvas
    }
    //Simple Coroutine to count down
    IEnumerator LoseTime()
    {
        if (GameManager.players_are_ready == true)
        {
            while (timeLeft > 0)
            {
                yield return new WaitForSeconds(1);
                timeLeft--;
            }
        }
    }
}
