using UnityEngine;
using System.Collections;

public class CandleScript : MonoBehaviour {

    public bool IsInRoom;
    public LightMissionController controller;


    // Use this for initialization
    void Start ()
    {
        IsInRoom = true;
	}
    public void useCheckLights()
    {
        controller.CheckLights();
    }

}
