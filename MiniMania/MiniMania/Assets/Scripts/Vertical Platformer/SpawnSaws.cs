using UnityEngine;
using System.Collections.Generic;

public class SpawnSaws : MonoBehaviour {
    public List<Transform> SawSpawns;
    private int sawsSpawned = 0;
    public int numberOfSaws;
    public GameObject saw;
	// Use this for initialization
	void Start () {
        for (int x = 0; x < 18; x++)
        {
            SawSpawns.Add(this.gameObject.transform.GetChild(x));
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(sawsSpawned < numberOfSaws)
        {
            int random = Random.Range(0, SawSpawns.Count);
            Instantiate(saw, SawSpawns[random].transform.position, Quaternion.identity);
            SawSpawns.RemoveAt(random);
            sawsSpawned++;
        }
	}
}
