using UnityEngine;
using UnityEngine.InputSystem;

public class PuzzleAlter : MonoBehaviour
{
    
    //[SerializeField] InputActionReference interactControl;

    [SerializeField] Inventory playerInventory;//reference to the player inventory
    [SerializeField] InputActionReference interactControl;
    private Item itemRequired; //Place which variant of item alter needs

    public bool alterActivated;
    private bool inRange;

    [SerializeField] GameObject objectSpawn;// a collider when the gem should spawn when place on the alter
    private Transform location;

    void Awake()
    {

        //player in range of alter
        inRange = false;
        alterActivated = false;
        //get component that the alter needs to later compare with player inventory
        itemRequired = GetComponent<RequiredItem>().ItemCollect();

        location = objectSpawn.GetComponent<Transform>();
    }

    void Update()
    {
        if (interactControl.action.triggered && inRange == true)
        {
            Debug.Log("Player interacted with item");
            Debug.Log("alter active: " + alterActivated);
            OnInteract();
        }
    }
    private void OnTriggerEnter(Collider other)//player enters in range 
    {
        if (other.CompareTag("Animal"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)//player leaves the interactable range of alter
    {
        if (other.CompareTag("Animal"))
        {
            inRange = false;
        }
    }
    public void OnInteract()//when player presses the interact button 
    {
        //add prefab to alter
        if (playerInventory.HasItem(itemRequired))
        {
            alterActivated = true;
            Debug.Log("alter active: " + alterActivated);
            playerInventory.PlaceItem(itemRequired, location);
        }
        //remove item from player inventory
    }

}
