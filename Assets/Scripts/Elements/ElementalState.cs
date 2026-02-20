using Emberborn.Interfaces;
using UnityEngine;

namespace Emberborn.Elements
{
    
	public abstract class ElementalState : ScriptableObject, IState
	{
        #region Fields
        #endregion

        #region Methods
        public abstract void ActivateAbility(object o = null);       
        #endregion
        
    }
}