using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;

    public GameObject settingsMenu;

    void Awake()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf)
            {
               
                Time.timeScale = 0;
                pauseMenu.SetActive(true); 
                settingsMenu.SetActive(false);
                Cursor.visible = true;
            }
            else
            {
                pauseMenu.SetActive(false);
                settingsMenu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
            }
                
        }        
    }

    public void resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
    }

    public void exit(string OtherSceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(OtherSceneName);
    }

    public void SettingsEnable()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void SettingsDisable()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
}
