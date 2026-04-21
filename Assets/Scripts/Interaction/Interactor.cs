using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Raycaster raycaster;
    //[SerializeField] private float raycastDistance = 4;

    public void Interact()
    {
        raycaster.FireRay(out RaycastHit hitObject);

        if (hitObject.collider != null)
        {
            Debug.Log("");
            IInteractable interactable = hitObject.collider.GetComponent<IInteractable>();
            interactable?.Interact(new InteractData(this.gameObject));
        }
    }
    
}
