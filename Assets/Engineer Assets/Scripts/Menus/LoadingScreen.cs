using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {
    GUITexture background;
    GUIText text;
    int loadProgress = 0;
    void Awake()
    {
        Object.DontDestroyOnLoad(this);
        (background = GetComponent<GUITexture>()).enabled = false;
        (text = GetComponent<GUIText>()).enabled = false;
    }
    public void loadLevel(string levelPath)
    {
        StartCoroutine(levelToLoad(levelPath));
    }

    IEnumerator levelToLoad(string levelPath)
    {
        background.enabled = true;
        text.enabled = true;

        text.text = "Loading Progress " + loadProgress + "%";
        
        AsyncOperation async = Application.LoadLevelAsync(levelPath);
        while (!async.isDone)
        {
            loadProgress = (int)(async.progress * 100);
            text.GetComponent<GUIText>().text = "Loading Progress " + loadProgress + "%";

            yield return null;
        }

        background.enabled = false;
        text.enabled = false;
    }
}
