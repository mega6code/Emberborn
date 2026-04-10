
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
    private void OnTriggerEnter(Collider other)//player collects items if they collide with it
    {
        //Debug.Log("collided with an targetItem!");

        if (other.GetComponent<ItemObject>())
        {
            Debug.Log("found targetItem: " + other.name);

            Item item = other.GetComponent<ItemObject>().ItemCollect();// gets the specific itemData in game object
            GameObject prefab = other.gameObject;//gets the GameObject that the player collided with

            //Debug.Log("Prefab itemName: " + prefab.itemName);

            Additem(prefab, item);
        }
    }
    public void Additem(GameObject prefab, Item item)
    {
        if (playerItems.Count < 3)// makes sure player can only pick up 3 items 
        {
            
            Debug.Log(item.itemName + " has been added to inventory");
            playerItems.Add(item);

            //turning off the following components so gem is not Visible
            MeshRenderer gemMesh = prefab.GetComponentInChildren<MeshRenderer>();
            gemMesh.enabled = false;
            Light gemLighting = prefab.GetComponentInChildren<Light>();
            gemLighting.enabled = false;
            Collider gemCollider = prefab.GetComponent<Collider>();
            gemCollider.enabled = false;

            slotManager.AddIcon(item);
        }
        else
        {
            Debug.Log("Player inventory full!!");
        }

    }
    public bool HasItem(Item targetItem)//makes sure if the player has a spcific item in inventory
    {
        if (playerItems != null)
        {
            foreach (Item items in playerItems)
            {
                if (items.itemName == targetItem.itemName)
                {
                    Debug.Log("Item: " + targetItem.itemName + " is in inventory");
                   return true;
                    
                }
            }
            
        }
        Debug.Log("target targetItem is not in inventory: " + targetItem.itemName);
        return false;
    }

    public void PlaceItem(Item targetItem, Transform location)//Should place prefab at a target position
    {
        if (playerItems != null)
        {

            Instantiate(targetItem.prefab, location.position, location.rotation);
            slotManager.RemoveIcon(targetItem);
            playerItems.Remove(targetItem);
            Debug.Log("targetItem: " + targetItem.itemName + " has been placed."); 

        }

    }
}
