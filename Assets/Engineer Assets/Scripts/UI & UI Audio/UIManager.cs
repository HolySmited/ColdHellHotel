using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(UISounds))]
[RequireComponent(typeof(TitleUI))]
[RequireComponent(typeof(GameEndUI))]
[RequireComponent(typeof(GameHintsUI))]
[RequireComponent(typeof(GameMenuUI))]
[RequireComponent(typeof(LoadingScreenUI))]

public class UIManager : MonoBehaviour
{
    #region Properties
    static UIManager uiManager;

    [HideInInspector]
    public UISounds uiSounds;
    [HideInInspector]
    public TitleUI titleUI;
    [HideInInspector]
    public GameMenuUI gameMenuUI;
    [HideInInspector]
    public GameHintsUI gameHintsUI;
    [HideInInspector]
    public GameEndUI gameEndUI;
    [HideInInspector]
    public LoadingScreenUI loadingScreenUI;
    [HideInInspector]
    public LevelManager levelManager;
    #endregion


    void Awake()
    {
        if (uiManager != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }

        uiManager = this;
        GameObject.DontDestroyOnLoad(this);

        uiSounds = GetComponent<UISounds>();
        titleUI = GetComponent<TitleUI>();
        gameMenuUI = GetComponent<GameMenuUI>();
        gameHintsUI = GetComponent<GameHintsUI>();
        gameEndUI = GetComponent<GameEndUI>();
        loadingScreenUI = GetComponent<LoadingScreenUI>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void initializeTitleUI()
    {
        titleUI.open();
        gameMenuUI.menuEnabled = false;
        unlockCursor();
    }
    public void initializeGameUI()
    {
        titleUI.close();
        gameMenuUI.menuEnabled = true;
        lockCursor();
    }

    public void closeAll()
    {
        titleUI.close();
        //  gameMenuUI.Close(); //  Closes by default
        gameHintsUI.deactivateHint();
        loadingScreenUI.close();
    }

    static public void pause()
    {
        Time.timeScale = 0;
    }
    static public void unpause()
    {
        Time.timeScale = 1;
    }

    static public void unlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    static public void lockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
