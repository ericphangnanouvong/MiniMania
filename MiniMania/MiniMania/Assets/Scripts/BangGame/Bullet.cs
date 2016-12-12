using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {
    public int direction;
    public Text winText;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (direction == 1)
        {
            this.transform.Translate(Vector3.right*.5f);
        }

        if (direction == -1)
        {
            this.transform.Translate(Vector3.right*-.5f);
        }

    }
}
