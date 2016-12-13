using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerBang : MonoBehaviour {
    public string mainButton;
    public GameObject bullet;
    public int direction;
    private bool bulletShot = false;
    private Animator animator;
    public static float shootTime;
    public static int shotsMissed = 0;
    public Text winText;
    public Text playerOneTime;
    public Text playerTwoTime;
    public static float player1Time;
    public static float player2Time;

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

        player1Time = 10000000000000;
        player2Time = 10000000000000;
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
                player1Time = Mathf.Abs(Timer.random);
                playerOneTime.text = player1Time.ToString("0.000") + "s";
            }

            else if (direction == 1 && Timer.random > 0)
            {
                animator.Play("PlayerOneShoot");
                playerOneTime.text = "Missed";
                player1Time = 10000000000000;
                shotsMissed += 1;
            }

            else if (direction == -1 && Timer.random <= 0)
            {
                GameObject bulletPrefab = Instantiate(bullet, this.transform.position + transform.right * 2, Quaternion.identity) as GameObject;
                bulletPrefab.GetComponent<Bullet>().direction = direction;
                animator.Play("PlayerTwoShoot");
                player2Time = Mathf.Abs(Timer.random);
                playerTwoTime.text = player2Time.ToString("0.000") + "s";
            }

            else if (direction == -1 && Timer.random > 0)
            {
                animator.Play("PlayerTwoShoot");
                playerTwoTime.text = "Missed";
                player2Time = 10000000000000;
                shotsMissed += 1;
            }

            bulletShot = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag == "Player One" && Timer.gameOver == false)
        {
            if (player2Time < player1Time)
            {
                winText.text = "Player 2 Wins ";
                GameDataManager.Instance.playerTwoTotalScore++;
                Destroy(this.gameObject);
            }

            else if (player2Time > player1Time)
            {
                winText.text = "Player 1 Wins ";
                Destroy(GameObject.FindGameObjectWithTag("Player Two"));
                GameDataManager.Instance.playerOneTotalScore++;
            }

            else if (player2Time == player1Time)
            {
               winText.text = "     Tie Game";
            }
            
            Destroy(other.gameObject);
            Timer.gameOver = true;         
        }

        else if (this.gameObject.tag == "Player Two" && Timer.gameOver == false)
        {
            if (player1Time < player2Time)
            {
                winText.text = "Player 1 Wins ";
                GameDataManager.Instance.playerOneTotalScore++;
                Destroy(this.gameObject);            
            }

            else if (player1Time > player2Time)
            {
                winText.text = "Player 2 Wins ";
                Destroy(GameObject.FindGameObjectWithTag("Player One"));
                GameDataManager.Instance.playerTwoTotalScore++;
            }

            else if (player2Time == player1Time)
            {
                winText.text = "     Tie Game";
            }

            Destroy(other.gameObject);
            Timer.gameOver = true;
        }
    }
}
