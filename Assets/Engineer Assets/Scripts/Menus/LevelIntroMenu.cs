/*  Author: Zackary Hoyt
    Scripts: LevelIntro.cs
    Description: 
        Menu for the level intro screen.
        Options:
            Info Slides
            Main Level
            Menu
    Last Modified: February 22nd
*/

using UnityEngine;
using System.Collections;

public class LevelIntroMenu : MonoBehaviour
{
    const int menuID_Narrative = 1, menuID_Controls = 2;
    public int menuID = 0;
    [SerializeField]
    GameObject menu_Narrative, menu_Controls;
    MenuSounds menusounds;

    void Start()
    {
        menusounds = transform.parent.GetComponent<MenuSounds>();

        menu_Narrative.SetActive(false);
        menu_Controls.SetActive(false);

        menuID = 1;
        updateMenu();
    }

    void updateMenu()
    {
        menu_Narrative.SetActive(false);
        menu_Controls.SetActive(false);
        switch (menuID)
        {
            case 0:
                FindObjectOfType<LevelLoader>().loadTitleScreen();
                break;
            case 1:
                enable_NarrativeMenu();
                break;
            case 2:
                enable_ControlMenu();
                break;
            default:
                menuID = menuID_Narrative;
                enable_NarrativeMenu();
                GameObject.FindObjectOfType<PlayerController>().transform.position = PCSettings.staticRef.spawnpoint;
                FindObjectOfType<LevelLoader>().loadMainLevel();
                break;
        }
    }

    void enable_ControlMenu()
    {
        menu_Narrative.SetActive(true);
        menu_Controls.SetActive(false);
    }
    void enable_NarrativeMenu()
    {
        menu_Narrative.SetActive(false);
        menu_Controls.SetActive(true);
    }

    public void back()
    {
        menusounds.PlayOneShot_Click();
        menuID--;
        updateMenu();
    }
    public void next()
    {
        menusounds.PlayOneShot_Click();
        menuID++;
        updateMenu();
    }
}
