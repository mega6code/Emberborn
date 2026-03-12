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
        public override void ActivateAbility1(GameObject parent_game_object)
        {
            parent_game_object.GetComponent<ProjectileLauncher>().FireProjectile(projectile);
        }

        public override void ActivateAbility2(GameObject parent_game_object)
        {
            throw new System.NotImplementedException();
        }
    }
}