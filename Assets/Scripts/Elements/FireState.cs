using System.Diagnostics;
using Emberborn.Mechanics;
using Unity.VisualScripting;
using UnityEngine;

namespace Emberborn.Elements
{
    [CreateAssetMenu(fileName = "FireState", menuName = "Scriptable Objects/ElementalStates/FireState")]
    public class FireState : ElementalState
    {
        [SerializeField] private GameObject projectile;
        public override void ActivateAbility(object o = null)
        {
            
        }
    }
}