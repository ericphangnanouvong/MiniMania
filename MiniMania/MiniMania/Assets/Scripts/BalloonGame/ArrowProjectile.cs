using UnityEngine;
using System.Collections;

public class ArrowProjectile : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        if(transform.position.x>30)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DestroyArrow")
            Destroy(gameObject);
       
    }

}
