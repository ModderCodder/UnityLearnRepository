using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
     PlayerStats PlayerStats;
     MoveScript MoveScript;
     public Item Item;

    InventoryManager InventoryManager;
    
    void Start()
    {
        PlayerStats = FindObjectOfType<PlayerStats>();
        MoveScript = FindObjectOfType<MoveScript>();
        InventoryManager = FindObjectOfType<InventoryManager>();
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetItem();
            Destroy(gameObject);
        }
    }

    void GetItem()
    {
        switch (Item.ItemType)
        {
            case ItemType.KEY:
                PlayerStats.Keys += Item.value;
                break;
            case ItemType.COIN:
                PlayerStats.Coins += Item.value;
                break;
            case ItemType.HEALS:
                //MoveScript.GetHeal(Item.value);
                InventoryManager.AddItem(Item);
                break;
        }
    }
    public void UseItem(Item item, InventoryItem inv)
    {

        switch (item.ItemType)
        {

            case ItemType.KEY:
                PlayerStats.Keys += Item.value;
                break;
            case ItemType.COIN:
                PlayerStats.Coins += Item.value;
                break;
            case ItemType.HEALS:
                if (PlayerStats.Hp < 100)
                {
                    InventoryManager.RemoveItem(Item, inv);
                    
                }
                break;

        }
    }
}
