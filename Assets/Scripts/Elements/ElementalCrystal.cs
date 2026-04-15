using UnityEngine;

namespace Emberborn.Elements
{
    public class ElementalCrystal : MonoBehaviour, IInteractable
    {
        [SerializeField] private ElementalTypes elementalType; //element

        public void Interact(InteractData interact_data)
        {
            interact_data.sender.TryGetComponent<ElementalStateManager>(out ElementalStateManager elementalStateManager);
            ReleaseElement(elementalStateManager);
        }

        private void ReleaseElement(ElementalStateManager elementalStateManager) //adds da element 
        {
            elementalStateManager.AddElement(elementalType); //add
        }
    }
}
