using UnityEngine;
using UnityEngine.UI;

public class InventorySlotManager : MonoBehaviour
{
    public Image slot1;
    public Image slot2;
    public Image slot3;


    public void AddIcon(Item item)
    {
        if (slot1 = null)
        {
            slot1.sprite = item.icon;
            slot1.enabled = true;
        }
        else if (slot2 = null)
        {
            slot2.sprite = item.icon;
            slot2.enabled = true;
        }
        else if (slot3 = null)
        {
            slot3.sprite = item.icon;
            slot3.enabled = true;
        }
        else
        {
            Debug.Log("no space in inventory!");
        }
    }

}
