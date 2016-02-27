using UnityEngine;
using System.Collections;

public class LivingState : MonoBehaviour {




	private LivingSight sight;
	private float timeSinceLastFear;

	private LivingMovement movement;
	private LivingSettings settings;




	// Use this for initialization
	void Start () {
		settings = this.GetComponent<LivingSettings> ();
		settings.fearState = LivingSettings.FearState.calm;
		settings.fearMult = 0;
		settings.fear = 0;
		timeSinceLastFear = 0.0f;
		sight = this.GetComponent<LivingSight>();
		movement = this.GetComponent<LivingMovement> ();
		settings.calmValue = 1;
		settings.calmTimer = 5f;
		settings.curiousTimer = 20f;
	}
	
	// Update is called once per frame
	void Update () {
		CheckFear ();
		if (settings.patrol) {
			Patrol ();
		}
	}


	public void Reaction(Interaction i){
		ResetPatrol ();
		settings.patrol = false;
		movement.SetNavDestination(sight.lastSeenInteraction);
		movement.SetCurrentWaitTime (settings.curiousTimer);
	}

	void Patrol(){
		timeSinceLastFear += Time.deltaTime;
		if (timeSinceLastFear >= settings.calmTimer) {
			settings.fear -= settings.calmValue;
			timeSinceLastFear = 0;
		}
	}

	void ResetPatrol(){
		timeSinceLastFear = 0;
		settings.calmValue = 1;
	}

	void CheckFear(){
		if (settings.fear < 20)
			settings.fearState = LivingSettings.FearState.calm;
		else if(settings.fear >= 20 && settings.fear < 40)
			settings.fearState = LivingSettings.FearState.nervous;
		else if (settings.fear >= 40 && settings.fear < 60)
			settings.fearState = LivingSettings.FearState.scared;
		else
			settings.fearState = LivingSettings.FearState.terrified;
	}

}
