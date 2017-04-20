using UnityEngine;
using UnityEngine.Networking;

public class MiniNetworkManager : NetworkManager
{
    private int count = 0;

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        //base.OnServerAddPlayer(conn, playerControllerId);

        GameObject newPlayer = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        count++;
        if (count == 1)
        {
            newPlayer.GetComponent<Player>().playerNo = 1;
        }
        else
        {
            newPlayer.GetComponent<Player>().playerNo = 2;
        }

        NetworkServer.AddPlayerForConnection(conn, newPlayer, playerControllerId);
    }

    public override void OnServerSceneChanged(string sceneName)
    {
        base.OnServerSceneChanged(sceneName);
        
        Debug.Log("on server scene changed");
    }

    
    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        //ClientScene.Ready(conn);
        base.OnClientSceneChanged(conn);
        
        //ClientScene.Ready(conn);

        switch (networkSceneName)
        {
            case "BangGameMultiplayer":
                GameObject[] characters = GameObject.FindGameObjectsWithTag("Player");

                foreach (var character in characters)
                {
                    character.GetComponent<Player>().AddCharacterOnSceneLoad();
                }
                break;
            case "TransitionMultiplayer":
                break;
            default:
                break;
        }
    }
}
