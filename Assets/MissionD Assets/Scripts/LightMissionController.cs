using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightMissionController : MonoBehaviour {

    public string Name;
    public List<GameObject> switchList;
    public bool sentinel = true; //this name has no meaning, only to irritate Zach
    public GameObject candle;
    LivingMovement NPC;


    // Use this for initialization
    void Start ()
    {
        NPC = GameObject.Find("Frankie_BASE").GetComponent<LivingMovement>();

        foreach (GameObject _switch in switchList)
        {
            //if(_switch.GetComponentInChildren<LightScript>())
                _switch.GetComponentInChildren<LightScript>().controller = this;
        }    

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void CheckLights()
    {
        //print("are you fucking running?");
		sentinel = true;
        foreach (GameObject _switch in switchList)
        {
            //Debug.Log(_switch+ "Switch");
           // Debug.Log(candle + "Candle");
            for (int i = 0; i < _switch.transform.childCount; i++)
			{
                if (_switch == candle)
                {
                    //Debug.Log(candle + "Candle");
                    if (_switch.transform.GetComponent<CandleScript>().IsInRoom == true)
                    {
                        sentinel = false;
                        break;
                    }
                }
                else if (_switch.transform.GetChild(i).gameObject.activeSelf)
				{
					sentinel = false;
					break;
				}
			}


        }
        if (sentinel)
        {
            ChangeAIState();
        }


       // Debug.Log("test");
		//Debug.Log(sentinel);


    }
    void ChangeAIState()
    {
        NPC.TransitionPath();
    }



}
