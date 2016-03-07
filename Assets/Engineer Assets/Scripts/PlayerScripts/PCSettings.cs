/*  Script: PCSettings.cs
    Author: Zackary Hoyt

    Description:
    Contains and manages the settings which define various player-related activities.
    E.g., movement speeds, mouse-sensitivity, etc.
*/

using UnityEngine;
using System.Collections;

public class PCSettings : MonoBehaviour
{
    public static PCSettings staticRef;
    void Awake()
    {
        if (staticRef == null)
            staticRef = this;
        initializeAbilityEnergy();
    }

    //  Player Collider Layer
    public LayerMask ignoredCollisionsLM = 16128; //  used to set what the player can/cannot collide with
    //  Renderer Layer
    public LayerMask fadingObjectsLM = 6144;
    //  Interaction Layer
    public LayerMask interactableObjectsLM = 2048; //  used to filter-out non-interactable objects for raycasting

    public Vector3 spawnPoint = new Vector3(24, 1, 10);
    public Quaternion spawnRotation = new Quaternion();
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
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Level"), !value);
        }
    }


    //  Mouse Look Settings
    public Vector2 lookSensitivity = new Vector2(2, 2);
    public float yRotationLimit = 80;

    #region Abilities
    public class AbilityEnergy
    {
        #region Properties
        MonoBehaviour m;

        int _level = 0;

        float[] energyMaxes = { 10, 20, 30, 40, 50 };
        float _energy = 0, _energyRegen = 0.5f, _energyInUse = 0;

        bool _regenerating = false;
        #endregion

        public AbilityEnergy(MonoBehaviour _m) { _energy = energyMax; m = _m; regenerating = true; }

        public int level(int levelup = 0) { return (_level = Mathf.Clamp(_level + levelup, 0, 99)); }

        public float energyMax { get { return energyMaxes[_level]; } }
        public float energyMaxWLimit { get { return energyMaxes[_level] - energyInUse; } }

        public float energy { get { return _energy; } }
        public float energyRegen { get { return _energyRegen; } }
        public float energyInUse { get { return _energyInUse; } }

        public float plusminusEnergy(float expending)
        {
            return (_energy = Mathf.Clamp(energy - expending, 0, energyMaxWLimit));
        }
        public float reduceEnergyMax(float reduction)
        {
            reduction = Mathf.Abs(reduction);
            if (energy < reduction || energyInUse + reduction > energyMaxWLimit)
                return -1;
            _energyInUse += reduction;
            plusminusEnergy(reduction);
            return energyMaxWLimit;
        }
        public float restoreEnergyMax(float accretion)
        {
            accretion = -Mathf.Abs(accretion);
            if (energyInUse - accretion < 0)
                return -1;
            _energyInUse -= accretion;
            return energyMaxWLimit;
        }

        bool regenerating { get { return _regenerating; } set { if ((_regenerating = value)) m.StartCoroutine(regen()); } }
        IEnumerator regen()
        {
            while (regenerating)
            {
                plusminusEnergy(-(Time.deltaTime * energyRegen));
                yield return new WaitForEndOfFrame();
            }
        }
    }
    AbilityEnergy _abilityEnergy;
    public AbilityEnergy abilityEnergy { get { return _abilityEnergy; } }
    void initializeAbilityEnergy()
    {
        _abilityEnergy = new AbilityEnergy(this);
    }
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 4, Screen.height / 4, 100, 50), "Energy: " + abilityEnergy.energy.ToString());
    }

    //  Interact Settings
    public float interactReach = 5,
                 interactCD = 1f,
                 breakHoldDist = 3f;

    //  Blast Settings
    public float blastForce = 800,
                 blastLength = 8,
                 blastAngle = 30,
                 blastCD = 1f,
                 blastDecay = 0.4f,
                 blastCost = 5;
    #endregion

    //  Object Fade Settings
    public float dist_a1 = 2;

    public void reset()
    {
        transform.position = spawnPoint;
        transform.rotation = spawnRotation;

        walkMode = false;
    }
}