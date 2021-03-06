﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextRandomizer : MonoBehaviour {
    private Text gameText;
    public Text gameDescription;
    private float time = 0;
    private float delay = .15f;
    private float counter;
    public static List<string> gameNames;
    public static bool originalGamesAdded = false;
    private bool textSet = false;
    private int lastNumber = 0;
    private bool endOfGame = false;
    public Text scoreP1;
    public Text scoreP2;
    // Use this for initialization
    void Start () {
        gameText = this.gameObject.GetComponent<Text>();
         if (originalGamesAdded == false)
        {
            gameNames = new List<string>();
            gameNames.Add("Bang Game");
            gameNames.Add("Balloon Game");
            gameNames.Add("Vertical Platformer");
            gameNames.Add("Parachute Drop");
            originalGamesAdded = true;
        }
        scoreP1.text = "P1 Score: " + GameDataManager.Instance.playerOneTotalScore;
        scoreP2.text = "P2 Score: " + GameDataManager.Instance.playerTwoTotalScore;

        if (gameNames.Count == 0)
        {
            if (SceneManager.GetActiveScene().name == "Transition")
            {
                if (GameDataManager.Instance.playerOneTotalScore > GameDataManager.Instance.playerTwoTotalScore)
                {
                    gameDescription.text = "Player 1 Wins. Thanks For Playing";
                }

                else if (GameDataManager.Instance.playerOneTotalScore < GameDataManager.Instance.playerTwoTotalScore)
                {
                    gameDescription.text = "Player 2 Wins. Thanks For Playing";
                }

                else
                {
                    gameDescription.text = "Tie Game. Thanks For Playing";
                }
                StartCoroutine("ChangeLevel");  
                endOfGame = true;
            }

            else
            {
                endOfGame = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Transition")
        {
            time += Time.deltaTime;


            if (endOfGame == false)
            {
                if (time < 6)
                {
                    counter += Time.deltaTime;
                    if (counter > delay && gameNames.Count != 1)
                    {
                        int random = Random.Range(0, gameNames.Count);

                        while (random == lastNumber)
                        {
                            random = Random.Range(0, gameNames.Count);
                        }

                        lastNumber = random;
                        gameText.text = gameNames[random];
                        counter = 0;
                    }

                    else if (gameNames.Count == 1)
                    {
                        gameText.text = gameNames[0];
                    }

                }

                if (time >= 6 && textSet == false)
                {
                    if (gameText.text == "Bang Game")
                    {
                        gameNames.Remove("Bang Game");
                        gameDescription.text = "Game Objective: Be the quickest player to shoot when the timer says BANG. Be careful not to shoot before BANG as" +
                           " doing so will cause you to miss with your only bullet." + "\n\nControls: Press A to shoot.";
                    }

                    else if (gameText.text == "Vertical Platformer")
                    {
                        gameNames.Remove("Vertical Platformer");
                        gameDescription.text = "Game Objective: Be the first player to climb to the top and reach a flag. Getting hit by a sawblade will cause you to" +
                           " start from the beginning." + "\n\nControls: Press A to jump. Use the joystick to move.";
                    }

                    else if (gameText.text == "Parachute Drop")
                    {
                        gameNames.Remove("Parachute Drop");
                        gameDescription.text = "Game Objective: Open your parachute as close to the ground as possible without crashing into the ground." +
                             "\n\nControls: Press A to open your parachute. Press Start to start the game";
                    }

                    else if (gameText.text == "Balloon Game")
                    {
                        gameNames.Remove("Balloon Game");
                        gameDescription.text = "Game Objective: Shoot balloons the same colour as you to gain points, hitting any other balloons will cause you to lose points." +
                           "\n\nControls: Press A to shoot";
                    }

                    textSet = true;
                }

                if (time > 10)
                {
                    if (gameText.text == "Bang Game")
                    {
                        SceneManager.LoadScene("Bang Game");
                    }

                    else if (gameText.text == "Vertical Platformer")
                    {
                        SceneManager.LoadScene("Vertical Platformer");
                    }

                    else if (gameText.text == "Parachute Drop")
                    {
                        SceneManager.LoadScene("Parachute Drop");
                    }

                    else if (gameText.text == "Balloon Game")
                    {
                        SceneManager.LoadScene("BalloonGame");
                    }
                }
            }
        }
    }

    public IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StatsScene");
    }
}


