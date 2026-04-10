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
        /// Activates the ElementalState's ability. Takes parent's gameObject reference as a parameter 
        /// to access the GameObject its apart of.
        /// </summary>
        /// <param itemName="parent_game_object"></param>
        public abstract void ActivateAbility1(GameObject parent_game_object);
        public abstract void ActivateAbility2(GameObject parent_game_object);
        #endregion

    }
}