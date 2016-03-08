/*  Script: PlayerController.cs
    Author: Zackary Hoyt

    Description:
    Controls the player's components:
        - movement
        - mouse-looking
        - object-fading
        - abilities

    Parses the LayerMask in the Settings for Ignoring Collisions,
    and applies those settings.
*/

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PCSettings))]
[RequireComponent(typeof(PCMovement))]
[RequireComponent(typeof(PCAbilities))]

[RequireComponent(typeof(MouseLook))]
[RequireComponent(typeof(ObjectFader))]

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class PCController : MonoBehaviour
{
#pragma warning disable 0414    //  disable unused variable warning messages
    //  Debug Variables
    [SerializeField]
    Vector3 velocity;
    [SerializeField]
    float velocityMagnitude;
#pragma warning restore 0414    //  restore unused variable warning messages

    //  Cached Component References
    PCMovement pMovement;
    MouseLook mouseLook;
    Rigidbody rbody;

    void Start()
    {
        //  Cache Components
        pMovement = GetComponent<PCMovement>();
        mouseLook = GetComponent<MouseLook>();
        rbody = GetComponent<Rigidbody>();

        setCustomPCColliderSettings();
    }
    
    void FixedUpdate()
    {
        //  Update Debug Variables
        velocity = rbody.velocity;
        velocityMagnitude = velocity.magnitude;
    }
    void Update()
    {
        if (PCSettings.staticRef.canControlPlayer)
            playerControlInput();
    }

    void setCustomPCColliderSettings()
    {
        //  Ignore Collision from Everything Marked in the IgnoreCollisionLayerMask
        int playerLayer = LayerMask.NameToLayer("Player");
        uint bitstring = (uint)PCSettings.staticRef.ignoredCollisionsLM.value;
        for (int i = 31; bitstring > 0; i--)
            if ((bitstring >> i) > 0)
            {
                bitstring = ((bitstring << 32 - i) >> 32 - i);
                Physics.IgnoreLayerCollision(playerLayer, i);
                if (i <= 0) break;
            }
    }

    //  Handles Input for Player Control
    void playerControlInput()
    {
        //  Mouse Look
        float mouseDeltaX = Input.GetAxis("Mouse X"), mouseDeltaY = Input.GetAxis("Mouse Y");
        mouseLook.mouseLook(mouseDeltaX, mouseDeltaY);

        //  Forward & Back
        if (Input.GetAxis("Horizontal Z") > 0)
            if (Input.GetAxis("Horizontal Z") < 0)
                pMovement.moveForwards(0);
            else
                pMovement.moveForwards(1);
        else if (Input.GetAxis("Horizontal Z") < 0)
            pMovement.moveForwards(-1);
        else
            pMovement.moveForwards(0);

        //  Right & Left
        if (Input.GetAxis("Horizontal X") > 0)
            if (Input.GetAxis("Horizontal X") < 0)
                pMovement.moveRightwards(0);
            else
                pMovement.moveRightwards(1);
        else if (Input.GetAxis("Horizontal X") < 0)
            pMovement.moveRightwards(-1);
        else
            pMovement.moveRightwards(0);

        //  Up & Down
        if (Input.GetAxis("Vertical") > 0)
            if (Input.GetAxis("Vertical") < 0)
                pMovement.moveUpwards(0);
            else
                pMovement.moveUpwards(1);
        else if (Input.GetAxis("Vertical") < 0)
            pMovement.moveUpwards(-1);
        else
            pMovement.moveUpwards(0);

        //  Interacting/Abilities
        if (Input.GetKeyDown(KeyCode.Mouse0))
            GetComponent<PCAbilities>().interactWithObject();
        if (Input.GetAxis("Blast") > 0)
            GetComponent<PCAbilities>().blastAbility();

        //  Altitude Soft-Locking
        if (Input.GetKeyDown(KeyCode.F))
            PCSettings.staticRef.walkMode = !PCSettings.staticRef.walkMode;
    }
}
