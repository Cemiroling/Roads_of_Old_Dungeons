using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Название окон, которые используются")]
    public string inventoryName = "Inventory";
    public string selectedItemName = "SelectedItem";
    public string tooltipName = "TooltipInventory";
    public string menuItemName = "Menu";




    public Item item;
    public ItemScenePresenter itemScenePresenter;
    private Image spriteImage;
    private UIItem selectedItem;
    private TooltipForInventory tooltip;
    private Inventory inventory;
    private MenuItem menuItem;

    public UIItem SelectedItem { get => selectedItem; }

    private void Awake()
    {
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
        selectedItem = GameObject.Find(selectedItemName).GetComponent<UIItem>();
        tooltip = GameObject.Find(tooltipName).GetComponent<TooltipForInventory>();
        inventory = GameObject.Find(inventoryName).GetComponent<Inventory>();
        menuItem = GameObject.Find(menuItemName).GetComponent<MenuItem>();
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.icon;
            spriteImage.preserveAspect = true;
        }
        else
        {
            spriteImage.color = Color.clear;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (this.item != null)
            {
                if (selectedItem.item != null)
                {
                    Item clone = new Item(selectedItem.item);
                    selectedItem.UpdateItem(this.item);
                    UpdateItem(clone);
                }
                else
                {
                    selectedItem.UpdateItem(this.item);
                    UpdateItem(null);
                }
            }
            else if (selectedItem.item != null)
            {
                UpdateItem(selectedItem.item);
                selectedItem.UpdateItem(null);
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right && this.item != null && selectedItem.item == null)
        {
            tooltip.gameObject.SetActive(false);
            menuItem.gameObject.SetActive(true);
            menuItem.ActiveMenu(transform.position.x, transform.position.y, this);
        }      
    }

    public void DropItem()
    {
        ItemScenePresenter itemScene = Instantiate<ItemScenePresenter>(itemScenePresenter, new Vector2(0, 0), new Quaternion());
        itemScene.CreateItemOnScene(this.item);
        inventory.RemoveItemByIndex(item);
        UpdateItem(null);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // if(!tooltip.IsMouseOnMe)
            tooltip.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.item != null)
        {
         //   tooltip.IsMouseOnMe = true;
            tooltip.GenerateToolTip(this.item);
        }
    }
}
