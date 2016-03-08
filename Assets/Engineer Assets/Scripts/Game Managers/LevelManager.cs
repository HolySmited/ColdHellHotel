using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LevelManager : MonoBehaviour
{
    #region Properties
    public const int sceneID_GameStart = 0, sceneID_LoadingScreen = 1, sceneID_TitleScreen = 2, sceneID_TestLevel = 3, sceneID_MainLevel = 5;

    public static LevelManager levelManager;

    [SerializeField]
    GameObject playerUI;
    #endregion

    void Awake()
    {
        if (levelManager != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        GameObject.DontDestroyOnLoad(this);
        levelManager = this;
    }
    void Start()
    {
        loadTitle();
    }

    #region Utilities
    public static void reload()
    {
        Debug.Log("Reloading Current Level");
        Application.LoadLevel(Application.loadedLevel);
    }
    public static void restart()
    {
        Debug.Log("Restarting Game");
        Application.LoadLevel(sceneID_GameStart);
    }
    public static void exit()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
    public void switchLevelUIs(int levelID)
    {
        playerUI.GetComponent<UIManager>().closeAll();
        switch (levelID)
        {
            case sceneID_TestLevel:
            case sceneID_MainLevel:
                playerUI.GetComponent<UIManager>().initializeGameUI();
                break;
            case sceneID_TitleScreen:
                playerUI.GetComponent<UIManager>().initializeTitleUI();
                break;
            default:
                //  playerUI.GetComponent<UIManager>().CloseAll();
                break;
        }
    }
    #endregion

    #region Scene Loading Methods
    public void loadTitle()
    {
        StartCoroutine(loadLevel(sceneID_TitleScreen));
    }
    public void loadLevel_Test()
    {
        playerUI.GetComponent<TitleUI>().hideScreen();
        StartCoroutine(loadLevel(sceneID_TestLevel, true));
    }
    public void loadLevel_Main()
    {
        playerUI.GetComponent<TitleUI>().hideScreen();
        StartCoroutine(loadLevel(sceneID_MainLevel, true));
    }
    #endregion

    //  Primary Level Loader
    int asyncLevelLoadCount = 0;
    public IEnumerator loadLevel(int levelID, bool useLS = false)
    {
        Application.LoadLevel(sceneID_LoadingScreen);    //  Load an empty scene.

        //  Activate Loading Screen
        if (useLS)
        {
            playerUI.GetComponent<LoadingScreenUI>().open_Fade();
            yield return new WaitForSeconds(1);
        }

        Debug.Log("Loading Level ID: " + levelID);
        asyncLevelLoadCount++;
        if (asyncLevelLoadCount > 1)
            Debug.Log("WARNING: Consecutive Async Scene Loadings!");

        //  Variables to track level loading progress (progress history preserves the last two progress checks).
        decimal progressAverage = 0;
        Queue<decimal> progressHistory = new Queue<decimal>();
        progressHistory.Enqueue(0);
        progressHistory.Enqueue(0);
        int progressTrackCount = progressHistory.Count;

        yield return null;
        AsyncOperation async = Application.LoadLevelAsync(levelID);

        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            //  Get the Load Progress %
            decimal progress = (decimal)async.progress;

            //  If the progress is equal to the average, then chances are the scene is nearly finished loading so it is okay to switch to it.
            async.allowSceneActivation = progress == progressAverage;
            progressHistory.Enqueue(progress);
            progressAverage += ((progress - progressHistory.Dequeue()) / progressTrackCount);
            yield return null;
        }
        asyncLevelLoadCount--;
        
        //  Close Loading Screen
        if (useLS)
        {
            playerUI.GetComponent<LoadingScreenUI>().close_Fade();
            yield return new WaitForSeconds(1);
        }

        //  Enable Level-Dependent GUIs
        switchLevelUIs(levelID);
    }

}
