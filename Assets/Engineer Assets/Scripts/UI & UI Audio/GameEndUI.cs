using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameEndUI : MonoBehaviour
{
    [SerializeField]
    Sprite screen_Win, screen_Lose;

    [SerializeField]
    Image uiScreen;

    [SerializeField]
    Button button_ExitToTitle, button_ReturnToGame;

    UISounds uiSounds;


    #region In-Game Debugging
    [SerializeField]
    bool debugWinScreen, debugLoseScreen;
    void debugUpdate()
    {
        if (debugWinScreen)
        {
            open_Win();
            debugWinScreen = false;
        }
        else if (debugLoseScreen)
        {
            open_Lose();
            debugLoseScreen = false;
        }
    }
    #endregion

    void Start()
    {
        uiSounds = GetComponent<UISounds>();
        close();
    }
    void FixedUpdate()
    {
        debugUpdate();
    }


    #region Display Methods
    public void open_Win()
    {
        uiScreen.sprite = screen_Win;
        uiScreen.gameObject.SetActive(true);
        enableButtons();
    }
    public void open_Lose()
    {
        uiScreen.sprite = screen_Lose;
        uiScreen.gameObject.SetActive(true);
        enableButtons();
    }
    public void close()
    {
        uiScreen.gameObject.SetActive(false);
        disableButtons();
    }
    #endregion

    #region Buttons
    public void Button_ReturnToGame()
    {
        uiSounds.oneshot_Click();
        close();
    }
    public void Button_ExitToTitle()
    {
        uiSounds.oneshot_Click();
        close();
    }
    #endregion
    #region Utilities
    void enableButtons()
    {
        button_ExitToTitle.gameObject.SetActive(true);
        //  button_ReturnToGame.gameObject.SetActive(true);
    }
    void disableButtons()
    {
        button_ExitToTitle.gameObject.SetActive(false);
        button_ReturnToGame.gameObject.SetActive(false);
    }
    #endregion
}
