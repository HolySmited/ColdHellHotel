using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightMissionController : MonoBehaviour {

    public string Name;
    public List<GameObject> switchList;
    public bool sentinel = true;
    LivingMovement NPC;


    // Use this for initialization
    void Start ()
    {
        NPC = GameObject.Find("mod_frankie_01").GetComponent<LivingMovement>();

        foreach (GameObject light in switchList)
        {
            light.GetComponentInChildren<LightScript>().controller = this;
        }    

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void CheckLights()
    {
		sentinel = true;
        foreach (GameObject _switch in switchList)
        {
			for(int i = 0; i < _switch.transform.childCount; i++)
			{
				if(_switch.transform.GetChild(i).gameObject.activeSelf)
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
		Debug.Log(sentinel);


    }
    void ChangeAIState()
    {
        NPC.TransitionPath();
    }



}
