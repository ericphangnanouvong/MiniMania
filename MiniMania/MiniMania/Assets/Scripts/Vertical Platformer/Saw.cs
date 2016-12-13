using UnityEngine;
using System.Collections;

public class Saw : MonoBehaviour {
    public int direction;
    private float sawSpeed;
    // Use this for initialization
    void Start () {
        sawSpeed = Random.Range(.05f, .1f);
	}
	
	// Update is called once per frame
	void Update () {
        if (direction == 1)
        {
            transform.position += new Vector3(sawSpeed, 0, 0);
            this.gameObject.transform.Rotate(0,0,-5);
        }

        if (direction == -1)
        {
            transform.position += new Vector3(-sawSpeed, 0, 0);
            this.gameObject.transform.Rotate(0, 0, 5);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Edge")
        {
            direction *= -1;
        }
    }
}
