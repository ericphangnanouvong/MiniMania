using UnityEngine;
using System.Collections;


public class GameDataManager
    {


        private static GameDataManager instance = null;

        public static GameDataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameDataManager();
                }
                return instance;
            }
        }


        // PlayerData Constructor:
        private GameDataManager()
        {

            // Initialize high score with the score stored in PlayerPrefs. 

        }


        // Accessors:

        private int p1_balloonscore = 0;

        public int P1_BalloonScore
        {
            get
            {
                return this.p1_balloonscore;
            }
            set
            {
                p1_balloonscore = value;

                playerOneTotalScore += p1_balloonscore;

            }
        }

        private int p2_balloonscore = 0;

        public int P2_BalloonScore
        {
            get
            {
                return this.p2_balloonscore;
            }
            set
            {
                p2_balloonscore = value;

                playerTwoTotalScore += p2_balloonscore;

            }
        }


        private int playeronetotalScore = 0;

        public int playerOneTotalScore
        {
            get
            {
                return this.playeronetotalScore;
            }
            set
            {
                playeronetotalScore = value;

            }
        }

        private int playertwototalScore = 0;

        public int playerTwoTotalScore
        {
            get
            {
                return this.playertwototalScore;
            }
            set
            {
                 playertwototalScore = value;

            }
        }
    }



/*
    static public int playerOneTotalScore;
	static public int playerTwoTotalScore;
	// Use this for initialization
	void Start () 
	{
		playerOneTotalScore = 0;
		playerTwoTotalScore = 0;
	}

	// Update is called once per frame
	void Update () {

	}
<<<<<<< HEAD

   
=======
    */


