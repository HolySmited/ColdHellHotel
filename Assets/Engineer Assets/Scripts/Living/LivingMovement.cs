using UnityEngine;
using System.Collections;

public class LivingMovement : MonoBehaviour {

	private int wayPointIndex;
	private float patrolTimer;
	private float investigateTimer;
	private NavMeshAgent nav;
	private LivingSettings settings;
	private float currentWaitTime;
	private int pathIndex;
	private Transform[] patrolPoints;


	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		settings = GetComponent<LivingSettings> ();
		pathIndex = 0;
		patrolPoints = GetComponent<PatrolPath>().patrolPoints;
	}
	
	// Update is called once per frame
	void Update () {
		if (settings.patrol)
			Patrolling ();
		else {
			Investigate();
		}
	}
	void Investigate(){
		investigateTimer += Time.deltaTime;
		if (investigateTimer >= currentWaitTime) {
			investigateTimer = 0;
			settings.patrol = true;
			settings.fear += 19;
		}
	}

	void Patrolling(){
        nav.speed = settings.patrolSpeed;
//		print (patrolPoints);
//		print (patrolPoints[wayPointIndex]);
		float delayTime = patrolPoints [wayPointIndex].GetComponent<WaypointSettings> ().delay;

		if (nav.remainingDistance < nav.stoppingDistance) {
			patrolTimer += Time.deltaTime;

			if (patrolTimer >= delayTime - currentWaitTime) {
				if (wayPointIndex == patrolPoints.Length - 1) {
					if(settings.paths[pathIndex].transistionOnEnd)
						TransitionPath();
					wayPointIndex = 0;
				} else {
					wayPointIndex ++;
				}
				patrolTimer = 0;
			}else{

			}
		} else {
			patrolTimer =0;
		}

		nav.destination = patrolPoints [wayPointIndex].position;
		//print (wayPointIndex);
	}

	void setSpeedByState(){
		switch (settings.fear) {
			case 0:
				nav.speed = settings.patrolSpeed;
				currentWaitTime = settings.patrolWaitTime;
				break;
			case 1: 
				nav.speed = settings.nervousSpeed;
				currentWaitTime = settings.nervousWaitTime;
				break;
			case 2:
				nav.speed = settings.scaredSpeed;
				currentWaitTime = settings.scaredWaitTime;
				break;
			case 3:
				nav.speed = settings.fleeSpeed;
				currentWaitTime = 0.0f;
				break;
		}
	}

	public void SetNavDestination(Vector3 dest){
		nav.SetDestination (dest);
	}

	public void SetCurrentWaitTime(float newTime){
		currentWaitTime = newTime;
	}
	public void TransitionPath(){
		wayPointIndex = 0;
		pathIndex++;
		if (pathIndex >= settings.paths.Length)
			print ("You didn't lose");
		else
			patrolPoints = settings.paths [pathIndex].patrolPoints;
	}
	public void TransitionPath(string name){
		wayPointIndex = 0;
		for (int i = 0; i < settings.paths.Length; i++) {
			if(settings.paths[i].name == name){
				pathIndex = i;
				patrolPoints = settings.paths[pathIndex].patrolPoints;
			}
		}
	}
}
