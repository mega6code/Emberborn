using System;
using UnityEngine;

namespace Emberborn.Elements
{
    public class ElementalCrystal : MonoBehaviour, IInteractable
    {
        public static event Action<ElementalTypes> collected;
        public GameObject tutorial;

        [SerializeField] private ElementalTypes elementalType; //element
        public GameObject crystalLight;
        public GameObject crystalSound;

        public void Interact(InteractData interact_data)
        {
            interact_data.sender.TryGetComponent<ElementalStateManager>(out ElementalStateManager elementalStateManager);
            ReleaseElement(elementalStateManager);
        }

        private void ReleaseElement(ElementalStateManager elementalStateManager) //adds da element 
        {
            elementalStateManager.AddElement(elementalType); //add
            collected?.Invoke(elementalType);
            crystalLight.SetActive(false);
            crystalSound.SetActive(false);
            Tutorial();
        }
        private void Tutorial()
        {
            tutorial.SetActive(true);
            Time.timeScale = 0f;
        }

        public void CloseTutorial()
        {
            tutorial.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
