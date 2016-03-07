using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDUI : MonoBehaviour
{
    [SerializeField]
    Texture reticle;
    Vector2 screenMid = new Vector2();

    void Start()
    {
        screenMid = new Vector2(Screen.width / 2, Screen.height / 2);
        GUI.color = Color.blue;
    }
    void OnGUI()
    {
        if (canDraw())
            GUI.DrawTexture(new Rect(screenMid.x + reticle.width / 4, screenMid.y + reticle.height / 4, reticle.width / 4, reticle.height / 4), reticle);
    }

    public bool hudEnabled = true;
    bool canDraw()
    {
        return hudEnabled && (Application.loadedLevel == LevelManager.sceneID_TestLevel || Application.loadedLevel == LevelManager.sceneID_MainLevel) && Time.timeScale != 0;
    }
}