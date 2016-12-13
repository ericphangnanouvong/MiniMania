using UnityEngine;
using System.Collections;

public class BalloonSpawn : MonoBehaviour {
    
    public GameObject balloon;
    public float spawnTime;
    public float repeatingSpawnTime;
    public int balloonType;
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", spawnTime, repeatingSpawnTime);
    }

    void Spawn()
    {
        Debug.Log("Balloon Spawned");
       
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the balloon prefab at the randomly selected spawn point's position and rotation.
        //Instantiate(balloon, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        if (balloonType == 1)
        {
            for (int i = 0; i < PoolManager.Instance.redballoonList.Count; i++)
            {

                if (PoolManager.Instance.redballoonList[i].activeInHierarchy == false)
                {

                    PoolManager.Instance.redballoonList[i].SetActive(true);
                    PoolManager.Instance.redballoonList[i].transform.position = spawnPoints[spawnPointIndex].position;

                    break;
                }
            }
        }
        if (balloonType == 2)
        {
            for (int i = 0; i < PoolManager.Instance.blueballoonList.Count; i++)
            {

                if (PoolManager.Instance.blueballoonList[i].activeInHierarchy == false)
                {

                    PoolManager.Instance.blueballoonList[i].SetActive(true);
                    PoolManager.Instance.blueballoonList[i].transform.position = spawnPoints[spawnPointIndex].position;

                    break;
                }
            }
        }

    }


}
