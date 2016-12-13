using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public Text Score1;
    public Text Score2;

    void Update()
    {
        Score1.text = GameDataManager.Instance.P1_BalloonScore.ToString();
        Score2.text = GameDataManager.Instance.P2_BalloonScore.ToString();

    }
}