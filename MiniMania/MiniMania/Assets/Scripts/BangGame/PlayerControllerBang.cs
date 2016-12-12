using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControllerBang : MonoBehaviour {
    public string mainButton;
    public GameObject bullet;
    public int direction;
    private bool bulletShot = false;
    private Animator animator;
    public static float shootTime;
    public static int shotsMissed = 0;
    public Text winText;

	// Use this for initialization
	void Start () {
	    if(gameObject.tag== "Player One")
        {
            direction = 1;
        }

        if (gameObject.tag == "Player Two")
        {
            direction = -1;
        }
        animator = gameObject.GetComponent<Animator>();
        shotsMissed = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(mainButton) && bulletShot == false) 
        {
            if (direction == 1 && Timer.random <=0)
            {
                GameObject bulletPrefab = Instantiate(bullet, this.transform.position + transform.right * 2, Quaternion.identity) as GameObject;
                bulletPrefab.GetComponent<Bullet>().direction = direction;
                animator.Play("PlayerOneShoot");
                shootTime = Mathf.Abs(Timer.random);
            }

            else if (direction == 1 && Timer.random > 0)
            {
                animator.Play("PlayerOneShoot");
                shotsMissed += 1;
            }

            if (direction == -1 && Timer.random <= 0)
            {
                GameObject bulletPrefab = Instantiate(bullet, this.transform.position + transform.right * 2, Quaternion.identity) as GameObject;
                bulletPrefab.GetComponent<Bullet>().direction = direction;
                animator.Play("PlayerTwoShoot");
                shootTime = Mathf.Abs(Timer.random);
            }

            else if (direction == -1 && Timer.random > 0)
            {
                animator.Play("PlayerTwoShoot");
                shotsMissed += 1;
            }

            bulletShot = true;
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (this.gameObject.tag == "Player One" && Timer.gameOver == false)
        {
            winText.text = "Player 2 Wins " + PlayerControllerBang.shootTime.ToString("0.000") +"s";
            Timer.gameOver = true;
            Destroy(this.gameObject, 1f);

        }

        else if (this.gameObject.tag == "Player Two" && Timer.gameOver == false)
        {
            winText.text = "Player 1 Wins " + PlayerControllerBang.shootTime.ToString("0.000")+ "s";
            Timer.gameOver = true;
            Destroy(this.gameObject, 1f);

        }
    }


}
