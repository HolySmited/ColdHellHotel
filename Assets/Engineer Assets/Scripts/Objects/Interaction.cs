using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {
	public Vector3 location;
	public GameObject obj1;
	public GameObject obj2;
	private int fixthis;

	Interaction(Vector3 l, GameObject o1, GameObject o2){
		location = l;
		obj1 = o1;
		obj2 = o2;
	}
}
