using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace LC.Inventory.Main
{
    public class Inventory_operators : MonoBehaviour
    {
        [Inject]
        Inventory inv_script;


        int interacting_item_index = -1;
        /// <summary>
        /// Finds the first empty slot or returns -1 as an index
        /// </summary>
        /// <returns></returns>
        public int FindEmptySlot()
        {
            for (int i = 0; i < inv_script.inventory.Count; i++)
            {
                if (inv_script.inventory[i].isEmpty()) return i;
            }
            return -1;
        }

        public bool AddItem(int id, int quantity)
        {
            int first_empty = FindEmptySlot();
            if (first_empty != -1)
            {
                Slot slot_with_empty = inv_script.inventory[first_empty];
                //Item added_item = inv_db.GetItem(id);
                // slot_with_empty.Item = added_item;
                //slot_with_empty.Quantity = quantity;
                return true;
            }
            else
            {
                Debug.LogError("Cant find any empty slot");
                return false;
            }
        }


        public void SetInteracting(int id)
        {
            interacting_item_index = id;
            Debug.Log("interacting with " + id);
        }
        public void RemoveItemAtSlot(int id)
        {
            Slot slot_in_inv = inv_script.inventory[id];
            if(!slot_in_inv.isEmpty())
            {
                if (slot_in_inv.Quantity > 1)
                    slot_in_inv.Quantity -= 1;
                else
                    slot_in_inv.DeleteItemFromSlot();
            }
        }
    }

}

