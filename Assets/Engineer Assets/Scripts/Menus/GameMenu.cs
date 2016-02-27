/*  Author: Zackary Hoyt
    Scripts: GameMenu.cs
    Description: 
        Menu for the title screen.
        Options:
            Control Info
            Game/Control Settings (DISABLED)
            Main Menu
            Return to Game
    Last Modified: February 22nd
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    GameObject menu_Main, menu_Settings, menu_Controls, menu_Exit, menu_GameOver;

    Stack<int> menuIDStack = new Stack<int>();
    const int menuID_Open = 0, menuID_Main = 10, menuID_Settings = 20, menuID_Controls = 30, menuID_Exit = 40, menuID_GameOver = 50;

    MenuSounds menusounds;

    void Start()
    {
        menusounds = transform.parent.GetComponent<MenuSounds>();

        //  Make Sure All Menus are Deactivated
        menu_Main.SetActive(false);
        menu_Settings.SetActive(false);
        menu_Controls.SetActive(false);
        menu_Exit.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (menuIDStack.Count == 0)
                menuIDStack.Push(menuID_Open);
            else
                closeMenu();

        if (menuIDStack.Count > 0)
            switch (menuIDStack.Peek())
            {
                case menuID_Open:
                    openMenu();
                    break;
                case menuID_Main:
                    if (!menu_Main.activeSelf)
                        openMainMenu();
                    break;
                case menuID_Settings:
                    if (!menu_Settings.activeSelf)
                        openSettingsMenu();
                    break;
                case menuID_Controls:
                    if (!menu_Controls.activeSelf)
                        openControlsMenu();
                    break;
                case menuID_Exit:
                    if (!menu_Exit.activeSelf)
                        openExitMenu();
                    break;
                case menuID_GameOver:
                    if (!menu_GameOver)
                        openGameOverScreen();
                    break;
                default:
                    if (menu_Main.activeSelf)
                        closeMenu();
                    break;
            }

    }

    #region Menu Managers

    #region Game Menu Open/Close
    void openMenu()
    {
        showCursor();
        PCSettings.staticRef.canControlPlayer = false;
        Time.timeScale = 0;

        menuIDStack.Clear();
        menuIDStack.Push(menuID_Main);
    }
    void closeMenu()
    {
        hideCursor();
        PCSettings.staticRef.canControlPlayer = true;
        Time.timeScale = 1;

        deactivateAllMenus();

        menuIDStack.Clear();
    }

    void showCursor() { Cursor.lockState = CursorLockMode.None; Cursor.visible = true; }
    void hideCursor() { Cursor.lockState = CursorLockMode.Confined; Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false; }
    #endregion

    #region Menus
    void openMainMenu()
    {
        menu_Main.SetActive(true);
        menu_Settings.SetActive(false);
        menu_Controls.SetActive(false);
        menu_Exit.SetActive(false);
    }
    void openSettingsMenu()
    {
        menu_Main.SetActive(false);
        menu_Settings.SetActive(true);
        menu_Controls.SetActive(false);
        menu_Exit.SetActive(false);
    }
    void openControlsMenu()
    {
        menu_Main.SetActive(false);
        menu_Settings.SetActive(false);
        menu_Controls.SetActive(true);
        menu_Exit.SetActive(false);
    }
    void openExitMenu()
    {
        menu_Main.SetActive(false);
        menu_Settings.SetActive(false);
        menu_Controls.SetActive(false);
        menu_Exit.SetActive(true);
    }
    void openGameOverScreen()
    {
        deactivateAllMenus();
        menu_GameOver.SetActive(true);
    }
    #endregion

    #region Menu Options
    public void openMenu_Main() { menusounds.PlayOneShot_Click(); menuIDStack.Push(menuID_Main); }
    public void openMenu_Settings() { menusounds.PlayOneShot_Click(); menuIDStack.Push(menuID_Settings); }
    public void openMenu_Controls() { menusounds.PlayOneShot_Click(); menuIDStack.Push(menuID_Controls); }
    public void openMenu_Exit() { menusounds.PlayOneShot_Click(); menuIDStack.Push(menuID_Exit); }
    public void back()
    {
        menusounds.PlayOneShot_Click();
        //  I swear, this code isn't redundant. I know you enable the GO whenever you go to that menu, and diable everything else, but that doesn't work without this.
        deactivateAllMenus();

        if (menuIDStack.Count > 0)
            menuIDStack.Pop();

        if (menuIDStack.Count == 0)
            closeMenu();
    }
    #endregion

    #region Game Returns
    public void returnToGame() { closeMenu(); }
    public void returnToTitle()
    {
        closeMenu();
        GameObject.FindObjectOfType<PlayerController>().transform.position = PCSettings.staticRef.spawnpoint;
        FindObjectOfType<LevelLoader>().loadTitleScreen();
    }
    #endregion

    void deactivateAllMenus()
    {
        menu_Main.SetActive(false);
        menu_Settings.SetActive(false);
        menu_Controls.SetActive(false);
        menu_Exit.SetActive(false);
        menu_GameOver.SetActive(false);
    }
    #endregion


}
