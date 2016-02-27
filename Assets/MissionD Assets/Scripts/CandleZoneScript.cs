using UnityEngine;
using System.Collections;

public class CandleZoneScript : MonoBehaviour {

    public bool test;
    public GameObject candle;


	// Use this for initialization
	void Start ()
    {
        test = true;
            
	}

    /// <summary>
    /// SO! 
    /// I need a boolean that the mission checker looks for  that gets flipped when entering THIS trigger 
    /// 
    /// </summary>
    

  public void OnTriggerEnter(Collider col)
  {
        if (col.transform.gameObject == candle){ }
        //candle.GetComponent<test = true;
        //candle.script.test = true;
        //controller.script.test = true;      
  }
  public void OnTriggerExit(Collider col)
  {
        if (col.transform.gameObject == candle) {
            candle.GetComponent<CandleScript>().IsInRoom = false;
            candle.GetComponent<CandleScript>().useCheckLights();
        }
        //test = false;
        //candle.GetComponent<CandleScript>().IsInRoom = false;
    }
}
