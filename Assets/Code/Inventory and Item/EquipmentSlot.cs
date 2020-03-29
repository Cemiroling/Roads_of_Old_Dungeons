using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour/*, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler*/
{
    public GearMainType gearMainType;
    public UIItem uIItem;
    private UIItem script;
     


    private void Awake()
    {
        script = uIItem.gameObject.GetComponent<UIItem>();
    }
/*    public void OnPointerClick(PointerEventData eventData)
    {
        if (uIItem.selectedItemName != null)
        {
            if (gearMainType == uIItem.SelectedItem.item.gearMainType)
            {
                uIItem.OnPointerClick(eventData);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(uIItem.SelectedItem.item.gearMainType != this.gearMainType)
        {
            script.gameObject.SetActive(false);
        }
    }  
    
    public void OnPointerExit(PointerEventData eventData)
    {
        script.gameObject.SetActive(false);
    }*/
    
    
}
