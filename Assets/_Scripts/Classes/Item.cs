using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC.Inventory.Main
{

    public class Item : IItem
    {
        private int id = -1;

        private string display_name = "";
        private string db_name = "";
        private string description = "";

        private Sprite icon;

        public Item()
        {
            this.id = -1;
        }
        public Item(int _id, string _disp_name, string _dbname)
        {
            this.id = _id;
            this.display_name = _disp_name;
            this.db_name = _dbname;

            this.icon = Resources.Load<Sprite>("Sprites/Items/" + this.db_name);
        }


        public virtual void Use()
        {
            Debug.Log("U¿yto przedmiotu");
        }


        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public string Name
        {
            get
            {
                return this.display_name;
            }
            set
            {
                this.display_name = value;
            }
        } 
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public Sprite GetSprite()
        {
            return this.icon;
        }

       
    }
}
