using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour 
{
	/*
	 * Jonathon Wigley, 1/14
	 * 
	 * Script causes attached object to appear to face the direction of the player.
	 * 
	 * By having the object face a direction according to the direction the player's 
	 * camera is facing rather than the actual player position, you get a smoother 
	 * effect.
	 */

	private Camera mainCamera;

	void Start() 
	{
		mainCamera = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();
	}

	void Update() 
	{
		/*uncomment this if you want the object to face the player position
		  rather than match how the player is looking*/
		//gameObject.transform.LookAt(mainCamera.transform.position);

		gameObject.transform.rotation = mainCamera.transform.rotation;
	}
}
