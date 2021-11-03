using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC.Inventory.Main
{
    [System.Serializable]
    public class Item : ScriptableObject, IItem
    {
         public int id = -1;

         public string display_name = "";
         [Multiline]
         public string description = "";

         public Sprite icon;

        public virtual void Use()
        {
            Debug.Log("U¿yto przedmiotu");
        }
    }
}
