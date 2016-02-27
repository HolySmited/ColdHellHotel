using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {

    Light _light;
    Camera _camera;
    public LightMissionController controller;
    public GameObject AITrigger;
    LivingSight sight;
    float investigateTime;
    public GameObject waypoint;


	// Use this for initialization
	void Start ()

    {

        investigateTime = 5.0f;
        //_light = gameObject.GetComponentInChildren<Light>();
        // _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
       // AITrigger = gameObject.GetComponentInChildren<Transform>().gameObject;

        //AITrigger.SetActive(false);

        sight = GameObject.Find("Frankie_BASE").GetComponent<LivingSight>();


        
	}
	
	// Update is called once per frame
	void Update ()
    {
      
              

         
    }

    public void TriggerAI()
    {
        //Debug.Log("Triggered AI");
        //Debug.Log(waypoint.transform.position);
     // if (sight.RecieveInteraction(waypoint.transform.position, investigateTime))
     // {
           // Debug.Log("Frankie Sighted");
      //      ActivateComponent();
     //  }
     //  else { DeactivateComponent(); }
    }
 
    
    public void ActivateComponent()
    {
        AITrigger.SetActive(true);
    }
    public void DeactivateComponent()
    {
       // AITrigger.SetActive(false);
    }


	
}
