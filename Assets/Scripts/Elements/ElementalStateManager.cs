using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Emberborn.Elements
{
    public class ElementalStateManager : MonoBehaviour
    {
        #region Fields
        //serialized fields
        [SerializeField] private List<ElementalTypes> collected_elements = new List<ElementalTypes>(); //Emby's elements!!!!!!
        [SerializeField] private ElementalState[] allElements;

        //other fields
        private ElementalState current_state = null;
        private int collected_elem_index = 0; //to keep track of which collected element is being used for the state
        #endregion

        #region Properties
        public ElementalState Current_state { get => current_state;} //in case u need to check Emby's state outside of this class
        public int Collected_elem_index { get => collected_elem_index;} 
        #endregion

        #region Methods
        /// <summary>
        /// Adds element to Emby's elements
        /// </summary>
        public void AddElement(ElementalTypes e_type)
        {
            if (!collected_elements.Contains(e_type))
            {
                collected_elements.Add(e_type);
            }
            else
            {
                //collected-elements[e_type].Upgrade
                //....maybeee
            }
        }

        /// <summary>
        /// For the collected elements list, increments index to next element index in list
        /// </summary>
        private void IncrementIndex()
        {
            collected_elem_index++;

            if (collected_elem_index > collected_elements.Count - 1) //if index counter is past the last element index 
            {
                collected_elem_index = 0; //back to first element in the list
            }
        }

        /// <summary>
        /// Gets next state in the state cycle
        /// </summary>
        /// <returns>ElementalState</returns>
        private ElementalState GetNextState()
        {
            ElementalState next_state = null;

            IncrementIndex();

            switch (collected_elements[collected_elem_index])
            {
                case ElementalTypes.Ice:
                    next_state = allElements[0];
                    changedState?.Invoke(collected_elements[collected_elem_index]);
                    break;
                case ElementalTypes.Fire:
                    next_state = allElements[1];
                    changedState?.Invoke(collected_elements[collected_elem_index]);
                    break;
            }

            return next_state;
        }

        /// <summary>
        /// To be called when Emby interacts with a Element pick up, adds element to Emby's elements
        /// </summary>
        public void OnElementPickUp(ElementalTypes e_types)
        {
            AddElement(e_types);
        }

        public void OnAbility(int ability_num)
        {
            if(current_state != null)
            {
                switch (ability_num)
                {
                    case 1:
                        current_state.ActivateAbility1(this.gameObject);
                        break;
                    case 2:
                        current_state.ActivateAbility2(this.gameObject);
                        break;
                    default:
                        break;
                }      
            }
            else
            {
                Debug.Log("No Elemental State yet!");
            }

        }

        public void OnChangeState()
        {
            if(collected_elements != null && collected_elements.Count != 0) //at least 1 element has to be collected to be able to activate 'switch'
            {
                ElementalState next_state = GetNextState();

                current_state = next_state; //will be the same elemeent if Emby only has 1 element collected

                Debug.Log($"Switched to {current_state.GetType()}");
            }
            else
            {
                Debug.Log("No Elements collected yet!");
            }
            
        }
        #endregion

        #region Events
        public event Action<ElementalTypes> changedState;
        #endregion

    } 

}
