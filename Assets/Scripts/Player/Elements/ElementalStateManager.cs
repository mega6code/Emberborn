using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class ElementalStateManager : MonoBehaviour
    {
        #region Fields
        [SerializeField] private List<ElementalTypes> collected_elements = new List<ElementalTypes>();

        private ElementalState current_state = null;
        #endregion

        #region Properties
        #endregion

        #region Methods
        private void AddElement(ElementalTypes e_type)
        {
            if (!collected_elements.Contains(e_type))
            {
                collected_elements.Add(e_type);
            }
        }
        #endregion

        #region Event Methods
        private void OnTriggerEnter(Collider other)
        {
            //if(other.CompareTag("ElementalPotion"))           
            //{
            //    //other.GetComponent<>
            //}
        }
        #endregion

        #region Events
        #endregion
    } 
}
