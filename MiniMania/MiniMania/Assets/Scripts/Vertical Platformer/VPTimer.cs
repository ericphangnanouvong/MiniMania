using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VPTimer : MonoBehaviour {
    public float gameLengthSeconds;
    private Text timer;
    public static bool VPGameOver = false;
    public Text winText;

	// Use this for initialization
	void Start () {
        timer = gameObject.GetComponent<Text>();
        VPGameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
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
    }

    public IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Transition");
    }
}
