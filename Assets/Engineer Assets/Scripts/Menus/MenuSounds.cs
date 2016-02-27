using UnityEngine;
using System.Collections;

public class MenuSounds : MonoBehaviour {

    [SerializeField]
    AudioClip backgroundMusic, clickSound, scrollSound;
    AudioSource audiosource;

    void Start() { GameObject.DontDestroyOnLoad(this.gameObject); audiosource = GetComponent<AudioSource>(); }

    public void PlayOneShot_Click() { audiosource.PlayOneShot(clickSound); }
    public void PlayOneShot_Scroll() { audiosource.PlayOneShot(clickSound); }
    public void PlayLoop_Background_Title() { audiosource.loop = true; audiosource.clip = backgroundMusic; audiosource.Play(); }

    public void PlayOneShot_AudioClip(AudioClip clip) { audiosource.PlayOneShot(clip); }
    public void Play_AudioClip(AudioClip clip, bool loop = false) { audiosource.loop = loop; audiosource.clip = clip; audiosource.Play(); }

    public void AudioSource_Loop(bool b) { audiosource.loop = b; }
    public void StopPlayingAudio() { audiosource.Stop(); }
}
