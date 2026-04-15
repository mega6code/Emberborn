using System;
using System.Threading;
using Emberborn.Elements;
using Emberborn.Interfaces;
using UnityEngine;

namespace Emberborn.Mechanics
{
    public class AutoMelt : MonoBehaviour, IFreezable
    {
        [SerializeField] private ProgressiveScaler progressiveScaler;
        [SerializeField] private float maxTimer = 3;

        private float timer;

        private void Start()
        {
            timer = maxTimer;
        }
        private void Update()
        {
            if (timer <= 0)
            {
                Melt();
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        private void Melt()
        {
            progressiveScaler.ChangeTargetScale(-float.MaxValue);
        }

        public void OnFreeze(PureElementData message_objects)
        {
            timer = maxTimer; //reset the timer
        }
    }
}
