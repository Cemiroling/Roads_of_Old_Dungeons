using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScenePresenter : MonoBehaviour
{
    private Item item;

    private SpriteRenderer spriteRenderer;
    private Inventory inventory;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void CreateItemOnScene(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventory.GiveItem(this.item);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }


}
