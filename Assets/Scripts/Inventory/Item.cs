using System.Collections;
using UnityEngine;



    [CreateAssetMenu(fileName = "New Item", menuName = "EmberBorn/Create inventory item", order = 0)]
    public class Item : ScriptableObject
    {

         public string type;
         public string name;
         public GameObject prefab;
         public Sprite icon;
           
    }
