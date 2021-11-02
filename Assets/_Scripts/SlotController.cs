using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LC.Inventory.Main
{
    public class SlotController : MonoBehaviour
    {
        [Inject]
        Inventory inv_script;

        public int ID = -1;

        Color colNorm = new Color(0.45f, 0.45f, 0.45f, 1f);
        Color colHov = new Color(0.57f, 0.57f, 0.57f, 1f);


        Image img_comp;
        private void Start()
        {
            img_comp = GetComponent<Image>();
        }

        public void Hover()
        {
            img_comp.color = colHov;
            inv_script.UpdateDesription(ID, true);
        }
        public void Unhover()
        {
            img_comp.color = colNorm;
            inv_script.UpdateDesription(ID, false);
        }
    }


}
