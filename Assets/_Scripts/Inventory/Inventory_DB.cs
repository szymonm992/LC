using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LC.Inventory.Main
{
    public class Inventory_DB : MonoBehaviour
    {
        public List<Item> all_items = new List<Item>();

        public Item GetItem(int id)
        {
            return all_items.Find(item => item.id == id);
        }
        public Item GetItem(string name)
        {
            return all_items.Find(item => item.name == name);
        }
    }
}
