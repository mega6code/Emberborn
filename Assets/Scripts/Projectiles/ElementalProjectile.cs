using Emberborn.Interfaces;
using Unity;
using UnityEngine;

namespace Emberborn.Projectiles
{
    public class ElementalProjectile : MonoBehaviour
    {
        [SerializeField] private float element_strength;
        [SerializeField] private string method_name;

        private void OnCollisionEnter(Collision collision)
        {
            collision.gameObject.BroadcastMessage(method_name, element_strength, SendMessageOptions.DontRequireReceiver);
        }
    }
}
