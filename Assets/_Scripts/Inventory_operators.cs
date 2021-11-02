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
            Slot slot_with_empty = inv_script.inventory[first_empty];
            if (first_empty != -1)
            {
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
    }

}

