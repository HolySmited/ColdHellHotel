/*  Author: Zackary Hoyt
    Scripts: GameStart.cs
    Description:
        Run once at the beginning of the game to 
        instantiate core game objects and game
        settings.
    Last Modified: February 22nd
*/

using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    GameObject LevelLoader_Prefab = null;

    void Start()
    {
        //  Level Loader
        GameObject.Instantiate(LevelLoader_Prefab);
    }
}