using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public GameObject player;
    public Texture texture;
	// Use this for initialization
	void Start () {
        
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width/2, Screen.height), texture);
        GUI.DrawTexture(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), texture);
    }

	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2,-10);
	}
}
