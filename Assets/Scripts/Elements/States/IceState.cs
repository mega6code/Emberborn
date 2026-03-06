using Emberborn.Mechanics;
using UnityEngine;

namespace Emberborn.Elements
{
    [CreateAssetMenu(fileName = "IceState", menuName = "Scriptable Objects/ElementalStates/IceState")]
    public class IceState : ElementalState
    {
        [SerializeField] private GameObject projectile;
        public override void ActivateAbility(GameObject parent_game_object)
        {
            parent_game_object.GetComponent<ProjectileLauncher>().FireProjectile(projectile);
        }
    }
}