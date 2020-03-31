using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDataBase ItemDataBase;
    public UIInventory inventoryUI;
    public int sizeOfInventory=16;

    private void Start()
    {
        GiveItem(0);
        GiveItem(1);
        GiveItem(2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            GiveItem(0);
    }

    public void GiveItem(int id)
    {
        if (characterItems.Count < sizeOfInventory)
        {
            Item itemToAdd = ItemDataBase.GetItem(id);
            characterItems.Add(itemToAdd);
            inventoryUI.AddNewItem(itemToAdd);
            Debug.Log("Added item: " + itemToAdd.title);
        }
    }

    public void GiveItem(Item item)
    {
        if (characterItems.Count < sizeOfInventory)
        {
            characterItems.Add(item);
            inventoryUI.AddNewItem(item);
            Debug.Log("Added item: " + item.title);
        }
    }

    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    public Item CheckForItem(Item itemForCheck)
    {
        return characterItems.Find(item => item == itemForCheck);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);
            Debug.Log("Item removed: " + itemToRemove.title);
        }
    }
    public void RemoveItemByIndex(Item item)
    {
        Item itemToRemove = CheckForItem(item);
        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            Debug.Log("Item removed: " + itemToRemove.title);
        }
    }
}
