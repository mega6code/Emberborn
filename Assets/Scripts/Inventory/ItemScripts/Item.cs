using System.Collections;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "New Item", menuName = "EmberBorn/Create inventory item", order = 0)]
    public class Item : ScriptableObject
    {

         
         public string itemName;
         public GameObject prefab;
         public GameObject icon;
           
    }
