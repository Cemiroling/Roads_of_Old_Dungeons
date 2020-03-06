using UnityEngine;

public class MusicLoaderAndController : MonoBehaviour
{

    private AudioClip[] audioClips;
    private bool prefMusic;
    private bool musicStop;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        prefMusic = Settings.MusicOn;
        if (Settings.MusicOn)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
        Resources resources = new Resources();
        audioClips =  Resources.LoadAll<AudioClip>("GameMusic");
        Debug.Log("Кол-во песен " + audioClips.Length);
    }

    void Update()
    {
        if (Settings.MusicOn)
        {
            audioSource.volume = Settings.MusicLevel;
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length - 1)]);
            }
        }
        else
        {
            audioSource.Stop();
        }

    }
}
