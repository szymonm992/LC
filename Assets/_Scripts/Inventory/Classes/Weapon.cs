using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LC.Inventory.Main
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Wepon", order = 1)]
    public class Weapon : Item
    {
        public float damage = 0;
        public DamageType damage_type;
        public enum DamageType
        {
            Normalne,
            Obszarowe
        }
        public override void Use()
        {
            base.Use();
            Debug.Log("U¿yto broni zadaj¹cej: " + damage+ " dmg, której w³aœciwoœæ to "+damage_type.ToString()+" obra¿enia");
        }
    }
}
