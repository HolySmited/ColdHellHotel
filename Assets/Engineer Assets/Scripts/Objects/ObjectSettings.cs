/*  Script: ObjectSettings.cs
    Author: Zackary Hoyt

    Description:
    Contains and manages the settings which define various object-related activities.
    E.g., movement speeds, max hold time, etc.

    This component is dependent on a text file, from which it reads a list of at least
    all the holdable items to be in the game.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ObjectSettings : MonoBehaviour
{
    //  Class Designed to Link an Object-Type to a Specific Hold-Time
    public class Item
    {
        string itemName;
        float holdTime = 0;

        public Item(string newItemName, float maxHoldTime)
        {
            itemName = newItemName;
            holdTime = maxHoldTime;
        }
        public string getItemName() { return itemName; }
        public float getMaxHoldTIme() { return holdTime; }
    };

    //  Held Variables
    public float heldSpeed = 5f, maxHoldTime = 0, defaultHoldTime = Mathf.Infinity;

    //  Min-Dist to Break When Falling
    public float fallBreakDist = 10f;

    //  Trait Timer Variables
    public bool catchingFire = false, soaking = false;
    public float timer_CatchFire = 0f, timer_Soaking = 0f, timer_Absorb = 0;
    public float time_OnFire = 0, time_Soaked = 0;

    //  Debug Vars Used to Manually Check a Specified Item's Hold Time
    [SerializeField]
    string itemName;
    [SerializeField]
    bool getHoldTime = false;
    [SerializeField]
    float holdTime = 0;

    void FixedUpdate()
    {
        //  Update Debug Vars
        if (getHoldTime)
        {
            getHoldTime = false;
            holdTime = (getItemHoldTime(itemName));
        }
    }

    //  List of at least all the holdable items 
    static List<Item> items = null;
    //  Address of the txt file containing the raw input for the items list
    const string itemStats_TxtFN = "TextFiles/itemStats.txt";
    void Awake()
    {
        //  Parse a text file (once) to determine every object's relative max-holding-time.
        if (items == null)
        {
            items = new List<Item>();
            StreamReader textReader = new StreamReader(itemStats_TxtFN);
            while (!textReader.EndOfStream)
            {
                string[] tokenizedLine = textReader.ReadLine().Split('\t');

                string itemName = tokenizedLine[0].ToLower();
                float holdTime = Mathf.Infinity;
                items.Insert(items.Count, new Item(itemName, holdTime));
            }
        }
    }
    void Start()
    {
        maxHoldTime = getItemHoldTime();
    }

    //  Getting a Specified Item's Hold Time
    float getItemHoldTime(string itemName = "\0")
    {
        if (itemName == "\0")
            itemName = this.name;
        try
        {
            return (items.Find(x => x.getItemName() == itemName.ToLower())).getMaxHoldTIme();
        }
        catch (System.NullReferenceException)
        {
            return defaultHoldTime;
        }
    }
}