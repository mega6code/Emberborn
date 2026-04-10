using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Raycaster raycaster;
    [SerializeField] private float raycastDistance = 4;

    public void Interact()
    {
        RaycastHit hitObject = raycaster.FireShot(raycastDistance);

        if (hitObject.collider != null)
        {
            Debug.Log("");
            IInteractable interactable = hitObject.collider.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }
    
}

public interface IInteractable
{
    public void Interact();
}