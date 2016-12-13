using UnityEngine;
using System.Collections;

public class PlayerData
{
    private static PlayerData instance = null;

    public static PlayerData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerData();
            }
            return instance;
        }
    }


    // PlayerData Constructor:
    private PlayerData()
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

        }
    }

}