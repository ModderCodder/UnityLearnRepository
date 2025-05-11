using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] slots;
    public GameObject invPrefab;
    // Start is called before the first frame update

    public void AddItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            InventorySlot slot = slots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item==item && itemInSlot.count<item.MaxStack && item.stackble)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return;
            }

        }

        for (int i=0; i < slots.Length; i++)
        {
            InventorySlot slot = slots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnItem(item, slot);
                return;
            }

        }
    }
    public void RemoveItem(Item item, InventoryItem inv)
    {

        //for (inv != null && inv.item == item)
        //{
         //   inv.count--;

        //}if (inv.count <= 0)
        //{
          //  Destroy(inv.gameObject);
        //}
        //else
        //{

          //  inv.RefreshCount();
        
       
    }
    void SpawnItem(Item item,InventorySlot slot)
    {
        GameObject newItem = Instantiate(invPrefab, slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitItem(item);
    }
}
