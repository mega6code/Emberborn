
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Inventory : MonoBehaviour
{
    List<Item> playerItems = new List<Item>();
    private Transform player;
    [SerializeField]InventorySlotManager slotManager;
    
    private void Awake()
    {
        if (playerItems == null)
        {
            Debug.Log("Inventory list is empty.");
        }
        player = GetComponentInParent<Transform>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collided with an item!");

        if (other.GetComponent<ItemObject>())
        {
            Debug.Log("found item: " + other.name);

            Item item = other.GetComponent<ItemObject>().ItemCollect();// gets the specific itemData in game object
            GameObject prefab = other.gameObject;//gets the GameObject that the player collided with

            //Debug.Log("Prefab name: " + prefab.name);

            Additem(prefab, item);
        }
    }
    public void Additem(GameObject prefab, Item item)
    {
        //if (playerItems.Count >= 2 || playerItems != null)// makes sure player can only pick up 3 items 
        //{
            
            Debug.Log(item.name + " has been added to inventory");
            playerItems.Add(item);

            MeshRenderer mesh = prefab.GetComponentInChildren<MeshRenderer>();
            mesh.enabled = false;
            Light lightingObj = prefab.GetComponentInChildren<Light>();
            lightingObj.enabled = false;

            slotManager.AddIcon(item);
        //}
        //else
        //{
            //Debug.Log("Player inventory full!!");
        //}

    }

    public void DropItem(Item item)
    {
        if (playerItems != null && HasItem(item))//double check if statment
        {

            playerItems.Remove(item);
            Debug.Log("Item removed: + item.name");


            Vector3 playerLocation = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

            Instantiate(item.prefab, playerLocation, Quaternion.identity);

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
            
            Instantiate(item.prefab, location, Quaternion.identity);
            Debug.Log("item: " + item.name + " has been placed."); 

            return;
        }
        else
        {
            Debug.Log("item not found. Item name: " + item.name);
        }
    }
}
