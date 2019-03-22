using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//(name) indicate who was responciple for that block of code since didn't set up GitHub until after project was complete

public class GameManager : MonoBehaviour
{
    //options passed to player from the weapon class (Ben)
    Weapon defaultRock = new Weapon(Weapon.WeaponType.Rock);
    Weapon defaultPaper = new Weapon(Weapon.WeaponType.Paper);
    Weapon defaultScissors = new Weapon(Weapon.WeaponType.Scissors);
    Weapon ready = new Weapon(Weapon.WeaponType.Ready);
    Weapon restart = new Weapon(Weapon.WeaponType.Restart);

    //object tied to script so there is some base reference/ thing to point to (Sam)
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Ready;
    public GameObject Count;
    public GameObject Results;

    // indivdial player objects that help tie actions and score to two person/ one if you're sad and alone :(  (Ben)
    Player player_one;
    Player player_two;

    // A secondary bool to make sure both players confirm (Ben/ Sam)
    public static bool judged = false;
    public static bool players_are_ready = false;
    public static bool players_are_restart = false;

    //Changable text to be desplayed on the results screen (Sam) 
    public Text winnerText;
    public Text player1_score;
    public Text player2_score;

    // Start is called before the first frame update and sets up scene /players (Ben/ Sam)
    void Start()
    {
        player_one = Player1.AddComponent<Player>();
        player_two = Player2.AddComponent<Player>();

        player_one.set_id(1);
        player_two.set_id(2);

        player_one.set_wins(0);
        player_two.set_wins(0);

        player1_score.text = player_one.get_wins() + "";
        player2_score.text = player_two.get_wins() + "";

        Player1.SetActive(true);
        Player2.SetActive(true);

        Ready.SetActive(true);
        Count.SetActive(false);
        Results.SetActive(false);
    }

    // Update is called once per frame and key presses indicating both players are ready (Ben/ Sam)
    void Update()
    {
        if (!players_are_ready)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("W key was pressed.");
                player_one.set_weapon(ready);
                if (player_one.get_ready_status() == false)
                {
                    player_one.set_ready_status(true);
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Up key was pressed.");
                player_two.set_weapon(ready);
                if (player_two.get_ready_status() == false)
                {
                    player_two.set_ready_status(true);
                }
            }
        }

        //Setting winner text when timer counts down (Ben)

        if (player_one.get_ready_status() == true && player_two.get_ready_status() == true && !players_are_ready)
        {
            players_are_ready = true;
            CountDown.timeLeft = CountDown.initialTime;
        }

        if (players_are_ready == true)
        {
            Ready.SetActive(false);
            Count.SetActive(true);


            //Player 1 inputs (Ben/ Sam)

            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("A key was pressed.");
                player_one.set_weapon(defaultRock);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("S key was pressed.");
                player_one.set_weapon(defaultPaper);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("D key was pressed.");
                player_one.set_weapon(defaultScissors);
                
            }

            //Player 2 inputs (Ben/ Sam)

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Down key was pressed.");
                player_two.set_weapon(defaultPaper);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Right key was pressed.");
                player_two.set_weapon(defaultScissors);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Left key was pressed.");
                player_two.set_weapon(defaultRock);
            }
   
        }
    }
    // Setting text if the winner id match a player id (Ben)
    void LateUpdate() {
        if (players_are_ready)
        {
            if (CountDown.timeLeft == 0)
            {
                if (player_one.get_weapon() != ready && player_two.get_weapon() != ready)
                {
                    Count.SetActive(false);
                    Results.SetActive(true);
                    judged = true;

                    if (player_one.get_winning_player(player_two) != -1)
                    {
                        Debug.Log(player_one.get_winning_player(player_two));
                        if (player_one.get_winning_player(player_two) == player_one.get_id())
                        {
                            player_one.add_amount_wins(1);
                            player1_score.text = player_one.get_wins() + "";
                            winnerText.text = "Player 1";
                        }
                        else if (player_two.get_winning_player(player_one) == player_two.get_id())
                        {
                            player_two.add_amount_wins(1);
                            player2_score.text = player_two.get_wins() + "";
                            winnerText.text = "Player 2";
                        }
                    }
                    else
                    {
                        winnerText.text = "Everyone's a Winner!";
                    }

                    player_one.set_ready_status(false);
                    player_two.set_ready_status(false);
                    players_are_ready = false;
                }
            }
        }

        //restart indicated by botton presses and setting initial conditions (Sam/ Ben)
        if (CountDown.timeLeft == 0 && judged)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("R key was pressed.");
                player_one.set_weapon(restart);
            }

            if (Input.GetKeyDown(KeyCode.Semicolon))
            {
                Debug.Log("Semicolon key was pressed.");
                player_two.set_weapon(restart);
            }
        }

        if (player_one.get_weapon() == restart && player_two.get_weapon() == restart)
        {
            Ready.SetActive(true);
            Count.SetActive(false);
            Results.SetActive(false);

            judged = false;
            players_are_restart = false;
          
        }
    }
}
