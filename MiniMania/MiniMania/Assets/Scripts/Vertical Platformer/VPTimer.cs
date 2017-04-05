using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VPTimer : MonoBehaviour {
    public float gameLengthSeconds;
    private Text timer;
    public static bool VPGameOver = false;
    public Text winText;
    public Text winText2;
    private float gameStartTimer =3;
    public Text gameStartText;
    private bool gameStarted = false;

    // Use this for initialization
    void Start () {
        timer = gameObject.GetComponent<Text>();
        VPGameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        gameStartTimer -= Time.deltaTime;

        if (gameStartTimer <= 0)
        {
            gameStartText.text = "";
            gameStarted = true;
        }

        else
            gameStartText.text = "  " + gameStartTimer.ToString("00");

        if (gameStarted == true)
        {
            if (VPGameOver == false)
            {
                gameLengthSeconds -= Time.deltaTime;
                timer.text = gameLengthSeconds.ToString("00");
            }

            if (gameLengthSeconds <= 0)
            {
                VPGameOver = true;
                winText.text = "     Tie Game";
                StartCoroutine("ChangeLevel");
                timer.text = "0";
            }

            if (winText.text.Contains("Win"))
            {
                StartCoroutine("ChangeLevel");
            }

            if (winText.text.Contains("1"))
            {
                winText.text = "Player 1 Wins";
                winText2.text = "Player 1 Wins";
            }

            if (winText.text.Contains("2"))
            {
                winText.text = "Player 2 Wins";
                winText2.text = "Player 2 Wins";
            }
        }
    }

    public IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Transition");
    }
}
