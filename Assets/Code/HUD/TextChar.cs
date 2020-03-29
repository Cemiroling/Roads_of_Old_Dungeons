using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TextChar : MonoBehaviour 
{
    public Tooltip tooltip;

    public void OnMouseExit()
    {
        tooltip.gameObject.SetActive(false);
        GUI.Label(new Rect(gameObject.transform.position,new Vector2( 100, 50)), GUI.tooltip);
    }
    public void OnGUI()
    {        
        //GUI.Button(new Rect(gameObject.transform.position,new Vector2( 100, 50)),new GUIContent( "sdsdfdsfdf", "jfhdfhjsdh"));
    }

    public void OnMouseEnter()
    {
        tooltip.gameObject.SetActive(true);
        Debug.Log("dsda");
    }
}
