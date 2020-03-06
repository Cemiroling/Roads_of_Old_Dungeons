using UnityEngine;
using UnityEngine.UI;


public class ChooseButton : MonoBehaviour
{
    public Text label;

    public Toggle toggle;

    public bool isMusic;

    public Slider slider;

    private bool isEnable;

    private void Start()
    {
        if (isMusic)
        {
            toggle.isOn=Settings.MusicOn;
            isEnable = Settings.MusicOn;
            slider.value = Settings.MusicLevel;
        }
        else
        {
            slider.value = Settings.SoundLevel;
            toggle.isOn = Settings.SoundOn;
            isEnable = Settings.SoundOn;
        }
        if (isEnable)
            label.text = "ВКЛ";
        else
            label.text = "ВЫКЛ";
    }
    public void DisableEnableSound()
    {
        if (Settings.SoundOn)
        {
            label.text = "ВЫКЛ";
            Settings.SoundOn = false;
        }
        else
        {
            label.text = "ВКЛ";
            Settings.SoundOn = true;
        }
    }

    public void DisableEnableMusic()
    {
        if (Settings.MusicOn)
        {
            label.text = "ВЫКЛ";
            Settings.MusicOn = false;
        }
        else
        {
            label.text = "ВКЛ";
            Settings.MusicOn = true;
        }
    }

    public void SetLevelMusic() 
    {
        Settings.MusicLevel = slider.value;
    }
    public void SetLevelSound()
    {
        Settings.SoundLevel = slider.value;
    }
   
}

