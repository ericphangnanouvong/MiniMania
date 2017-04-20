using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BangPlayerControllerMultiplayer : NetworkBehaviour
{
    private BangGameManager bangGameManager;
    public GameObject bulletPrefab;
    private int bulletSpeed = 20;

    private bool IsPlayerOne { get; set; } //Used to determine the player order.

    private bool isBulletShot = false; //Used to disable player from shooting twice.

    void Start()
    {
        bangGameManager = GameObject.Find("BangGameManager").GetComponent<BangGameManager>();
        if (gameObject.tag == "Player One")
        {
            IsPlayerOne = true;
        }
        else if (gameObject.tag == "Player Two")
        {
            IsPlayerOne = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority)
        {
            return;
        }

        if (Input.GetButtonDown("MainAction") && isBulletShot == false)
        {
            //Check if player shot or missed.
            if (bangGameManager.isCountdownOver)
            {
                CmdFire();
            }
            else
            {
                CmdMiss();
            }

            isBulletShot = true;
        }
    }

    [Command]
    void CmdFire()
    {
        GameObject bullet;

        if (IsPlayerOne == true)
        {
            bullet = Instantiate(bulletPrefab, this.transform.position + transform.right * 2, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = Vector3.right * bulletSpeed;
            bangGameManager.PlayerOneShot();
        }
        else
        {
            bullet = Instantiate(bulletPrefab, this.transform.position - transform.right * 2, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = -Vector3.right * bulletSpeed;
            bangGameManager.PlayerTwoShot();
        }

        NetworkServer.Spawn(bullet);
    }

    [Command]
    void CmdMiss()
    {
        if (IsPlayerOne == true)
        {
            bangGameManager.PlayerOneMiss();
        }
        else
        {
            bangGameManager.PlayerTwoMiss();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (IsPlayerOne && bangGameManager.gameOver == false)
            {
                CmdKillPlayer();
                Destroy(this.gameObject);
                Destroy(other.gameObject); //Destroys the bullet.
            }
            else if (!IsPlayerOne && bangGameManager.gameOver == false)
            {
                CmdKillPlayer();
                Destroy(this.gameObject);
                Destroy(other.gameObject); //Destroys the bullet.
            }
    }

    [Command]
    void CmdKillPlayer()
    {
        if (IsPlayerOne)
        {
            bangGameManager.KillPlayerOne();
        }
        else
        {
            bangGameManager.KillPlayerTwo();
        }
    }
}
