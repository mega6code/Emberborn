using UnityEngine;
using UnityEngine.UI;

public class InventorySlotManager : MonoBehaviour
{
    //uses gameobject to get the postions of where the icons should go
    public GameObject ImageSlot1;
    public GameObject ImageSlot2;
    public GameObject ImageSlot3;

    //makes sure that slots are empty or in use
    private bool ImSlot1;
    private bool ImSlot2;
    private bool ImSlot3;

    //stores instantiated items and the gameObject instantiated
    Item index1;
    Item index2;
    Item index3;

    GameObject instantiated1;
    GameObject instantiated2;
    GameObject instantiated3;


    private void Awake()
    {
        ImSlot1 = false;
        ImSlot2 = false;
        ImSlot3 = false;

    }

    public void AddIcon(Item item)//need to fix, code it atomatically going into the else statement.
    {
        if (ImSlot1 == false)
        {
            Debug.Log("In slot 1.");
            CreateIcon(item, ImageSlot1, 1);
            this.ImSlot1 = true;
        }
        else if (ImSlot2 == false)
        {
            Debug.Log("In slot 2.");
            CreateIcon(item, ImageSlot2, 2);
            this.ImSlot2 = true;
        }
        else if (ImSlot3 == false)
        {
            Debug.Log("In slot 3.");
            CreateIcon (item, ImageSlot3, 3);
            this.ImSlot3 = true;
        }
        else
        {
            Debug.Log("no space in inventory!");
        }
    }
    
    public void RemoveIcon(Item itemToRemove)
    {
        if (itemToRemove.name == index1.name)
        {
            Destroy(instantiated1);
        }
        else if (itemToRemove.name == index2.name)
        {
            Destroy (instantiated2);
        }
        else if (itemToRemove.name == index3.name)
        {
            Destroy(instantiated3);
        }
        else
        {
            Debug.Log("Could not remove: " + itemToRemove.name + "From the UI bar");
        }
    }
    public void CreateIcon(Item item, GameObject imageSlot, int index)//creates a gameObject at the location of the slot 
    {//add index to save the instantiated object
        Debug.Log("icon in Bar.");

        Transform location = imageSlot.GetComponent<Transform>();

        switch (index)
        {
            case 1:
                index1 = item;
                instantiated1 = Instantiate(item.icon, location);
                break;
            case 2:
                index2 = item;
                instantiated2 = Instantiate(item.icon, location);
                break;
            case 3:
                index3 = item;
                instantiated3 = Instantiate(item.icon, location);
                break;
        }

    }
    
}
