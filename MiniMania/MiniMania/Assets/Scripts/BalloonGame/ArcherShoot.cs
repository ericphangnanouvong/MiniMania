using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ArcherShoot : MonoBehaviour {

    public GameObject arrow;
    public GameObject spawnPoint;
    public int archerType; //1 for red -- 2 for blue
    public string fireButton;
    public Animator anim;
    public int controller;

    // Use this for initialization
    void Start () {
	
	}
    public void detectPressedKeyOrButton()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
                Debug.Log("KeyCode down: " + kcode);
        }
    }

    // Update is called once per frame
    void Update()
    {

        detectPressedKeyOrButton();
        if (Input.GetButtonDown(fireButton))
        {
            //check the pool list to see if any items are inactive;
            if (archerType == 1)
            {
                for (int i = 0; i < PoolManager.Instance.redarrowList.Count; i++)
                {

                    if (PoolManager.Instance.redarrowList[i].activeInHierarchy == false)
                    {

                        anim.SetBool("Shoot", true);
                        PoolManager.Instance.redarrowList[i].SetActive(true);
                        PoolManager.Instance.redarrowList[i].transform.position = spawnPoint.transform.position;
                        Invoke("StopAnim", 0.667f);

                        break;
                    }
                }
            }

            
            
                // detectPressedKeyOrButton();
                //check the pool list to see if any items are inactive;
                if (archerType == 2)
                {
                    for (int i = 0; i < PoolManager.Instance.bluearrowList.Count; i++)
                    {

                        if (PoolManager.Instance.bluearrowList[i].activeInHierarchy == false)
                        {

                            anim.SetBool("Shoot", true);
                            PoolManager.Instance.bluearrowList[i].SetActive(true);
                            PoolManager.Instance.bluearrowList[i].transform.position = spawnPoint.transform.position;
                            Invoke("StopAnim", 0.667f);
                            break;
                        }
                    }
                }

            }
        }
    


   /* void Spawn()
    {

        // Create an instance of the balloon prefab at the randomly selected spawn point's position and rotation.
        Instantiate(arrow, spawnPoint.gameObject.transform.position, spawnPoint.transform.rotation);

    }*/

    void StopAnim()
    {
        anim.SetBool("Shoot", false);

    }
}
