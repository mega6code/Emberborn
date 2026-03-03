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

    //stores instantiated items
    GameObject icon1;
    GameObject icon2;
    GameObject icon3;


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
            CreateIcon(item, ImageSlot1);
            this.ImSlot1 = true;
        }
        else if (ImSlot2 == false)
        {
            Debug.Log("In slot 2.");
            CreateIcon(item, ImageSlot2);
            this.ImSlot2 = true;
        }
        else if (ImSlot3 == false)
        {
            Debug.Log("In slot 3.");
            CreateIcon (item, ImageSlot3);
            this.ImSlot3 = true;
        }
        else
        {
            Debug.Log("no space in inventory!");
        }
    }
    
    /*public void RemoveIcon(Item item)
    {
        if ()
        {

        }
        else if ()
        {

        }
        else if ()
        {

        }
        else
        {
            Debug.Log("Could not remove: " + item.name + "From the UI bar");
        }
    }*/
    public void CreateIcon(Item item, GameObject imageSlot)//creates a gameObject at the location of the slot 
    {
        Debug.Log("icon in Bar.");

        Transform location = imageSlot.GetComponent<Transform>();

        Instantiate(item.icon, location);

    }
    
}
