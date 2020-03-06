using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        if (Settings.MusicOn)
        {           
            musicSource.Play();
        }
        else
        {
            musicSource.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Settings.MusicOn)
        {
            musicSource.volume = Settings.MusicLevel;
            if(!musicSource.isPlaying)
                musicSource.Play();     
        }
        else
        {
            musicSource.Stop();
        }
    }
}
