using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    [Header("Текстовое поле для подсказки")]
    [SerializeField] private Text tooltip;
    


    public void GenerateTooltip(string text)
    {
        tooltip.text = text;
        gameObject.SetActive(true);
    }

    public void DeleteTooltip()
    {
        gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        Canvas.ForceUpdateCanvases();
      //  textTooltip.text = text;
    }

}
