using UnityEngine;
using UnityEngine.InputSystem;

public class PuzzleAlter : MonoBehaviour, IInteractable
{
    
    //[SerializeField] InputActionReference interactControl;

    [SerializeField] Inventory playerInventory;//reference to the player inventory
    private Item itemRequired; //Place which variant of item alter needs

    public bool alterActivated;

    [SerializeField] GameObject objectSpawn;// a collider when the gem should spawn when place on the alter
    private Transform location;

    void Awake()
    {

        //player in range of alter
        alterActivated = false;
        //get component that the alter needs to later compare with player inventory
        itemRequired = GetComponent<RequiredItem>().ItemCollect();

        location = objectSpawn.GetComponent<Transform>();
    }

    public void Interact(InteractData interact_data)
    {
        if (playerInventory.HasItem(itemRequired))
        {
            Debug.Log($"Player interacted with {gameObject.name}");
            alterActivated = true;
            Debug.Log("alter active: " + alterActivated);
            playerInventory.PlaceItem(itemRequired, location);
        }
    }
}
