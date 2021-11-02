using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LC.Inventory.Main
{
    public class PhysicalDescriptionItem
    {
        public GameObject root_obj;
        public void InitializeComponent()
        {
            this.description_item_name = root_obj.transform.GetChild(0).GetComponent<Text>();
            this.description_item_desc = root_obj.transform.GetChild(1).GetComponent<Text>();
        }

        public PhysicalDescriptionItem(GameObject root)
        {
            this.root_obj = root;
            InitializeComponent();
        }
        public Text description_item_name;
        public Text description_item_desc;
    }
}
