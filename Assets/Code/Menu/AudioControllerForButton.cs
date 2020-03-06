using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerForButton : MonoBehaviour 
{
    [SerializeField] private AudioSource myFx;
    [SerializeField] private AudioClip clickAudio;
    [SerializeField] private AudioClip enterAudio;


    private void LevelOfSound()
    {
        myFx.volume = Settings.SoundLevel;
    }

    public void onMouseEnterPlay()
    {
        LevelOfSound();
        if (Settings.SoundOn)
            myFx.PlayOneShot(enterAudio);
    }

    public void onMouseClick()
    {
        LevelOfSound();
        if (Settings.SoundOn)
             myFx.PlayOneShot(clickAudio);
    }

}
