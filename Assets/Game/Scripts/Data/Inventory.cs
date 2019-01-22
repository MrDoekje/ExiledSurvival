using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> PlayerInventory;

    public class returnInfo
    {
        public string itemDescription;
        public string itemName;
        public int itemId;
        public int itemMaxAmount;
        public int itemAmount;
        
        public returnInfo(string itemDescription, string itemName, int itemMaxAmount, int itemAmount, int itemId)
        {
            this.itemDescription = itemDescription;
            this.itemName = itemName;
            this.itemMaxAmount = itemMaxAmount;
            this.itemAmount = itemAmount;
            this.itemId = itemId;
        }
    }

    public class InventoryItem
    {
        private int itemAmount;
        //something to explain what item it is
        private int itemId;
        private int itemMaxAmount;
        private string itemDescription;
        private string itemName;

        public InventoryItem(string itemDescription, string itemName, int itemMaxAmount, int itemAmount, int itemId)
        {

        }

        public void fillToMax()
        {
            itemAmount = itemMaxAmount;
        }

        public bool changefItem(int howMany)
        {
            if (itemAmount - howMany <= 0) { itemAmount -= howMany; return true; }
            return false;
        }


        public returnInfo getInfo => new returnInfo(itemDescription, itemName, itemMaxAmount, itemAmount, itemId);
    }

    public Inventory()
    {
        PlayerInventory = new List<InventoryItem>();
    }

    public void changeItem(string itemDescription, string itemName, int itemMaxAmount, int itemAmount, int itemId)
    {
        bool isInInventory = false;
        foreach (InventoryItem inventoryitem in PlayerInventory)
            if (inventoryitem.getInfo.itemId == itemId)
                isInInventory = true;
        if (isInInventory)
            foreach (InventoryItem inventoryitem in PlayerInventory)
                if (inventoryitem.getInfo.itemId == itemId)
                    if (inventoryitem.changefItem(itemAmount))
                        return;
                    else
                    {
                        inventoryitem.fillToMax();
                        PlayerInventory.Add(new InventoryItem(itemDescription, itemName, itemMaxAmount, itemAmount, itemId));
                    }
    }
}

