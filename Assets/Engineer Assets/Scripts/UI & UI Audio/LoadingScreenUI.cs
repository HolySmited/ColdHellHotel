using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreenUI : MonoBehaviour
{
    [SerializeField]
    Image uiLoadingScreen, backdrop;

    #region In-Game Debugging
    [SerializeField]
    bool debugFadeIn, debugFadeOut;
    void debugUpdate()
    {
        if (debugFadeIn)
        {
            open_Fade();
            debugFadeIn = false;
        }
        else if (debugFadeOut)
        {
            close_Fade();
            debugFadeOut = false;
        }
    }
    #endregion

    void Start()
    {
        close();
    }
    void FixedUpdate()
    {
        debugUpdate();
    }

    #region Display Methods
    public void open()
    {
        uiLoadingScreen.gameObject.SetActive(true);
    }
    public void open_Fade()
    {
        StartCoroutine(fadeIn());
    }
    public void close()
    {
        uiLoadingScreen.gameObject.SetActive(false);
        backdrop.gameObject.SetActive(false);
    }
    public void close_Fade()
    {
        StartCoroutine(fadeOut());
    }
    #endregion

    #region Fades
    bool fadingIn = false, fadingOut = false;
    IEnumerator fadeIn()
    {
        backdrop.gameObject.SetActive(true);
        float startTime = Time.time, fadePeriod = 0.5f;
        fadingOut = true;
        fadingIn = false;

        uiLoadingScreen.gameObject.SetActive(true);
        Color color = uiLoadingScreen.color;

        do
        {
            color.a = (Time.time - startTime) / fadePeriod;
            uiLoadingScreen.color = color;
            yield return null;
        } while (uiLoadingScreen.color.a < 1 && fadingOut);

        backdrop.gameObject.SetActive(false);
    }
    IEnumerator fadeOut()
    {
        float startTime = Time.time, fadePeriod = 1f;
        fadingIn = true;
        fadingOut = false;

        uiLoadingScreen.gameObject.SetActive(true);
        Color color = uiLoadingScreen.color;

        do
        {
            color.a = 1 - (Time.time - startTime) / fadePeriod;
            uiLoadingScreen.color = color;
            yield return null;
        } while (uiLoadingScreen.color.a > 0 && fadingIn);
    }
    #endregion
}
