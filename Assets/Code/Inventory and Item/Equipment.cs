using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public List<EquipmentSlot> uIItems = new List<EquipmentSlot>();




    private UIItem CheckUIItem(Item item)
    {
        return uIItems.Find(i => i.gearMainType == item.gearMainType).uIItem;
    }


    public void EquipItem(UIItem equipItem)
    {
        UIItem slot = CheckUIItem(equipItem.item);
        Debug.Log("fdsf");
        if (slot.item == null)
        {
            CheckUIItem(equipItem.item).UpdateItem(equipItem.item);
            equipItem.UpdateItem(null);
        }
        else
        {
            Item clone = new Item(slot.item);
            CheckUIItem(equipItem.item).UpdateItem(equipItem.item);
            equipItem.UpdateItem(clone);
        }
    }



}
