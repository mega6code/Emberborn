using UnityEngine;

namespace Emberborn.Elements
{
    public class ElementalCrystal : MonoBehaviour
    {
        [SerializeField] private ElementalTypes e_type; //element

        private void ReleaseElement(ElementalStateManager elementalStateManager) //adds da element 
        {
            elementalStateManager.AddElement(e_type); //add
        }
    }
}
