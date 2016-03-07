using UnityEngine;
using System.Collections;

class LevelManagerDebug : MonoBehaviour {

    [SerializeField]
    string levelName = "";
    [SerializeField]
    int currentLevelID = -1, levelID = 0;
    [SerializeField]
    bool loadLevel = false;
    
    void Update()
    {
        levelName = Application.loadedLevelName;
        currentLevelID = Application.loadedLevel;

        if (loadLevel)
        {
            StartCoroutine(GetComponent<LevelManager>().loadLevel(levelID));
            loadLevel = false;
        }
    }
}
