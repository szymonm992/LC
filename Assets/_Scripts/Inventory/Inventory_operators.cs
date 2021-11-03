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
        [Inject]
        Inventory_DB inv_db;

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

        /// <summary>
        /// Checks wether inventory contains an item with given Id and if so returns the id, otherwise returns -1
        /// </summary>
        /// <param name="id">Given Id of an item</param>
        /// <returns></returns>
        public int CheckIfIsInInventory(int id)
        {
            for (int i = 0; i < inv_script.inventory.Count; i++)
            {
                if (!inv_script.inventory[i].isEmpty() && inv_script.inventory[i].Item.id == id) return i;
            }
            return -1;
        }

        public bool AddItem(int id, int quantity)
        {
            int isIn = CheckIfIsInInventory(id);

            if(isIn == -1)
            {
                int first_empty = FindEmptySlot();
                if (first_empty != -1)
                {
                    Debug.Log("first empty at" + first_empty);
                    Slot slot_with_empty = inv_script.inventory[first_empty];
                    Item added_item = inv_db.GetItem(id);
                    slot_with_empty.Item = added_item;
                    slot_with_empty.Quantity = quantity;
                    return true;
                }
                else
                {
                    Debug.LogError("Cant find any empty slot");
                    return false;
                }
            }
            else
            {
                Slot existing_slot = inv_script.inventory[isIn];
                Item added_item = inv_db.GetItem(id);
                existing_slot.Item = added_item;
                existing_slot.Quantity += quantity;
                return true;
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

        public void UseItemAtSlot(int id)
        {
            Slot slot_in_inv = inv_script.inventory[id];
            if (!slot_in_inv.isEmpty())
                slot_in_inv.Item.Use();
        }
    }

}

