using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LC.Inventory.Main
{
    public class Inventory : MonoBehaviour
    {
        [Header("Control inputs")]
        [SerializeField] private string INVENTORY_BUTTON = "Inventory";


        //general variables
        private bool display_inventory = false;

        [Inject(Id = "ui_slots_parent")]
        private GameObject slots_parent;
        [Inject(Id = "ui_description")]
        private GameObject description_parent;

        internal List<Slot> inventory = new List<Slot>();

        //description variables
        private Slot highlighted_slot = new Slot();

        private PhysicalDescriptionItem description_item_obj;

        private Text desc_title;
        private Text desc_content;

        private void Start() => InitializeComponents(); 

        private void InitializeComponents()
        {
            for (int i = 0; i < 6; i++)
            {
                GameObject objToAdd = slots_parent.transform.GetChild(i).gameObject;
                var slot_controller = objToAdd.GetComponent<SlotController>();
                inventory.Add(new Slot(objToAdd));
                slot_controller.ID = i;
            }

            description_item_obj = new PhysicalDescriptionItem(description_parent.gameObject);
        }

        private void Update()
        {
            if (Input.GetButtonDown(INVENTORY_BUTTON))
            {
                display_inventory = !display_inventory;
                slots_parent.SetActive(display_inventory);
            }
            if (display_inventory) DrawInventory();
        
        }

        private void DrawInventory()
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                Slot slot = inventory[i];
                GameObject icon_img = slot.GetPhysicalSlot().transform.GetChild(0).gameObject;
                Image icon_img_spr = slot.GetPhysicalSlot().transform.GetChild(0).gameObject.GetComponent<Image>();
                Text quant_text = slot.GetPhysicalSlot().transform.GetChild(1).gameObject.GetComponent<Text>();
                if (inventory[i].isEmpty())
                {
                    if (icon_img.activeSelf) icon_img.SetActive(false);
                    if (quant_text.text != "") quant_text.text = "";
                }
                else
                {
                    if (!icon_img.activeSelf) icon_img.SetActive(true);
                    icon_img_spr.sprite = slot.Item.icon;
                    quant_text.text = slot.Quantity.ToString();
                }
            }
        }

      
        /// <summary>
        /// Void that hides the empty description or activates it if conditions are fulfilled
        /// </summary>
        /// <param name="id">Id of slot</param>
        /// <param name="val">Value of activation</param>
        public void UpdateDesription(int id,bool val)
        {
            if (val && !description_parent.activeInHierarchy)
            {
                Slot highlighted_slot = inventory[id];
                if (!highlighted_slot.isEmpty())
                    AssignDescValues(val, highlighted_slot.Item.display_name, highlighted_slot.Item.description);
                    
            }
            else if (!val && description_parent.activeInHierarchy)
                AssignDescValues(val, "", "");
        }

        private void AssignDescValues(bool val,string title, string content)
        {
            description_parent.SetActive(val);
            description_item_obj.description_item_name.text = title;
            description_item_obj.description_item_desc.text = content;
        }

       
    }
}



