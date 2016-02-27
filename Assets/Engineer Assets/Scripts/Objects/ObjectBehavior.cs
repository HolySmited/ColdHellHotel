/*  Script: ObjectBehavior.cs
    Author: Zackary Hoyt

    Description:
    Contains traits which detail an object's behavior with the world and the player.

    *** TRAITS_SIZE must be <= 25 else the customized editor will throw an error
        due to its inability to handle more than 25 lines.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ObjectSettings))]
[RequireComponent(typeof(InteractableObject))]

public class ObjectBehavior : MonoBehaviour
{
    public const int TRAITS_SIZE = 25;  //  Very Important That This is Accurrate!!!
    //  traitNames can be static as the names of the traits won't vary
    public static string[] traitNames = new string[TRAITS_SIZE] { "Light", "Medium", "Heavy", "Fragile", "Hard",
        "Severable", "Sharp", "Broken", "Flammable", "Flame", "Soakable", "Soaked", "Liquid", "Absorbant", "Electrical",
        "Powered", "Power Source", "Noisy", "Special Interaction", "Holdable", "Movable", "Perishable",
    "Flammable Liquid", "Flammable Soaked", "Permanent Fire/Water"};
    [SerializeField]
    bool[] traits = new bool[TRAITS_SIZE];

    ObjectSettings oSettings;
    void Start() { oSettings = GetComponent<ObjectSettings>(); }

    void FixedUpdate()
    {
        if (oSettings.catchingFire) oSettings.timer_CatchFire -= Time.deltaTime;
        if (oSettings.soaking) oSettings.timer_Soaking -= Time.deltaTime;
    }

    //  Mass
    public bool trait_Light     { get { return traits[0]; } set { traits[0] = value; } }
    public bool trait_Medium    { get { return traits[1]; } set { traits[1] = value; } }
    public bool trait_Heavy     { get { return traits[2]; } set { traits[2] = value; } }
    //  Physical State
    public bool trait_Fragile   { get { return traits[3]; } set { traits[3] = value; } }
    public bool trait_Hard      { get { return traits[4]; } set { traits[4] = value; } }
    public bool trait_Severable { get { return traits[5]; } set { traits[5] = value; } }
    public bool trait_Sharp     { get { return traits[6]; } set { traits[6] = value; } }
    public bool trait_Broken    { get { return traits[7]; } set { traits[7] = value; } }
    //  Fire-ish
    public bool trait_Flammable { get { return traits[8]; } set { traits[8] = value; } }
    public bool trait_Flame     { get { return traits[9]; } set { traits[9] = value; } }
    //  Water-ish
    public bool trait_Soakable  { get { return traits[10]; } set { traits[11] = value; } }
    public bool trait_Soaked    { get { return traits[11]; } set { traits[12] = value; } }
    public bool trait_Liquid    { get { return traits[12]; } set { traits[12] = value; } }
    public bool trait_Absorbant { get { return traits[13]; } set { traits[13] = value; } }
    //  Electricity
    public bool trait_Electrical    { get { return traits[14]; } set { traits[14] = value; } }
    public bool trait_Powered       { get { return traits[15]; } set { traits[15] = value; } }
    public bool trait_PowerSource   { get { return traits[16]; } set { traits[16] = value; } }
    //  Noise
    public bool trait_Noisy { get { return traits[17]; } set { traits[16] = value; } }
    //  Interactions
    public bool trait_SpecialInteraction 	{ get { return traits[18]; } set { traits[18] = value; } }
    public bool trait_Holdable      		{ get { return traits[19]; } set { traits[19] = value; } }
    public bool trait_Blastable     		{ get { return traits[20]; } set { traits[20] = value; } }
    //  Other
    public bool trait_Perishable { get { return traits[21]; } set { traits[21] = value; } }
    //  Fire/Water
    public bool trait_FlammableLiquid { get { return traits[22]; } set { traits[22] = value; } }
    public bool trait_FlammableSoaked { get { return traits[23]; } set { traits[23] = value; } }
    public bool trait_PermanentFireOrWater { get { return traits[24]; } set { traits[24] = value; } }
}
