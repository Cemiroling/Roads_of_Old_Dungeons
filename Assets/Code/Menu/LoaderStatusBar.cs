using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderStatusBar : MonoBehaviour
{
    [SerializeField] private Image statusBar;

    public Text text;

    void Start()
    {   
       StartCoroutine(LoadAsynk("Game"));           
    }


    IEnumerator LoadAsynk(string name)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);
        float i = 0.5f;
        while (!asyncLoad.isDone)
        {
            i+=0.1f;
            statusBar.gameObject.transform.localScale= new Vector2(asyncLoad.progress,1);
            text.text = LoadStatus.MessageInfo;
            Debug.Log(asyncLoad.progress);
            yield return null;
        }
    }
}
