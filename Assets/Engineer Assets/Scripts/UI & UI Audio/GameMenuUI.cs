using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameMenuUI : MonoBehaviour {

    #region Properties
    [SerializeField]
    Sprite screen_MenuMain, screen_MenuGameExit, screen_MenuControlInfo, screen_MenuSettings;
    Sprite activeImage;

    [SerializeField]
    Image uiMenu;

    [SerializeField]
    Button button_Back, button_Settings, button_ControlInfo, button_GameExit, button_ConfirmExit, button_DontExit, button_Back1;
    public const int menuID_Close = -1, menuID_Main = 0, menuID_Settings = 1, menuID_ControlInfo = 2, menuID_ConfirmExit = 3;
    [SerializeField]
    Stack<int> menuIDHistory = new Stack<int>();

    UISounds uiSounds;

    [SerializeField]
    bool _enabled = false;
    public bool menuEnabled { get { return _enabled; } set { if (!(_enabled = value)) { close(); } } }
    #endregion
    
    void Start()
    {
        uiSounds = GetComponent<UISounds>();
        menuEnabled = false;
    }
    void Update()
    {
        inputPoll();
    }
    void inputPoll()
    {
        if (menuEnabled && PCSettings.staticRef != null && Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuIDHistory.Peek() == menuID_Close)
                open();
            else
                close();
        }
    }


    #region Display Methods
    public void open()
    {
        close();    //  Ensure Menu is Reset

        UIManager.pause();
        UIManager.unlockCursor();
        PCSettings.staticRef.canControlPlayer = false;

        menuIDHistory.Push(menuID_Main);
        setActive();
    }
    public void close()
    {
        UIManager.unpause();
        UIManager.lockCursor();

        if (PCSettings.staticRef != null)
            PCSettings.staticRef.canControlPlayer = true;

        menuIDHistory.Clear();
        menuIDHistory.Push(menuID_Close);
        uiMenu.gameObject.SetActive(false);
        disableButtons();
    }
    #endregion

    #region Buttons
    public void Button_Back()
    {
        Debug.Log("Back Button: Count - " + menuIDHistory.Count);
        uiSounds.oneshot_Click();
        menuIDHistory.Pop();
        setActive();
        Debug.Log("Back Button: Count - " + menuIDHistory.Count);
    }
    public void Button_Settings()
    {
        uiSounds.oneshot_Click();
        menuIDHistory.Push(menuID_Settings);
        setActive();
    }
    public void Button_ControlInfo()
    {
        uiSounds.oneshot_Click();
        menuIDHistory.Push(menuID_ControlInfo);
        setActive();
    }
    public void Button_GameExit()
    {
        uiSounds.oneshot_Click();
        menuIDHistory.Push(menuID_ConfirmExit);
        setActive();
    }
    public void Button_ConfirmExit()
    {
        uiSounds.oneshot_Click();
        close();
        GetComponent<UIManager>().levelManager.loadTitle();
    }
    public void Button_DontExit()
    {
        Button_Back();
    }
    #endregion
    #region Utilities
    void setActive()
    {
        Debug.Log("Setting menu " + menuIDHistory.Peek() + " active.");
        switch(menuIDHistory.Peek())
        {
            case menuID_Main:
                activeImage = screen_MenuMain;
                enableButtons_Menu();
                break;
            case menuID_Settings:
                activeImage = screen_MenuSettings;
                enableButtons_Settings();
                break;
            case menuID_ControlInfo:
                activeImage = screen_MenuControlInfo;
                enableButtons_ControlInfo();
                break;
            case menuID_ConfirmExit:
                activeImage = screen_MenuGameExit;
                enableButtons_ConfirmExit();
                break;
            default:
                close();
                print("Default Game Menu Case");
                return;
        }
        displayCurrent();
    }
    void displayCurrent()
    {
        uiMenu.sprite = activeImage;
        uiMenu.gameObject.SetActive(true);
    }

    void enableButtons_Menu()
    {
        disableButtons();
        button_Back.gameObject.SetActive(true);
        button_Settings.gameObject.SetActive(true);
        button_ControlInfo.gameObject.SetActive(true);
        button_GameExit.gameObject.SetActive(true);
    }
    void enableButtons_Settings()
    {
        disableButtons();
        button_Back.gameObject.SetActive(true);
    }
    void enableButtons_ControlInfo()
    {
        disableButtons();
        button_Back1.gameObject.SetActive(true);
    }
    void enableButtons_ConfirmExit()
    {
        disableButtons();
        button_ConfirmExit.gameObject.SetActive(true);
        button_DontExit.gameObject.SetActive(true);
    }
    void disableButtons()
    {
        button_Back.gameObject.SetActive(false);
        button_Settings.gameObject.SetActive(false);
        button_ControlInfo.gameObject.SetActive(false);
        button_GameExit.gameObject.SetActive(false);
        button_ConfirmExit.gameObject.SetActive(false);
        button_DontExit.gameObject.SetActive(false);
        button_Back1.gameObject.SetActive(false);

    }
    #endregion
}
