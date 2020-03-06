using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class Main : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;



    public Canvas settingsCanvas;

    public Canvas acceptCanvas;

    public Canvas startCanvas;


    public void Awake()
    {
        SetActiveForCanvas(false, false, true);
      
    }


    private void SetActiveForCanvas(bool settings, bool accept, bool start)
    {
        startCanvas.gameObject.SetActive(start);
        acceptCanvas.gameObject.SetActive(accept);
        settingsCanvas.gameObject.SetActive(settings);
    }
    


    public void PlayNewGame()
    {
        SetActiveForCanvas(false, true, false);
    }

    public void LoadGame()
    {
        StartCoroutine(LoadAsynk("LoadScene"));
        Cursor.visible = false;
    }


    public void NoAcceptNewGame()
    {
        StartCoroutine(Wait(false, false, true));
        
    }


    public void AcceptNewGame()
    {
        StartCoroutine(LoadAsynk("LoadScene"));
        Cursor.visible = false;
    }


    public void Exit()
    {
        Application.Quit();
    }

    public void SettingsMenu()
    {
        SetActiveForCanvas(true, false, false);
    }

    public void BackButton()
    {
        SetActiveForCanvas(false, false, true);
    }

  

    public void ChangeResovution(Text text)
    {
        string[] size = text.text.Split('x');
        Settings.Width = int.Parse(size[0]);
        Settings.Height = int.Parse(size[1]);

        Screen.SetResolution(Settings.Width, Settings.Height,true);
    }

    IEnumerator Wait(bool settings, bool accept, bool start)
    {
        yield return new WaitForSeconds(0.5f);
        SetActiveForCanvas(settings, accept, start);
    }

    IEnumerator LoadAsynk(string name)
    {
        yield return new WaitForSeconds(1.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
