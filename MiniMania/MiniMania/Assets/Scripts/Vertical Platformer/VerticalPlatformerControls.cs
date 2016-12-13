using UnityEngine;
using System.Collections;

public class VerticalPlatformerControls : MonoBehaviour {
    public string horizontal;
    public string vertical;
    public string jump;
    public float playerSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetAxis(horizontal) > 0)
        {

        }

        if (Input.GetAxis(horizontal) < 0)
        {

        }

        transform.position += new Vector3(Input.GetAxis(horizontal), 0, 0) * playerSpeed * Time.deltaTime;
    }
}
