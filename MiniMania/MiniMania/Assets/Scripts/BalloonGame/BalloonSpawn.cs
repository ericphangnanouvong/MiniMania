using UnityEngine;
using System.Collections;

public class BalloonSpawn : MonoBehaviour {
    
    public GameObject balloon;
    public float spawnTime;
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
       
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the balloon prefab at the randomly selected spawn point's position and rotation.
        Instantiate(balloon, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

}
