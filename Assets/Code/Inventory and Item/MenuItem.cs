using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuItem : MonoBehaviour, IPointerExitHandler
{
    public Equipment equipment;
    private UIItem uItem;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ActiveMenu(float x, float y, UIItem uIItem)
    {
        this.uItem = uIItem;
        gameObject.transform.position = new Vector2(x, y);
    }

    public void UseItem()
    {
        if(uItem.item.itemType == ItemType.Gear)
        {
            equipment.EquipItem(uItem);
        }
        gameObject.SetActive(false);
    }

    public void DropItem()
    {
        uItem.DropItem();
        gameObject.SetActive(false);
    }



    public void OnPointerExit(PointerEventData eventData)
    {
        uItem = null;
        gameObject.SetActive(false);
    }
}
