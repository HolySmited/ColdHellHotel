using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TitleMenu : MonoBehaviour {

    string inputString = "";
    void Update()
    {
        if (Input.anyKeyDown)
            if (Input.GetKeyDown(KeyCode.Return))
                parseInputString();
            else if (Input.GetKeyDown(KeyCode.Backspace) && inputString.Length > 0)
                inputString = inputString.Remove(inputString.Length - 1);
            else
                inputString += Input.inputString;
    }

    void parseInputString()
    {
        if (inputString.ToLower() == "engineering")
            FindObjectOfType<LoadingScreen>().loadLevel("TestLevel");
        inputString = "";
    }

    public void titelmenu_StartGame()
    {
        FindObjectOfType<LoadingScreen>().loadLevel("current");
    }
    public void titlemenu_Exit()
    {
        Application.Quit();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 8, Screen.height / 8, 200, 50), inputString);
    }
}