using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BangGameManager : NetworkBehaviour
{
    [SyncVar(hook = "OnPlayerOneTimeChanged")]
    public float playerOneTime;

    [SyncVar(hook = "OnPlayerTwoTimeChanged")]
    public float playerTwoTime;

    [SyncVar(hook = "OnTimerChanged")] public float timeLeft;
    public float maximumTimeAmount = 10;
    public Text timerText;
    public Text winText;
    public Text playerOneTimeText;
    public Text playerTwoTimeText;

    [SyncVar]
    public bool gameOver = false;

    public bool isCountdownOver = false;

    private bool isPlayerOneDead = false;
    private bool isPlayerTwoDead = false;

    public override void OnStartServer()
    {
        base.OnStartServer();

        timeLeft = Random.Range(3f, maximumTimeAmount);
        timerText.text = timeLeft.ToString("0");
        gameOver = false;
        isCountdownOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Make sure the timer is only updated in the server.
        if (isServer)
        {
            if (gameOver == false)
            {
                timeLeft -= Time.deltaTime;
            }
        }
    }

    void Reset()
    {
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        winText = GameObject.Find("WinText").GetComponent<Text>();
        playerOneTimeText = GameObject.Find("PlayerOneTimeText").GetComponent<Text>();
        playerTwoTimeText = GameObject.Find("PlayerTwoTimeText").GetComponent<Text>();
    }

    public IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(3);
    }

    void OnTimerChanged(float timeLeft)
    {
        if (timeLeft > 3)
        {
            timerText.text = "  " + timeLeft.ToString("0");
        }
        else if (timeLeft <= 3 && timeLeft > 0)
        {
            timerText.text = "";
        }
        else if (timeLeft <= 0)
        {
            isCountdownOver = true;
            timerText.text = "BANG";
        }
        else if (timeLeft <= 0)
        {
            timerText.text = "TOO LATE";
            //TODO: Switch scene here. Make it a tie.
        }
    }

    [Server]
    public void PlayerOneShot()
    {
        playerOneTime = Mathf.Abs(timeLeft);
    }

    [Server]
    public void PlayerTwoShot()
    {
        playerTwoTime = Mathf.Abs(timeLeft);
    }

    [Server]
    public void PlayerOneMiss()
    {
        playerOneTime = -1;
        if (!gameOver)
        {
            CheckForWinner();
        }
    }

    [Server]
    public void PlayerTwoMiss()
    {
        playerTwoTime = -1;
        if (!gameOver)
        {
            CheckForWinner();
        }
    }

    [Server]
    public void KillPlayerOne()
    {
        isPlayerOneDead = true;
        if (!gameOver)
        {
            CheckForWinner();
        }
    }

    [Server]
    public void KillPlayerTwo()
    {
        isPlayerTwoDead = true;
        if (!gameOver)
        {
            CheckForWinner();
        }
    }

    [Server]
    private void CheckForWinner()
    {
        bool isPlayerOneWinner = false;
        bool isTie = false;

        if (playerOneTime < 0 && playerTwoTime < 0) //Tie Game. Both players missed.
        {
            isTie = true;
            gameOver = true;
        }
        else
        {
            PlayerManager playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            if (isPlayerOneDead && !isPlayerTwoDead) //Player Two Wins the game.
            {
                isPlayerOneWinner = false;
                playerManager.IncreasePlayerTwoScore();
                gameOver = true;
            }
            else if (!isPlayerOneDead && isPlayerTwoDead) //Player One Wins the game.
            {
                isPlayerOneWinner = true;
                playerManager.IncreasePlayerOneScore();
                gameOver = true;
            }
            else if (isPlayerOneDead && isPlayerTwoDead) 
            {
                if (playerOneTime > playerTwoTime) //Player Two Wins the game.
                {
                    isPlayerOneWinner = false;
                    playerManager.IncreasePlayerTwoScore();
                }
                else if (playerTwoTime > playerOneTime) //Player One Wins the game.
                {
                    isPlayerOneWinner = true;
                    playerManager.IncreasePlayerOneScore();
                }
                else if (Math.Abs(playerOneTime - playerTwoTime) < 0.001f) //Tie game.
                {
                    isTie = true;
                }
                gameOver = true;
            }
        }

        if (gameOver)
        {
            RpcDeclareWinner(isTie, isPlayerOneWinner);
            StartCoroutine(EndLevel());
        }
    }

    [ClientRpc]
    private void RpcDeclareWinner(bool isTie, bool isPlayerOneWinner)
    {
        if (isTie)
        {
            winText.text = "Tie";
        }
        else
        {
            if (isPlayerOneWinner)
            {
                winText.text = "PlayerOneWinner";
            }
            else
            {
                winText.text = "PlayerTwoWinner";
            }
        }
    }

    void OnPlayerOneTimeChanged(float playerOneTime)
    {
        if (playerOneTime >= 0)
        {
            playerOneTimeText.text = playerOneTime.ToString("0.000") + "s";
        }
        else
        {
            playerOneTimeText.text = "Miss";
        }
    }

    void OnPlayerTwoTimeChanged(float playerTwoTime)
    {
        if (playerTwoTime >= 0)
        {
            playerTwoTimeText.text = playerTwoTime.ToString("0.000") + "s";
        }
        else
        {
            playerTwoTimeText.text = "Miss";
        }
    }

    [Server]
    public IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(3);
        MiniNetworkManager.singleton.ServerChangeScene("TransitionMultiplayer");
    }
}
