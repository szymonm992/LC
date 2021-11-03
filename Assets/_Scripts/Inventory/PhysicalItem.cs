using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using LC.Inventory.Main;
public class PhysicalItem : MonoBehaviour
{

    [Inject]
    private Inventory_operators inv_ops;
    [SerializeField] private int ID = -1;
    [SerializeField] private int Quantity = 1;

    void OnMouseDown()
    {
        AddToInventory();
    }
    public void AddToInventory()
    {
       
        if(ID == -1)
        {
            Debug.LogError("U need to assign the ID of prefab first!");
            return;
        }
        inv_ops.AddItem(ID, Quantity);
        Destroy(this.gameObject);
    }
}
