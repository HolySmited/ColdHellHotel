using UnityEngine;
using System.Collections;

public class LevelTips : MonoBehaviour
{
    [SerializeField]
    GameObject tip_CheckKitchen, tip_KnifeChandelier, tip_LightsOff, tip_ScareFrankie;
    GameObject activeTip = null;
    public const int tipID_CheckKitchen = 0, tipID_KnifeChandelier = 1, tipID_LightsOff = 2, tipID_ScareFrankie = 3;
    const int tipCount = 4;
    
    float tipFrequency_CheckKitchen = 10, tipFrequency_KnifeChandelier = 10, tipFrequency_LightsOff = 10, tipFrequency_ScareFrankie = 10;
    [SerializeField]
    float tipTimer, tipTimeDisplayed = 0, activeFrequency = 0;
    float displayPeriod = 5;

    void Update()
    {
        if (activeTip != null)
        {
            if ((tipTimer += Time.deltaTime) > activeFrequency)
                displayTip();
            if (activeTip.activeSelf && (tipTimeDisplayed += Time.deltaTime) > displayPeriod)
                hideTip();
        }

        if (parseInput)
            foo();
    }
    void OnDisable()
    {
        setAble_Tip(-1);
    }

    public int idInput = -1;
    public bool parseInput = false;
    void foo()
    {
        setAble_Tip(idInput);
        parseInput = false;
    }

    void displayTip()
    {
        tipTimer = 0;
        activeTip.SetActive(true);
    }
    void hideTip()
    {
        tipTimeDisplayed = 0;
        if (activeTip != null)
            activeTip.SetActive(false);
    }

    public bool setAble_Tip(int tipID)
    {
        resetTips();
        if (tipID >= tipCount)
            return false;

        switch (tipID)
        {
            case tipID_CheckKitchen:
                activeTip = tip_CheckKitchen;
                activeFrequency = tipFrequency_CheckKitchen;
                break;
            case tipID_KnifeChandelier:
                activeTip = tip_KnifeChandelier;
                activeFrequency = tipFrequency_KnifeChandelier;
                break;
            case tipID_LightsOff:
                activeTip = tip_LightsOff;
                activeFrequency = tipFrequency_LightsOff;
                break;
            case tipID_ScareFrankie:
                activeTip = tip_ScareFrankie;
                activeFrequency = tipFrequency_ScareFrankie;
                break;
            default:
                activeTip = null;
                activeFrequency = Mathf.Infinity;
                break;
        }

        return true;
    }


    public void resetTips()
    {
        hideTip();
        activeFrequency = 0;
    }
}