using UnityEngine;
using System.Collections;

public class LivingSight : MonoBehaviour {

	public Vector3 lastInteraction;
	public Vector3 lastSeenInteraction;
	private int lastPriority;
	public float timeBetweenInteraction;
	public float noiseThreshold;
	private SphereCollider col;
	private LivingSettings settings;
	private LivingState state;

	void Start(){
		settings = this.GetComponent<LivingSettings> ();
		state = this.GetComponent<LivingState> ();


	}


	// Update is called once per frame
	void Update () {
	}


	void CheckSenses(Interaction i){
		if (CheckAbsolute(i) || CheckHearing (i) || CheckSight(i)) {
			lastSeenInteraction = lastInteraction;
			state.Reaction(i);
		}
	}

	bool CheckAbsolute(Interaction i){
		if (Vector3.Distance (transform.position, i.location) < this.settings.absoluteRadius) {
			return true;
		}
		return false;
	}

	bool CheckSight(Interaction i){
		if (Vector3.Dot (this.transform.position, i.location) > 0) {
			RaycastHit hit;
			Vector3 heading = this.transform.position - i.location;
			float distance = heading.magnitude;
			Vector3 direction = heading/distance;
			if(!Physics.Raycast(this.transform.position, direction, out hit, distance)){
				return true;
			}
		}
		return false;
	}

	bool CheckHearing(Interaction i){
		if (Vector3.Distance (transform.position, i.location) < this.settings.hearingRadius) {
			RaycastHit hit;
			Vector3 heading = this.transform.position - i.location;
			float distance = heading.magnitude;
			Vector3 direction = heading/distance;
			if(!Physics.Raycast(this.transform.position, direction, out hit, distance)){
				return true;
			}
		}
		return false;
	}

}
