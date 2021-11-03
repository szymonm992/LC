using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


namespace LC.Inventory.Main
{
    public class Slot
    {
        private Item item;
        private int quantity;
        private GameObject slot_item;


        public Slot()
        {
            this.item = null;
            this.quantity = 0;
            this.slot_item = null;
        }
        public Slot(GameObject slot)
        {
            this.item = null;
            this.quantity = 0;
            this.slot_item = slot;
        }

        public GameObject GetPhysicalSlot()
        {
            return this.slot_item;
        }

        public void DeleteItemFromSlot()
        {
            this.item = null;
            this.quantity = 0;
        }
        public Item Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }
        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }
        public bool isEmpty()
        {
            if (this.item == null || this.item.id == -1) return true;
            else return false;
        }
    }

}
