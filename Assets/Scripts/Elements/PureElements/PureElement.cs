using System;
using Emberborn.Interfaces;
using UnityEngine;

namespace Emberborn.Elements
{
    [Serializable]
    public class PureElement
    {
        public ElementalTypes elemental_type;
        public float strength;

        private string GetMessageMethodName()
        {
            switch (elemental_type)
            {
                case ElementalTypes.Ice:
                    return "OnFreeze";
                case ElementalTypes.Fire:
                    return "OnFire";
                default:
                    return null;
            }
        }

        private float FormatStrength()
        {
            switch (elemental_type)
            {
                case ElementalTypes.Fire:
                    return -strength;
                default:
                    return strength;
            }
        }

        public void ApplyElement(GameObject game_object)
        {
            PureElementData message_objects = new PureElementData();
            message_objects.strength = FormatStrength();

            game_object.BroadcastMessage(GetMessageMethodName(), message_objects, SendMessageOptions.DontRequireReceiver);
        }

        public void ApplyElement(GameObject game_object, Vector3 point)
        {
            PureElementData message_objects = new PureElementData();
            message_objects.strength = FormatStrength();
            message_objects.point_of_collision = point;

            game_object.BroadcastMessage(GetMessageMethodName(), message_objects, SendMessageOptions.DontRequireReceiver);
        }

        public PureElement(ElementalTypes type, float strength)
        {
            this.elemental_type = type;
            this.strength = strength;
        }
    }
}