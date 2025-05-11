using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class InventoryItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Item item;
    public TextMeshProUGUI text;

 
    [HideInInspector]
    public Image image;
    public int count = 1;
    public Transform parentEnd;
    public ItemScript itemScript;


    private void Start()
    {
        itemScript = FindAnyObjectByType<ItemScript>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentEnd = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentEnd);
    }

    public void InitItem(Item item)
    {
        this.item = item;
        image.sprite = item.image;
        RefreshCount();
    }

    public void RefreshCount()
    {
        text.text = count.ToString();

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject gm = eventData.pointerClick;
        InventoryItem inv = gm.GetComponent<InventoryItem>();
        itemScript.UseItem(item, inv);
    }

}
