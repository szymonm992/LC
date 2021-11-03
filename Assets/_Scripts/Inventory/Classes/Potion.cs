using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LC.Inventory.Main
{
    [CreateAssetMenu(fileName = "Potion", menuName = "Inventory/Potion", order = 1)]
    public class Potion : Item
    {
        public float healing_hp = 0;

        public override void Use()
        {
            base.Use();
            Debug.Log("U¿yto mikstury leczniczej i przywrócono: " + healing_hp);
        }
    }
}
