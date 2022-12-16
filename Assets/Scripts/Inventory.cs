using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class InventorySlot
    {
        public CollectibleType type;
        public int count;
        public int maxAllowed;
        public Sprite Icon;
        public InventorySlot()
        {
            type = CollectibleType.none;
            count = 0;
            maxAllowed = 9;
        }
        public bool CanAddItem()
        {
            if(count < maxAllowed)
            {
                return(true);
            }else{
                return false;
            }   
        }
        public void AddItem(EnemyCollectible Item)
        {
            Debug.Log("AddItem called");
            this.type = Item.type;
            this.Icon = Item.Icon;
            count++;
        }
    }
    public List<InventorySlot> slots = new List<InventorySlot>();
    public Inventory(int NumSlot)
    {
        for(int i = 0; i < NumSlot; i++)
        {
            InventorySlot slot = new InventorySlot();
            slots.Add(slot);
        }
    }
    public void Add(EnemyCollectible Item)
    {
        Debug.Log(" Inventory Add called");
        foreach (InventorySlot slot in slots)
        {
            if(slot.type == Item.type && slot.CanAddItem())
            {
                slot.AddItem(Item);
                return;
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if(slot.type == CollectibleType.none)
            {
                slot.AddItem(Item);
                return;
            }
        }
    }
}
