using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LC.Inventory.Main
{
    [CreateAssetMenu(fileName = "Armor", menuName = "Inventory/Armor", order = 1)]
    public class Armor : Item
    {
        public float armor_value = 0;
        public float armor_hp = 0;
        public EquippingSpot equipping_spot;
        public enum EquippingSpot
        {
            Head,
            Shoulders,
            Chest
        }
        public override void Use()
        {
            base.Use();
            Debug.Log("U¿yto zbroi która zapewnia: " + armor_value+" pancerza i posiada:"+ armor_hp + " hp oraz zak³ada siê j¹ na "+equipping_spot.ToString());
        }
    }
}
