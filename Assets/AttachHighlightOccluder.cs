using UnityEngine;
using System.Collections;
using HighlightingSystem;
using System.Collections.Generic;

public class AttachHighlightOccluder : MonoBehaviour 
{
	void Awake()
	{
		GameObject[] nonInteractArray = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];

		foreach(GameObject obj in nonInteractArray)
		{
			if(obj.layer != LayerMask.NameToLayer("Items_Interactable"))
			{
				obj.AddComponent(typeof(HighlighterOccluder));
			}
		}
	}
}
