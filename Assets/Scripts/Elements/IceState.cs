using UnityEngine;

namespace Emberborn.Elements
{
    [CreateAssetMenu(fileName = "IceState", menuName = "Scriptable Objects/ElementalStates/IceState")]
    public class IceState : ElementalState
    {
        [SerializeField] private GameObject projectile;
        public override void ActivateAbility()
        {
            throw new System.NotImplementedException();
        }
    }
}