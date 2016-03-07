using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHintsUI : MonoBehaviour
{
    #region Properties
    [SerializeField]
    Sprite hint_CheckKitchen, hint_KnifeChandelier, hint_TurnOffLights, hint_ScareFrankie;
    Sprite activeHint;

    [SerializeField]
    Image uiHint;

    public const int hintID_DISABLE = -1, hintID_CheckKitchen = 0, hintID_KnifeChandelier = 1, hintID_TurnLightsOff = 2, hintID_ScareFrankie = 3;
    [SerializeField]
    int currentHintID = -1;

    [SerializeField]
    float displayPeriod = 5f;
    [SerializeField]
    float displayTimer = 0;
    
    float displayFrequence_CheckKitchen = 10, displayFrequency_KnifeChandelier = 10, displayFrequency_TurnLightsOff = 0, displayFrequency_ScareFrankie = 10;
    [SerializeField]
    float frequencyTimer = 0, activeFrequency = 0;
    #endregion
    
    #region In-Game Debugging
    [SerializeField]
    int debugHintID = -1;
    [SerializeField]
    bool debugShowHint, debugHideHint;
    void debugUpdate()
    {
        if (debugShowHint)
        {
            setActiveHint(debugHintID);
            debugShowHint = false;
        }
        else if (debugHideHint)
        {
            setActiveHint(hintID_DISABLE);
            debugHideHint = false;
        }
    }
    #endregion

    void Start()
    {
        hideHint();
    }
    void FixedUpdate()
    {
        debugUpdate();
        if (currentHintID != hintID_DISABLE)
            hintDisplayUpdate();
    }

    #region Display Methods
    public void deactivateHint() { setActiveHint(hintID_DISABLE); }
    public void activateHint_CheckKitchen(bool immediateDisplay = false) { setActiveHint(hintID_CheckKitchen, immediateDisplay); }
    public void activateHint_KnifeChandelier(bool immediateDisplay = false) { setActiveHint(hintID_KnifeChandelier, immediateDisplay); }
    public void activateHint_TurnLightsOff(bool immediateDisplay = false) { setActiveHint(hintID_TurnLightsOff, immediateDisplay); }
    public void activateHint_ScareFrankie(bool immediateDisplay = false) { setActiveHint(hintID_ScareFrankie, immediateDisplay); }
    #endregion

    #region Utilities
    public void setActiveHint(int hintID, bool immediateDisplay = false)
    {
        frequencyTimer = 0;
        displayTimer = 0;
        switch(hintID)
        {
            case hintID_CheckKitchen:
                activeHint = hint_CheckKitchen;
                currentHintID = hintID_CheckKitchen;
                activeFrequency = displayFrequence_CheckKitchen;
                break;
            case hintID_KnifeChandelier:
                activeHint = hint_KnifeChandelier;
                currentHintID = hintID_KnifeChandelier;
                activeFrequency = displayFrequency_KnifeChandelier;
                break;
            case hintID_TurnLightsOff:
                activeHint = hint_TurnOffLights;
                currentHintID = hintID_TurnLightsOff;
                activeFrequency = displayFrequency_TurnLightsOff;
                break;
            case hintID_ScareFrankie:
                activeHint = hint_ScareFrankie;
                currentHintID = hintID_ScareFrankie;
                activeFrequency = displayFrequency_ScareFrankie;
                break;
            default:
                activeHint = null;
                currentHintID = hintID_DISABLE;
                activeFrequency = Mathf.Infinity;
                hideHint();
                return;
        }

        if (immediateDisplay)
            showHint();
        else
            hideHint();
    }
    void hintDisplayUpdate()
    {
        if (activeFrequency == 0)
        {
            showHint();
        }
        else
        {
            if (uiHint.gameObject.activeSelf && (displayTimer += Time.deltaTime) > displayPeriod)
                StartCoroutine(hideHint_Fade());
            if ((frequencyTimer += Time.deltaTime) > activeFrequency)
                StartCoroutine(showHint_Fade());
        }
    }
    void showHint()
    {
        uiHint.sprite = activeHint;
        uiHint.gameObject.SetActive(true);

        Color color = uiHint.color;
        color.a = 1;
        uiHint.color = color;

        frequencyTimer = 0;
    }
    void hideHint()
    {
        uiHint.gameObject.SetActive(false);
        displayTimer = 0;
    }
    IEnumerator showHint_Fade()
    {
        float startTime = Time.time, fadePeriod = 1f;

        showHint();
        Color color = uiHint.color;

        do
        {
            color.a = (Time.time - startTime) / fadePeriod;
            uiHint.color = color;
            yield return null;
        } while (uiHint.color.a < 1);
    }
    IEnumerator hideHint_Fade()
    {
        float startTime = Time.time, fadePeriod = 1f;
        
        Color color = uiHint.color;

        do
        {
            color.a = 1 - (Time.time - startTime) / fadePeriod;
            uiHint.color = color;
            yield return null;
        } while (uiHint.color.a > 0);

        hideHint();
    }
    #endregion
}
