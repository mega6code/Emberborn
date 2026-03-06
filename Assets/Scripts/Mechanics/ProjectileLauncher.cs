using Unity.VisualScripting;
using UnityEngine;

namespace Emberborn.Mechanics
{
    public class ProjectileLauncher : MonoBehaviour
    {

        #region Fields
        [SerializeField] private Transform launch_point;
        [SerializeField] private float launch_speed;
        #endregion
        
        #region Methods
        public void FireProjectile(GameObject game_object)
        {
            game_object = GameObject.Instantiate(game_object, launch_point.position, launch_point.rotation);
            
            if (game_object.TryGetComponent(out Rigidbody rb))
            {
                rb.linearVelocity = launch_speed * launch_point.forward;
            }
        }
        #endregion
    }
}