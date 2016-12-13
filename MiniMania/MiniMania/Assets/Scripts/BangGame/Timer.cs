using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    public float timer = 10;
    public Text timerText;
    public Text winText;
    public static float random;
    public static bool gameOver = false;
    // Use this for initialization
    void Start () {
        random = Random.Range(3f, timer);
        timerText.text = random.ToString("0");
        gameOver = false;
    }

    // Update is called once per frame
    void Update() {
        if (gameOver == false)
        {
            random -= Time.deltaTime;
            if (random > 3)
            {
                timerText.text = "  " + random.ToString("0");
            }

           else if(random<=3 && random > 0)
            {
                timerText.text = "";
            }
           else if (random <= 0)
            {
                timerText.text = "BANG";
            }

          


        }

        if (PlayerControllerBang.shotsMissed == 2)
        {
            winText.text = "     Tie Game";
            StartCoroutine("ChangeLevel");
            gameOver = true;
        }

        if (winText.text.Contains("Win"))
        {
            StartCoroutine("ChangeLevel");
        }
    }

    public IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Transition");
    }
}
