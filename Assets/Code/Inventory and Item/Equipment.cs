using System;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public List<EquipmentSlot> equipmentSlots = new List<EquipmentSlot>();

    public event Action Equipmting;
    public event Action UnEquipmting;

    public EquipmentSlot EquipmentSlot { get; set; }


    private EquipmentSlot CheckUIItem(Item item)
    {
        return equipmentSlots.Find(i => i.gearMainType == item.gearMainType);
    }

    private void Start()
    {
        foreach (EquipmentSlot slot in equipmentSlots)
        {
            slot.SwapingItem += () => Swaping(slot);
            slot.UnSwapingItem += () => UnSwaping(slot);
        }
    }

    private void UnSwaping(EquipmentSlot equipmentSlot)
    {
        EquipmentSlot = equipmentSlot;
        UnEquipmting?.Invoke();
    }
    private void Swaping(EquipmentSlot equipmentSlot)
    {
        EquipmentSlot = equipmentSlot;
        Equipmting?.Invoke(); 
    }

    public void EquipItem(UIItem equipItem)
    {
        EquipmentSlot slot = CheckUIItem(equipItem.item);
        Debug.Log("fdsf");

        if (slot.item == null)
        {
            slot.UpdateItem(equipItem.item);
            equipItem.UpdateItem(null);
        }
        else
        {
            UnSwaping(slot);
            Item clone =(Item) ScriptableObject.CreateInstance(typeof(Item));
            clone.Clone(slot.item);
            slot.UpdateItem(equipItem.item);
            equipItem.UpdateItem(clone);
        }
        Swaping(slot);
    }



}
