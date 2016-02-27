using UnityEngine;
using System.Collections;

public class LivingSettings : MonoBehaviour {

	public float patrolSpeed = 2f;
	public float patrolWaitTime = 1f;
	public float nervousSpeed = 2.5f;
	public float nervousWaitTime = .75f;
	public float scaredSpeed = 3.5f;
	public float scaredWaitTime = .5f;
	public float fleeSpeed = 5f;
	public float absoluteRadius = .5f;
	public float hearingRadius = 5f;
	[HideInInspector]
	public bool patrol = true;

	public PatrolPath[] paths;

	//variables
	public string[] phobia;
	
	//time spent patroling to lose fear
	public float calmTimer;
	//amount of fear lost when patroling
	public int calmValue;
	//time spent investigating things
	public float curiousTimer;
	//int between 0 and 60
	public int fear;
	//increased for each interaction
	public int fearMult;

	public enum FearState{calm, nervous, scared, terrified};
	public FearState fearState;
}
