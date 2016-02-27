/*  Script: PlayerInteractor.cs
    Author: Zackary Hoyt

    Description:
    Allows the player to interact with specific objects.
        Allows the player to hold an object. Hold is broken if object
        gets too far away. Object will travel to a point in front of
        the player, so it tries to keep with the player as they move.

    Allows the player to create a blast wave to blast forward all the 
    objects within a forward cone.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HighlightingSystem;

public class PlayerInteractor : MonoBehaviour
{
	[SerializeField]
	bool objInRange = false, interacting = false;
	[SerializeField]
	float cdTimer_Blast = 0, cdTimer_Interact = 0;
	
	GameObject heldObj = null;
	GameObject lastHit = null;
	float heldDist = 0;
	
	void FixedUpdate()
	{
		if ((!interacting || heldObj.GetComponent<ObjectBehavior>().trait_Sharp) && cdTimer_Interact <= 0)
			objInRange = checkForObjInRange();
		if (heldObj != null)
			manageHeldObject();
		
		cdTimer_Blast -= Time.deltaTime;
		cdTimer_Interact -= Time.deltaTime;
	}
	
	//  Check if there is an Interactable Object Immediately Before the Player
	bool checkForObjInRange()
	{
		//  Check for an Object within Range
		//  Utilizes a Raycast
		Vector3 rayOrigin = transform.position;
		Vector3 rayDir = transform.forward;
		float rayDist = PCSettings.staticRef.interactReach;
		
		RaycastHit hitInfo;
		if (Physics.Raycast(rayOrigin, rayDir, out hitInfo, rayDist, PCSettings.staticRef.interactableObjectsLM))
		{
			// This object's highlighter component
			Highlighter highlight = hitInfo.transform.GetComponent<Highlighter>();
			
			// If an object has been hit
			if(lastHit != null)
			{
				// Last hit object's hightligher component
				Highlighter lastHighlight = lastHit.GetComponent<Highlighter>();
				
				// If the last hit object is not the same as the current, turn off the last hit highlighter
				if(!highlight.Equals(lastHighlight))
				{
					// Turn off highlighter of last hit object that is no longer being hit
					lastHighlight.Off();
				}
			}
			
			// Set this object as the last hit for in other passes
			lastHit = hitInfo.transform.gameObject;
			
			// Activate the highlighting on the object when it is interactable, based on object type
			if(hitInfo.transform.GetComponent<ObjectBehavior>().trait_Severable)
				highlight.ConstantOn(Color.white);
			else if(hitInfo.transform.GetComponent<ObjectBehavior>().trait_Flammable)
				highlight.ConstantOn(Color.red);
			else if(hitInfo.transform.GetComponent<ObjectBehavior>().trait_PowerSource)
				highlight.ConstantOn(Color.green);
			else if(hitInfo.transform.GetComponent<ObjectBehavior>().trait_Sharp)
				highlight.ConstantOn(Color.white);
			else
				highlight.ConstantOn(Color.yellow);
			highlight.SeeThroughOff();
			
			//check to see if the object is touching the player collider
			bool objectTouchingPlayer = hitInfo.transform.GetComponent<Collider>().bounds.Contains(GetComponent<Collider>().ClosestPointOnBounds(hitInfo.transform.position));
			if(objectTouchingPlayer)
			{
				// Turn off highlighting if object is touching the player
				highlight.Off();
			}
			
			return (!objectTouchingPlayer);
		}
		
		if(lastHit != null)
		{
			// Turn off highlighter of last hit object that is no longer being hit
			Highlighter lastHighlight = lastHit.GetComponent<Highlighter>();
			lastHighlight.Off();
		}
		
		return false;
	}
	
	//  Interact with the Interactable Object Immediately Before the Player
	public void interactWithObject()
	{
		Vector3 rayOrigin = transform.position;
		Vector3 rayDir = transform.forward;
		float rayDist = PCSettings.staticRef.interactReach;
		RaycastHit hitInfo;
		
		// HARD CODED SHARP TAG INTO LIMITS. REMOVE AND MAKE BETTER.
		if (heldObj != null) 
		{ 
			if(!heldObj.GetComponent<ObjectBehavior>().trait_Sharp)
			{
				dropObject(); return; 
			}
			else
			{	
				if (Physics.Raycast(rayOrigin, rayDir, out hitInfo, rayDist, PCSettings.staticRef.interactableObjectsLM))
				{
					// Special Interact
					if(hitInfo.transform.GetComponent<ObjectBehavior>().trait_SpecialInteraction)
					{
						hitInfo.transform.GetComponent<InteractableObject>().specialInteract(heldObj);
					}
				}else
				{
					dropObject(); return;
				}
			}
			
			
		}
		if (!objInRange || interacting || cdTimer_Interact > 0) 
		{
			return;
		}
		
		if (Physics.Raycast(rayOrigin, rayDir, out hitInfo, rayDist, PCSettings.staticRef.interactableObjectsLM))
		{
			// Special Interact
			if(hitInfo.transform.GetComponent<ObjectBehavior>().trait_SpecialInteraction)
			{
				hitInfo.transform.GetComponent<InteractableObject>().specialInteract(heldObj);
			}
			
			//  Hold-Interact
			if (hitInfo.transform.GetComponent<ObjectBehavior>().trait_Holdable)
			{
				heldObj = hitInfo.transform.gameObject;
				heldObj.GetComponent<Rigidbody>().useGravity = false;
				heldObj.layer = LayerMask.NameToLayer("Default");
				
				objInRange = !(interacting = true);
				heldDist = Vector3.Distance(transform.position, heldObj.transform.position);
				
				cdTimer_Interact = PCSettings.staticRef.interactCD;
			}
		}
	}
	
	//  Use the Blast Ability
	public void blastAbility()
	{
		if (cdTimer_Blast > 0) return;
		dropObject();
		createBlastWave();
		
		// Turn off last hit highlighting
		if(lastHit != null)
			lastHit.GetComponent<Highlighter>().Off();
		
		//  Apply Cool Downs
		cdTimer_Blast = PCSettings.staticRef.blastCD;
		cdTimer_Interact = PCSettings.staticRef.interactCD;
	}
	
	//  Apply a Force Vector to All Objects in the Blast's Path
	void createBlastWave()
	{
		//  Applies a forward force to all objects in a forward cone.
		
		//  RayCast Variables for a SphereCastAll and Detecting which Objects are in the Cone
		Vector3 rayOrigin = transform.position, rayDir = transform.forward;
		float coneAngle = PCSettings.staticRef.blastAngle;
		//  Bell-Curve Cone
		float rayRadius = PCSettings.staticRef.blastLength;
		/*  Flat-Bottom Cone
        float coneHeight = PlayerSettings.staticRef.blastLength, coneBaseRadius = coneHeight * Mathf.Tan(coneAngle * Mathf.Deg2Rad);
        Vector2 r = new Vector2(coneHeight, coneBaseRadius);
        float rayRadius = r.magnitude;
        */
		
		// Find the blast sound and play it
		AudioSource[] sounds = GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<AudioSource>();
		foreach(AudioSource sound in sounds)
		{
			if(sound.clip.name == "Foley_Action_Ghost_Interaction_Blast")
			{
				sound.Play();
				break;
			}
		}
		
		RaycastHit[] hits = Physics.SphereCastAll(rayOrigin, rayRadius, rayDir, rayRadius, PCSettings.staticRef.interactableObjectsLM);
		foreach(RaycastHit hitInfo in hits)
		{
			if(hitInfo.transform.GetComponent<ObjectBehavior>().trait_Holdable)
			{
				float angle = Vector3.Angle(rayDir, rayOrigin - hitInfo.transform.position);
				float dist = Vector3.Distance(rayOrigin, hitInfo.transform.position);
				if (angle < 180 - coneAngle || angle > 180 + coneAngle || dist > PCSettings.staticRef.blastLength) continue; //  continue if object is not within the specified cone's bounds
				
				float forceMult = Mathf.Pow(1 - dist / PCSettings.staticRef.blastLength, PCSettings.staticRef.blastDecay);  //  exponentially scale the force's power according to distance
				Vector3 forceV = forceMult * PCSettings.staticRef.blastForce * Vector3.Normalize(hitInfo.transform.position - transform.position);
				hitInfo.transform.GetComponent<Rigidbody>().AddForce(forceV);
				//  print(hitInfo.transform.name + "\t" + angle + "deg" + "\tDist: " + dist + "m" + "\tMaxRange: " + coneHeight + "m\t" + forceMult);
			}
			
			// Do any action caused by a blast
			hitInfo.transform.GetComponent<InteractableObject>().blastInteract();
		}
	}
	
	//  Drop the Held Object
	void dropObject()
	{
		if (heldObj == null) return;    //  return if not holding an object
		
		heldObj.GetComponent<Rigidbody>().velocity = new Vector3();
		heldObj.GetComponent<Rigidbody>().useGravity = true;
		
		heldObj.layer = LayerMask.NameToLayer("Items_Interactable");
		
		heldObj = null;
		
		interacting = false;
	}
	
	//  Manage the Held Object
	void manageHeldObject()
	{
		// Turn off highlighting
		heldObj.GetComponent<Highlighter>().Off();
		
		//  Break Interaction if Object is Too Far Away
		Vector3 restPoint = transform.position + heldDist * transform.forward;
		float objDistToRestPoint = Vector3.Distance(heldObj.transform.position, restPoint);
		float distFactor = objDistToRestPoint / PCSettings.staticRef.breakHoldDist;
		if (distFactor > 1)
		{
			dropObject();
			return;
		}
		
		//  Move Object to Resting Point
		float objectVelocity = heldObj.GetComponent<ObjectSettings>().heldSpeed;
		
		Vector3 trajectory = restPoint - heldObj.transform.position;
		Vector3 velocity = Mathf.Sqrt(distFactor) * objectVelocity * Vector3.Normalize(trajectory);
		//  To Prevent Jittering, Stop Object if it Could Reach the Point by Next Frame
		if (velocity.magnitude < objectVelocity * Time.deltaTime)
		{
			heldObj.GetComponent<Rigidbody>().velocity = new Vector3();
			return;
		}
		//  Update Velocity to Match Current Trajectory
		heldObj.GetComponent<Rigidbody>().velocity = velocity;
	}
}