using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour {

    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
           if (_instance == null)
            {
                GameObject go = new GameObject("PoolManager");
                go.AddComponent<PoolManager>();
            }
            return _instance;
        }
    }

    public GameObject RedArrowPrefab;
    public GameObject BlueArrowPrefab;
    public GameObject RedBalloonPrefab;
    public GameObject BlueBalloonPrefab;
    public GameObject ArrowContainer;
    public GameObject BalloonContainer;
    public int ObjToSpawn = 20;

    public List<GameObject> redarrowList = new List<GameObject>();
    public List<GameObject> bluearrowList = new List<GameObject>();
    public List<GameObject> redballoonList = new List<GameObject>();
    public List<GameObject> blueballoonList = new List<GameObject>();

    void Awake()
    {
        _instance = this;
    }
    
    void Start()
    {
        for(int i = 0; i < ObjToSpawn; i++)
        {
            GameObject arrow1 = Instantiate(RedArrowPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            GameObject arrow2 = Instantiate(BlueArrowPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            arrow1.transform.parent = ArrowContainer.transform;
            arrow2.transform.parent = ArrowContainer.transform;
            arrow1.SetActive(false);
            arrow2.SetActive(false);
            redarrowList.Add(arrow1);
            bluearrowList.Add(arrow2);

            GameObject balloon1 = Instantiate(RedBalloonPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            GameObject balloon2 = Instantiate(BlueBalloonPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            balloon1.transform.parent = BalloonContainer.transform;
            balloon2.transform.parent = BalloonContainer.transform;
            balloon1.SetActive(false);
            balloon2.SetActive(false);
            redballoonList.Add(balloon1);
            blueballoonList.Add(balloon2);
        }
    }
}
