using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UIManager : NetworkBehaviour
{
    public void StartGame()
    {
        if (isServer)
        {
            MiniNetworkManager mnm = GameObject.Find("NetworkManager").GetComponent<MiniNetworkManager>();
            mnm.ServerChangeScene("TransitionMultiplayer");
        }
    } 
}
