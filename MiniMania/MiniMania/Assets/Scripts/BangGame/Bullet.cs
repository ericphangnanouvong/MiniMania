using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {
    public int direction;
    
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (direction == 1)
        {
            this.transform.Translate(Vector3.right*1f);
        }

        if (direction == -1)
        {
            this.transform.Translate(Vector3.right*-1f);
        }

    }
}
