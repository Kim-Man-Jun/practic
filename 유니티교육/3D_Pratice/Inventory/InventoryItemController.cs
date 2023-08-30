using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.Potion:
                GameObject.Find("Player").GetComponent<Player>().Hp += item.value;
                break;
            case Item.ItemType.Book:
                GameObject.Find("Player").GetComponent<Player>().Attack += item.value;
                break;
        }
    }
}
