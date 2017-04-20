using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour
{
    [SyncVar]
    public int playerOneScore = 0;

    [SyncVar]
    public int playerTwoScore = 0;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    [Server]
    public void IncreasePlayerOneScore()
    {
        playerOneScore++;
    }

    [Server]
    public void IncreasePlayerTwoScore()
    {
        playerTwoScore++;
    }
}
