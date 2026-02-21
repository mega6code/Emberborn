
using System;
using System.Collections.Generic;
using UnityEngine;



public class Inventory : MonoBehaviour
{
    List<Item> playerItems = new List<Item>();
    [SerializeField] private GameObject player;
    
    private void Awake()
    {
        if (playerItems == null)
        {
            Debug.Log("Inventory list is empty.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemObject>())
        {
           Item item = other.GetComponent<ItemObject>().ItemCollect();
            Additem(item);
        }
    }
    public void Additem(Item item)
    {
        //add item to inventory
        playerItems.Add(item);
    }

    public void DropItem(Item item)
    {
        if (playerItems != null && HasItem(item))//double check if statment
        {

            playerItems.Remove(item);
            Debug.Log("Item removed: + item.name");


            Vector3 playerLocation = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

            Instantiate(item, playerLocation, Quaternion.identity);

            return; 
        }
        else
        {
            Debug.Log("item not found. Item name: " + item.name);
        }
    }
    public bool HasItem(Item targetItem)
    {
        if (playerItems != null)
        {
            foreach (Item items in playerItems)
            {
                if (items.name == targetItem.name)
                {
                    Debug.Log("Item: " + targetItem.name + " is in inventory");
                   return true;
                    
                }
            }
            
        }
        Debug.Log("target item is not in inventory: " + targetItem.name);
        return false;
    }

    public void PlaceItem(Item item, Vector3 location)
    {
        if (playerItems != null && HasItem(item))//double check if statment
        {

            playerItems.Remove(item);
            
            Instantiate(item, location, Quaternion.identity);
            Debug.Log("item: " + item.name + " has been placed."); 

            return;
        }
        else
        {
            Debug.Log("item not found. Item name: " + item.name);
        }
    }
    

}
