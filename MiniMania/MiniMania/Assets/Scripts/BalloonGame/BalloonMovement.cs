using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BalloonMovement : MonoBehaviour {

    public float speed;
    public float minSpeed=0.5f;
    public float maxSpeed=1f;
    public string BalloonType;
    public Animator anim;

    // Use this for initialization
    void Start () {
        speed = Random.Range(minSpeed, maxSpeed);
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "RedArrow")
        {
            if (BalloonType == "red")
            {
                GameDataManager.Instance.P1_BalloonScore += 1;

            }
            else
            {
                GameDataManager.Instance.P1_BalloonScore -= 1;
            }
            anim.SetBool("BalloonPop", true);
            other.gameObject.SetActive(false);
            Invoke("DestroyBalloon", 0.5f);
        }

        if (other.tag == "BlueArrow")
        {
            if (BalloonType == "blue")
            {
                GameDataManager.Instance.P2_BalloonScore += 1;

            }
            else
            {
                GameDataManager.Instance.P2_BalloonScore -= 1;
            }
            anim.SetBool("BalloonPop", true);
            other.gameObject.SetActive(false);
            Invoke("DestroyBalloon", 0.5f);
        }
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.up * Time.deltaTime*speed, Space.World);
        if (transform.position.y > 5)
        {
            this.gameObject.SetActive(false);
        }
    }

    void DestroyBalloon()
    {
       anim.SetBool("BalloonPop", false);
        gameObject.SetActive(false);
    }
}
