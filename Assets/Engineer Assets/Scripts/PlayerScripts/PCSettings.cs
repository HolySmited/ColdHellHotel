/*  Script: PCSettings.cs
    Author: Zackary Hoyt

    Description:
    Contains and manages the settings which define various player-related activities.
    E.g., movement speeds, mouse-sensitivity, etc.

    Contains additional cursor-functionality, allowing the displaying/hiding of the cursor.
    Toggable with F1.
*/

using UnityEngine;
using System.Collections;

public class PCSettings : MonoBehaviour
{
    public static PCSettings staticRef;
    void Awake() {if(staticRef == null) staticRef = this; }

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

    void Update()
    {
        //  Cursor Visibility
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (Cursor.lockState != CursorLockMode.None)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = (CursorLockMode.Locked != Cursor.lockState);
        }
    }

    //  Player Collider Layer
    public LayerMask ignoredCollisionsLM = 16128; //  used to set what the player can/cannot collide with
    //  Renderer Layer
    public LayerMask fadingObjectsLM = 6144;
    //  Interaction Layer
    public LayerMask interactableObjectsLM = 2048; //  used to filter-out non-interactable objects for raycasting

    //  Player Controller Settings
    public bool canControlPlayer = true;
    //  Player Movement Settings
    public float speed = 5f,
                 accel = 25f;
    public bool instantDirChange = true;   //  instantly move in a new direction, or slow to a stop first
    bool _altitudeSoftLock = false; //  left/right and for/back movement cannot be translated into vertical movement
    public bool walkMode
    {
        get {
            return _altitudeSoftLock;
        }
        set {
            _altitudeSoftLock = GetComponent<Rigidbody>().useGravity = value;
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Level"), false);
        }
    }


    //  Mouse Look Settings
    public Vector2 lookSensitivity = new Vector2(2, 2);
    public float yRotationLimit = 80;

    //  Interact Settings
    public float interactReach = 5,
                 interactCD = 1f,
                 breakHoldDist = 3f;

    //  Blast Settings
    public float blastForce = 800,
                 blastLength = 8,
                 blastAngle = 30,
                 blastCD = 1f,
                 blastDecay = 0.4f;

    //  Rendering Settings
    public float dist_a1 = 2;
}