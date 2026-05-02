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
        [SerializeField] private ParticleSystem vfx;

        private PureElement pure_element;

        private void Start()
        {
            pure_element = new PureElement(type, strength);
        }

        private void OnCollisionEnter(Collision collision)
        {
            pure_element.ApplyElement(collision.gameObject);

            

            //if (gameObject.TryGetComponent<Renderer>(out Renderer renderer))
            //{
            //    renderer.enabled = false;
            //}

            //if (gameObject.TryGetComponent<Collider>(out Collider collider))
            //{
            //    collider.enabled = false;
            //}

            Destroy(vfx.gameObject, 5f);
            transform.DetachChildren();
            Destroy(gameObject);
        }
    }
}
