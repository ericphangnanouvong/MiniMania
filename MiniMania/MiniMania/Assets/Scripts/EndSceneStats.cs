using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneStats : MonoBehaviour {

	private PlayerController paradrop;
	private PlayerControllerBang bangGame;
	private VPTimer vptime;

	private bool hasStatsSceneLoaded = false;

	//private int p1BangScore;
	//private int p2BangScore;

	//	private float p1ParaDropTime;
	//	private float p2ParaDropTime;

	//private float p1Vertime;
	//private float p2VertTime;




	public Text p1ParaDropText = null;
	public Text p2ParaDropText = null;

	public Text p1BalloonText = null;
	public Text p2BalloonText = null;

	public Text p1BangGameText = null;
	public Text p2BangGameText = null;

	public Text p1VertTimeText = null;
	public Text p2VertTimeText = null;

	public Text p1TotalScoreText = null;
	public Text p2TotalScoreText = null;




	void Start () 
	{
		hasStatsSceneLoaded = true;

		//	p1BalloonScore = GameDataManager.Instance.P1_BalloonScore;
		//	p2BalloonScore = GameDataManager.Instance.P2_BalloonScore;

		paradrop = GameObject.Find("Main Menu_2").GetComponent<PlayerController>();
		bangGame = GameObject.Find("Main Menu_2").GetComponent<PlayerControllerBang>();
		vptime = GameObject.Find("Main Menu_2").GetComponent<VPTimer>();



	}

	// Update is called once per frame
	void Update ()
	{


		if(hasStatsSceneLoaded == true)
		{

			this.p1ParaDropText.text = "P1 ParaDrop: " + GameDataManager.Instance.PlayerOneParaDistance.ToString("00");
			this.p2ParaDropText.text = "P2 ParaDrop: " + GameDataManager.Instance.PlayerTwoParaDistance.ToString("00");

			Debug.Log("Para Drop Running");

			this.p1BangGameText.text = "P1 Bang Game Time: " + GameDataManager.Instance.PlayerOneBangTime.ToString("0.0");
			this.p2BangGameText.text = "P2 Bang Game Time: " + GameDataManager.Instance.PlayerTwoBangTime.ToString("0.0");

			Debug.Log("Bang Game Running");

			this.p1BalloonText.text = "P1 Balloon Score: " + GameDataManager.Instance.P1_BalloonScore.ToString();
			this.p2BalloonText.text = "P2 Balloon Score: " + GameDataManager.Instance.P2_BalloonScore.ToString();

			Debug.Log("Balloon Game Running");
			this.p1VertTimeText.text = "P2 VertPlat Time: " + GameDataManager.Instance.PlayerOneVertPlatTime.ToString("00");
			this.p2VertTimeText.text = "P2 VertPlat Time: " + GameDataManager.Instance.PlayerOneVertPlatTime.ToString("00");

			Debug.Log("Vert Game Running");
			this.p1TotalScoreText.text = "P1 Total Score: " + GameDataManager.Instance.playerOneTotalScore.ToString();
			this.p2TotalScoreText.text = "P2 Total Score: " + GameDataManager.Instance.playerTwoTotalScore.ToString();



			Debug.Log("Total Score Running");
		}

	}
}
