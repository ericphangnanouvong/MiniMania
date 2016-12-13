using UnityEngine;
using System.Collections;

public class ArcherShoot : MonoBehaviour {

    public GameObject arrow;
    public GameObject spawnPoint;
    public int archerType; //1 for red -- 2 for blue
    public string fireButton;
    public Animator anim;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(fireButton))
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
