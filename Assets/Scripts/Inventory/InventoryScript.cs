using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenInventory();
    }

    void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.B) && !image.activeSelf)
        
            image.SetActive(true);
        
        else if((Input.GetKeyDown(KeyCode.B) && image.activeSelf))
            image.SetActive(false);

    }
}
