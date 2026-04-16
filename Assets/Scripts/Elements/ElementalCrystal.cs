using UnityEngine;

namespace Emberborn.Elements
{
    public class ElementalCrystal : MonoBehaviour, IInteractable
    {
        [SerializeField] private ElementalTypes elementalType; //element
        public GameObject tutorial;
        public GameObject crystalLight;
        public GameObject crystalSound;

        public void Interact(InteractData interact_data)
        {
            interact_data.sender.TryGetComponent<ElementalStateManager>(out ElementalStateManager elementalStateManager);
            ReleaseElement(elementalStateManager);
            tutorial.SetActive(true);
            Time.timeScale = 0f;
        }

        private void ReleaseElement(ElementalStateManager elementalStateManager) //adds da element 
        {
            elementalStateManager.AddElement(elementalType); //add
            crystalLight.SetActive(false);
            crystalSound.SetActive(false);
        }
    }
}
