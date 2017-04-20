using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Player : NetworkBehaviour
{
    //References to the player prefabs for each game.
    public GameObject bangCharacterOne;
    public GameObject bangCharacterTwo;

    [SyncVar]
    public int score;

    [SyncVar]
    public int playerNo;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    void Reset()
    {
        bangCharacterOne = (GameObject)Resources.Load("BangCharacterOne", typeof(GameObject));
        bangCharacterTwo = (GameObject)Resources.Load("BangCharacterTwo", typeof(GameObject));
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {/*
        switch (scene.name)
        {
            case "BangGameMultiplayer":
                if (isLocalPlayer && isServer) //For the first player.
                {
                    ClientScene.Ready(connectionToClient);
                    CmdSpawnCharacter("BangGameMultiplayer", playerNo);
                }
                else if (!isServer && isLocalPlayer)
                {
                    ClientScene.Ready(connectionToServer);
                    CmdSpawnCharacter("BangGameMultiplayer", playerNo);
                }
                break;
            case "BalloonGameMultiplayer":
                break;
            case "VerticalPlatformerMultiplayer":
                break;
            case "ParachuteGameMultiplayer":
                break;
            case "TransitionMultiplayer":
                break;
        }*/
    }

    public void AddCharacterOnSceneLoad()
    {
        if (isLocalPlayer)
        {
            CmdSpawnCharacter("BangGameMultiplayer", playerNo);
        }
    }

    [Command]
    void CmdSpawnCharacter(string gameName, int playerNumber)
    {
        switch (gameName)
        {
            case "BangGameMultiplayer":
                if (playerNo == 1)
                {
                    GameObject character = Instantiate(bangCharacterOne, new Vector3(-8, -2.5f, 0), Quaternion.identity);
                    NetworkServer.SpawnWithClientAuthority(character, connectionToClient);
                }
                else if (playerNo == 2)
                {
                    GameObject character = Instantiate(bangCharacterTwo, new Vector3(8, -2.5f, 0), Quaternion.identity);
                    NetworkServer.SpawnWithClientAuthority(character, connectionToClient);
                }
                break;
            case "BalloonGameMultiplayer":
                break;
            case "VerticalPlatformerMultiplayer":
                break;
            case "ParachuteGameMultiplayer":
                break;
            case "TransitionMultiplayer":
                break;
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        Debug.Log("start client");
    }
}




