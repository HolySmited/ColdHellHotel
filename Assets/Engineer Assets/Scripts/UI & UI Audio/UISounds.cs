using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(AudioSource))]

public class UISounds : MonoBehaviour
{
    [SerializeField]
    AudioClip menuBackground, clickSound, scrollSound;
    static AudioSource audiosource;

    void Awake()
    {
        //  Cache Components at Awake so Sound can be Played @ Start
        audiosource = GetComponent<AudioSource>();
    }

    #region Predefined Audio OneShots
    public void oneshot_Click()
    {
        audiosource.PlayOneShot(clickSound);
    }
    public void oneshot_Scroll()
    {
        audiosource.PlayOneShot(clickSound);
    }
    #endregion
    #region Predefined Audio Loops
    public void loopMenuBackground()
    {
        stopFading = true;
        audiosource.loop = true;
        audiosource.clip = menuBackground;
        audiosource.Play();
    }
    #endregion

    #region Play Audio Methods
    public void oneshot(AudioClip clip)
    {
        audiosource.PlayOneShot(clip);
    }
    public void audioclip(AudioClip clip, bool loop = false)
    {
        stopFading = true;
        audiosource.loop = loop;
        audiosource.clip = clip;
        audiosource.Play();
    }
    #endregion

    #region Audio Source Utility
    public void loop(bool b)
    {
        audiosource.loop = b;
    }
    public static void stop()
    {
        audiosource.Stop();
    }

    public static bool stopFading = false, fading = false;
    public static IEnumerator fadeout()
    {
        while (fading) yield return null;
        fading = true;  //  checkout function
        float startTime = Time.time, fadePeriod = 5f, volume = audiosource.volume;
        while ((audiosource.volume = 1 - (Time.unscaledTime - startTime) / fadePeriod) > 0 && !stopFading) yield return null;
        if (!stopFading) stop();  //  If the fade out was canceled, don't stop the audio.
        stopFading = false;
        fading = false; //  checkin function
        audiosource.volume = volume;
    }
    #endregion
}
