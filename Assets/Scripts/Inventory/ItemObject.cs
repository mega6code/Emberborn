using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private Item item;
    
    public Item ItemCollect()
    {

        Debug.Log("Return item: " + item.name);
        return item;
    }
}
