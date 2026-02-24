using UnityEngine;
using UnityEngine.UI;

public class InventorySlotManager : MonoBehaviour
{
    public GameObject ImageSlot1;
    public GameObject ImageSlot2;
    public GameObject ImageSlot3;

    private bool ImSlot1;
    private bool ImSlot2;
    private bool ImSlot3;

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
            Debug.Log("In slot 1.");
            CreateIcon(item, ImageSlot2);
            this.ImSlot1 = true;
        }
        else if (ImSlot3 == false)
        {
            Debug.Log("In slot 1.");
            CreateIcon (item, ImageSlot3);
            this.ImSlot1 = true;
        }
        else
        {
            Debug.Log("no space in inventory!");
        }
    }
    public void CreateIcon(Item item, GameObject imageSlot)
    {
        Debug.Log("icon in Bar.");

        Transform location = imageSlot.GetComponent<Transform>();

        Instantiate(item.icon, location);

    }
    
}
