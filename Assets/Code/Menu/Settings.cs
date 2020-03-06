using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Settings
{
    
    private static int width;
    private static int height;

    private static bool musicOn = true;
    private static bool soundOn = true;


    private static float musicLevel = 1;
    private static float soundLevel = 1;

    public static int Height { get => height; set => height = value; }
    public static int Width { get => width; set => width = value; }
    public static bool MusicOn { get => musicOn; set => musicOn = value; }
    public static bool SoundOn { get => soundOn; set => soundOn = value; }
    public static float MusicLevel { get => musicLevel; set => musicLevel = value; }
    public static float SoundLevel { get => soundLevel; set => soundLevel = value; }
}
    
