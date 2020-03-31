using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltipForInventory : MonoBehaviour, IPointerUpHandler, IPointerEnterHandler
{
    private Text tooltipText;

    private bool isMouseOnMe = false;

    public bool IsMouseOnMe { get => isMouseOnMe; set => isMouseOnMe = value; }

    void Start()
    {
        tooltipText = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    public void GenerateToolTip(Item item)
    {
        string statText = "";
        if (item.atributes.Count > 0)
        {
            foreach(var stat in item.atributes)
            {
                statText += Enum.GetName(typeof(TypeOfAtribute),stat.atribute) + ": " + stat.value.ToString() + "\n";
            }
        }
        string tooltip = string.Format("<b>{0}</b>\n{1}\n\n<b>{2}</b>\n<b>{3}</b>",
            item.title, item.description, statText,Enum.GetName(typeof(Rarity), item.rarity));
        tooltipText.text = tooltip;
        gameObject.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IsMouseOnMe == false)
            IsMouseOnMe = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (IsMouseOnMe == false)
            IsMouseOnMe = true;
    }
}
