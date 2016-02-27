/*  Author: Zackary Hoyt
    Scripts: LevelLoader.cs
    Description: 
        Designed to consolidate all level loading to increase 
        the ease of which changes can be made to the scene build 
        settings and scene names.
        Also used to update settings depending on level being loaded.
    Last Modified: February 23rd
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{
    static LevelLoader _LevelLoader;

    int scene_GameStart = 0, scene_LoadingScreen = 1, scene_TitleScreen = 2, scene_TestLevel = 3, scene_MainLevelIntro = 4, scene_MainLevel = 5;
    GameObject LoadingScreen, LoadingScreen_ProgressText;
    public GameObject menu_Title, menu_Level, menu_LevelIntro;

    public string currentLevel;

    MenuSounds menusounds;

    void Start()
    {
        if (_LevelLoader != null)
        {
            print("Two Level Loaders Generated");
            GameObject.Destroy(this);
            return;
        }
        GameObject.DontDestroyOnLoad(this);
        _LevelLoader = this;

        PCSettings.staticRef.canControlPlayer = false;

        menusounds = GameObject.FindObjectOfType<MenuSounds>();

        lockCursor();

        LoadingScreen = transform.FindChild("LoadingScreen").gameObject;
        LoadingScreen_ProgressText = LoadingScreen.transform.FindChild("ProgressText").gameObject;
        LoadingScreen.SetActive(false);

        loadTitleScreen();
    }

    void Update()
    {
        currentLevel = Application.loadedLevelName;
    }

    void reloadGame() { Application.LoadLevel(scene_GameStart); }
    void loadLoadingScreen() { Application.LoadLevel(scene_LoadingScreen); }

    public void loadTitleScreen()
    {
        StartCoroutine(LoadLevel_wLS(scene_TitleScreen, false));
        disableMenus();
        menu_Title.SetActive(true);
        unlockCursor();
    }
    public void loadTestLevel()
    {
        StartCoroutine(LoadLevel_wLS(scene_TestLevel));
        disableMenus();
        menu_Level.SetActive(true);
        lockCursor();
    }
    public void loadMainLevelIntro()
    {
        StartCoroutine(LoadLevel_wLS(scene_MainLevelIntro, false));
        disableMenus();
        menu_LevelIntro.SetActive(true);
        unlockCursor();
    }
    public void loadMainLevel()
    {
        StartCoroutine(LoadLevel_wLS(scene_MainLevel));
        disableMenus();
        menu_Level.SetActive(true);
        lockCursor();
        PCSettings.staticRef.canControlPlayer = true;
    }

    void LoadLevel(int levelID)
    {
        //  Simple Level Loader
        Application.LoadLevel(levelID);
    }
    IEnumerator LoadLevel_wLS(int levelID, bool showProgressText = true)
    {
        PCSettings.staticRef.canControlPlayer = false;
        //  Display a level loading screen while asynchronously loading the target level.
        loadLoadingScreen();    //  Load an empty scene.
        LoadingScreen.SetActive(true);
        LoadingScreen_ProgressText.SetActive(showProgressText);

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

            //  Update the Progress Display
            LoadingScreen_ProgressText.GetComponent<Text>().text = ((int)(progress * 100)).ToString() + "%";

            yield return null;
        }

        if (levelID == scene_TestLevel || levelID == scene_MainLevel)
            menusounds.StopPlayingAudio();
        else if (levelID == scene_TitleScreen)
            menusounds.PlayLoop_Background_Title();
            

        LoadingScreen_ProgressText.SetActive(false);
        LoadingScreen.SetActive(false);
    }

    void unlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void lockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void disableMenus()
    {
        menu_Title.SetActive(false);
        menu_LevelIntro.SetActive(false);
        menu_Level.SetActive(false);
    }
}