using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {

    Light _light;
    Camera _camera;
    public LightMissionController controller;

	// Use this for initialization
	void Start ()

    {
        _light = gameObject.GetComponentInChildren<Light>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // Transform objectHit = hit.transform;
                //_light.enabled = !_light.enabled;
                controller.CheckLights();
              

            }
        }
	}
}
