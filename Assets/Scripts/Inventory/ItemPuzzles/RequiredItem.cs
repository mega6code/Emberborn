using UnityEngine;

public class RequiredItem : MonoBehaviour
{
    [SerializeField] private Item item;

    public Item ItemCollect()
    {
        return item;
    }
}
