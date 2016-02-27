using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterMissionControl : MonoBehaviour {

    public List<GameObject> missionList = new List<GameObject>();
    private bool initialized;
    public int index;
    public LivingSight frankie;
    //public GameObject[] _MissionList;




    // Use this for initialization
    void Start ()
    {
        frankie = GameObject.FindGameObjectWithTag("Frankie").GetComponent<LivingSight>();
	}
	
	// Update is called once per frame
	void Update ()
    {


	    if(!initialized)
        {
            Initialize();
        }
	}
    void Initialize()
    {
        index = 0;
        foreach (GameObject mission in missionList)
        {
            mission.SetActive(false);
        }
        missionList[index].SetActive(true);

    }

    void Increment()
    {
        missionList[index].SetActive(false);
        missionList[index++].SetActive(true);
        switch (index)
        {
           /* case 0:
                frankie.UpgradeFear();
                break;
            case 2:
                frankie.UpgradeFear();
                break;
            case 4:
                frankie.UpgradeFear();
                break;*/

        }
        index++;
    }
}
