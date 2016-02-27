using UnityEngine;
using System.Collections;
using HighlightingSystem;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Highlighter))]

public class InteractableObject : MonoBehaviour 
{
	/*
	 * Jonathon Wigley, 2/21
	 */

	private ObjectBehavior behavior;
	private AudioSource constantSound;
	public AudioClip collisionSound;

	private LightMissionController controller;

	//Sound delay threshold is the time that has to pass before the collision sound will play again
	[SerializeField]
	private float soundDelayThreshold = 0.75f;
	private float soundDelayer = 0;

	void Start() 
	{
		//set references to the object's traits and collision sound
		behavior = GetComponent<ObjectBehavior>();
		constantSound = GetComponent<AudioSource>();

		if(collisionSound == null)
			collisionSound = constantSound.clip;

		controller = GameObject.Find("LightController").GetComponent<LightMissionController>();

		GameObject.FindGameObjectWithTag("GameController").GetComponent<VolumeController>().sendTransform(transform);
	}

	void Update()
	{
		if(soundDelayer <= soundDelayThreshold)
		{
			soundDelayer += Time.deltaTime;
		}
	}

	//When this object collides with something, play the collision sound
	void OnCollisionEnter(Collision other)
	{
		// If the sound hasn't already played within the soundDelayThreshold
		if(soundDelayer > soundDelayThreshold)
		{
			constantSound.PlayOneShot(collisionSound);
			soundDelayer = 0;
		}
	}

	//determine what interaction to occur based on what object the player is holding
	public void specialInteract(GameObject heldObj)
	{
		//if the player is holding an object, run through the interaction between objects
		if(heldObj != null)
		{
			ObjectBehavior otherBehavior = heldObj.transform.gameObject.GetComponent<ObjectBehavior>();

			//if player is holding a flame, set the object on fire
			if(behavior.trait_Flammable && otherBehavior.trait_Flame)
			{
				//set this object on fire and set flame child to true
				behavior.trait_Flame = true;
				transform.FindChild("Flame").gameObject.SetActive(true);
			}

			//if player is holding something sharp, cut this object
			if(behavior.trait_Severable && otherBehavior.trait_Sharp)
			{
				behavior.trait_Severable = false;
				GetComponent<Rigidbody>().isKinematic = false;

				GameObject.Find("mod_frankie_01").GetComponent<LivingMovement>().TransitionPath();
			}
		}

		// If this object is a flame, toggle the fire
		if(behavior.trait_Flammable)
		{
			//set this object on fire and set flame child to true
			behavior.trait_Flame = !behavior.trait_Flame;
			transform.FindChild("Flame").gameObject.SetActive(behavior.trait_Flame);
			constantSound.PlayOneShot(collisionSound);
		}

		// If this object is a power source, toggle it on and off
		if(behavior.trait_PowerSource)
		{
			// Toggle the power and set any child lights to inactive
			behavior.trait_Powered = !behavior.trait_Powered;

			//GetComponent<LightScript>().triggerAI();

			if(name != "CircuitBreaker_MDL_PDH")
			{
				for(int i = 0; i < transform.childCount; i++)
				{
					transform.GetChild(i).gameObject.SetActive(behavior.trait_Powered);
				}

				controller.CheckLights();
			}
			else
			{
				transform.FindChild("LightsOn").gameObject.SetActive(behavior.trait_Powered);
				transform.FindChild("LightsOff").gameObject.SetActive(!behavior.trait_Powered);
			}

			constantSound.PlayOneShot(collisionSound);
		}

		// If this object is noisy, play its sound
		if(behavior.trait_Noisy)
		{
			// Make noise
			constantSound.PlayOneShot(collisionSound);

			behavior.trait_Powered = !behavior.trait_Powered;

			if(behavior.trait_Powered)
			{
				constantSound.Play();
				constantSound.loop = true;
			}
			else
			{
				constantSound.Stop();
			}
		}

	}

	public void blastInteract()
	{
		// Put out the fire
		if(behavior.trait_Flame)
		{
			behavior.trait_Flame = false;
			transform.FindChild("Flame").gameObject.SetActive(false);
		}

	}

}
