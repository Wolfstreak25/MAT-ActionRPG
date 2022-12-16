using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] private GameObject InventoryPannel;
    public PlayerController player;
    //public Sprite Icon;
    public List<Slots_UI> slots = new List<Slots_UI>();
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
            Setup();
        }
    }
    public void ToggleInventory()
    {
        if(!InventoryPannel.activeSelf)
        {
            InventoryPannel.SetActive(true);
        }else
        {
            InventoryPannel.SetActive(false);
        }
    }
    void Setup()
    {
        Debug.Log("Inventory_UI Setup called");
        Debug.Log("UI slots = " + slots.Count + "Player inventory slots = " + player.inventory.slots.Count);
        if(slots.Count == player.inventory.slots.Count)
        {
            
            for(int i= 0; i< slots.Count; i++)
            {
                if(player.inventory.slots[i].type != CollectibleType.none)
                {
                    Debug.Log("setup>>forloop>>if_statement>>true");
                    slots[i].SetItem(player.inventory.slots[i]);
                }else{
                    Debug.Log("setup>>forloop>>if_statement>>false");
                    slots[i].SetEmpty();
                }
            }
        }
    }
}
