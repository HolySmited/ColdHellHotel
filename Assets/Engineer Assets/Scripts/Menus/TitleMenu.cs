/*  Author: Zackary Hoyt
    Scripts: TitleMenu.cs
    Description: 
        Menu for the title screen.
        Options:
            Level Intro
            Exit Game
    Last Modified: February 22nd
*/

using UnityEngine;
using System;
using System.Text;
using System.Collections;

public class TitleMenu : MonoBehaviour {

    string inputString = "";
    float inputTimer = 0;

    MenuSounds menusounds;

    void Start()
    {
        menusounds = transform.parent.GetComponent<MenuSounds>();
        menusounds.PlayLoop_Background_Title();
    }

    void Update()
    {
        updateTextField();
    }

    #region Text Field
    void updateTextField()
    {
        if (Input.GetKey(KeyCode.Backspace))
            if (inputString.Length > 0 && (Time.time - inputTimer > 0.1f || Input.GetKeyDown(KeyCode.Backspace)))
            {
                inputString = inputString.Remove(inputString.Length - 1);
                inputTimer = Time.time;
            }
            else;
        else if (Input.GetKeyDown(KeyCode.Escape))
            inputString = "";
        else
            try
            {
                if (Input.GetKeyDown(KeyCode.Return))
                    parseInputString();
                else if ((Time.time - inputTimer > 0.5f || Input.anyKeyDown) && Input.inputString[0] > 32 && inputString.Length <= 32)
                {
                    inputString += Input.inputString;
                    inputTimer = Time.time;
                }
            }
            catch (System.IndexOutOfRangeException e) { }
    }
    void parseInputString()
    {
        if (GetBits(inputString.ToLower()) == "1101010110100111001111100111110110011001011110011")
            FindObjectOfType<LevelLoader>().loadTestLevel();
        inputString = "";
    }
    public string GetBits(string input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in Encoding.ASCII.GetBytes(input))
            sb.Append(Convert.ToString(b, 2));
        return sb.ToString();
    }

    void OnGUI()
    {
        //if (inputString.Length > 0)
        //GUI.Label(new Rect(Screen.width / 8, Screen.height / 8, 400, 50), "> " + inputString);
    }
    #endregion

    public void titelmenu_StartGame()
    {
        menusounds.PlayOneShot_Click();
        FindObjectOfType<LevelLoader>().loadMainLevelIntro();
    }
    public void titlemenu_Exit()
    {
        menusounds.PlayOneShot_Click();
        Application.Quit();
    }
}