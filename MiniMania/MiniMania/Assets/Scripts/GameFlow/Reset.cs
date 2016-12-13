using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TextRandomizer.originalGamesAdded = false;
        GameDataManager.Instance.playerOneTotalScore = 0;
        GameDataManager.Instance.playerTwoTotalScore = 0;
        GameDataManager.Instance.P1_BalloonScore = 0;
        GameDataManager.Instance.P2_BalloonScore = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
