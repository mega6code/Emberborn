using Emberborn.Elements;
using Emberborn.Interfaces;
using Unity;
using UnityEngine;

namespace Emberborn.Projectiles
{
    public class ElementalProjectile : MonoBehaviour
    {
        [SerializeField] private ElementalTypes type;
        [SerializeField] private float strength;

        private PureElement pure_element;

        private void Start()
        {
            pure_element = new PureElement(type, strength);
        }

        private void OnCollisionEnter(Collision collision)
        {
            pure_element.ApplyElement(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
