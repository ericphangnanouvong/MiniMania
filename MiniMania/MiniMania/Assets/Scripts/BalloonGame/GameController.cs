using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text Score1;
    public Text Score2;
    public Text timeText;
    public Text winText;
    public float gameLength;
	private bool p1wins = false;
	private bool p2wins = false;
    
    void Update()
    {
		Score1.text = GameDataManager.Instance.P1_BalloonScore.ToString();
        Score2.text = GameDataManager.Instance.P2_BalloonScore.ToString();
        gameLength -= Time.deltaTime;
        timeText.text = gameLength.ToString("00");

        if (gameLength <= 0)
        {
            if(GameDataManager.Instance.P1_BalloonScore > GameDataManager.Instance.P2_BalloonScore)
            {
                winText.text = "Player 1 Wins";
				p1wins = true;
            }

            else if (GameDataManager.Instance.P1_BalloonScore < GameDataManager.Instance.P2_BalloonScore)
            {
                winText.text = "Player 2 Wins";
				p2wins = true;
            }

            else
            {
                winText.text = "Tie Game";
            }


            StartCoroutine("ChangeLevel");
            timeText.text = "0";
        }
    }

    public IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(3);
		if(p1wins)
			GameDataManager.Instance.playerOneTotalScore += 1;
		else
			GameDataManager.Instance.playerTwoTotalScore += 1;
        SceneManager.LoadScene("Transition");
    }
}