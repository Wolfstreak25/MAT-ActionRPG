using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Slots_UI : MonoBehaviour
{
    public Image IconImage;
    public TextMeshProUGUI Quantity;

    public void SetItem(Inventory.InventorySlot slot) 
    {
        if(slot != null)
        {
            Debug.Log("SetItem called");
            IconImage.sprite = slot.Icon;
            IconImage.color = new Color(1,1,1,1);
            Quantity.text = slot.count.ToString();
        }
    }
    public void SetEmpty()
    {
        Debug.Log("SetEmpty called");
        IconImage.sprite = null;
        IconImage.color = new Color(1,1,1,0);
        Quantity.text = "";
    }

}
