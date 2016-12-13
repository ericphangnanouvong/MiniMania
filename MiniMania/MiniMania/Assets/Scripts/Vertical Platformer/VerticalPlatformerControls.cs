using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VerticalPlatformerControls : MonoBehaviour {
    public string horizontal;
    public string vertical;
    public string jump;
    public float playerSpeed;
    public float playerJumpForce;
    public GameObject player1Spawn;
    public GameObject player2Spawn;
    private Animator animator;
    public Text winText;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
        if (gameObject.tag == "Player One")
        {
            animator.SetBool("Player1", true);
        }

        else if (gameObject.tag == "Player Two")
        {
            animator.SetBool("Player2", true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        //animations and sprite flipping
        if (VPTimer.VPGameOver == false)
        {
            if (Input.GetAxis(horizontal) > 0.1f)
            {
                animator.SetBool("Running", true);
                animator.SetBool("Idle", false);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            else if (Input.GetAxis(horizontal) < -.01)
            {
                animator.SetBool("Running", true);
                animator.SetBool("Idle", false);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            else if (Input.GetAxis(horizontal) >= -.01 && Input.GetAxis(horizontal) <= 0.1f)
            {
                animator.SetBool("Idle", true);
                animator.SetBool("Running", false);
            }

            //jump raycast 
            RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.right * -.5f, Vector2.down);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position + transform.right * .5f, Vector2.down);
            if (hit.collider != null || hit2.collider != null)
            {
                if (hit.collider.tag == "Ground" || hit.collider.tag.Contains("Player") || hit2.collider.tag == "Ground" || hit2.collider.tag.Contains("Player"))
                {
                    if (hit.distance < 1f || hit2.distance < 1f)
                    {
                        animator.SetBool("Jump", false);
                        if (Input.GetButtonDown(jump))
                        {
                            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpForce, ForceMode2D.Impulse);
                        }
                    }
                }

                if (hit.distance >= 1f || hit2.distance >= 1f)
                {
                    animator.SetBool("Jump", true);
                }
            }

            //move player
            transform.position += new Vector3(Input.GetAxis(horizontal), 0, 0) * playerSpeed * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Saw")
        {
            if (this.gameObject.tag.Contains("One"))
            {
                this.transform.position = player1Spawn.transform.position;
            }

            else if (this.gameObject.tag.Contains("Two"))
            {
                this.transform.position = player2Spawn.transform.position;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Flag" && VPTimer.VPGameOver == false)
        {
            if (this.gameObject.tag.Contains("One"))
            {
                winText.text = "Player 1 Wins";
                GameDataManager.Instance.playerOneTotalScore++;
            }

            else if (this.gameObject.tag.Contains("Two") && VPTimer.VPGameOver == false)
            {
                winText.text = "Player 2 Wins";
                GameDataManager.Instance.playerTwoTotalScore++;
            }

            animator.SetBool("Idle", true);
            animator.SetBool("Running", false);
            animator.SetBool("Jump", false);
            VPTimer.VPGameOver = true;
        }
    }
}
