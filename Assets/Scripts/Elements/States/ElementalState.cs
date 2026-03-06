using Emberborn.Interfaces;
using UnityEngine;

namespace Emberborn.Elements
{
    
	public abstract class ElementalState : ScriptableObject, IState
	{
        #region Fields
        #endregion

        #region Methods
        /// <summary>
        /// Activates the elemental state's ability,
        /// and takes its parent's gameObject reference as a parameter
        /// to be able to access the gameObject its apart of.
        /// </summary>
        /// <param name="parent_game_object"></param>
        public abstract void ActivateAbility(GameObject parent_game_object);       
        #endregion
        
    }
}