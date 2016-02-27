using UnityEngine;
using System.Collections;

public class LightTriggerScript : MonoBehaviour {

    LightScript parent;
    Light _light;
    public GameObject _switch;
    public Transform ai;
    Collider col;


	// Use this for initialization
	void Start ()
    {
        _light = gameObject.transform.parent.GetComponentInChildren<Light>();
        parent = gameObject.GetComponentInParent<LightScript>();
        col = GetComponent<Collider>();
        ai = GameObject.FindGameObjectWithTag("Frankie").GetComponent<Transform>();

        
	}
    void Update()
    {
        if (Vector3.Distance(parent.waypoint.transform.position,ai.position) < 0.5f)
        {
            _switch.GetComponent<InteractableObject>().specialInteract(null);
            parent.DeactivateComponent();
        }


    }


  /*public void OnTriggerEnter(Collider col)
  {
        Debug.Log("Turn Light Back ON");
        _switch.GetComponent<InteractableObject>().specialInteract(null);

  }
  public void OnTriggerExit(Collider col)
  {
      //parent.DeactivateComponent();
  }*/
}
