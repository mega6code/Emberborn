using Interfaces;

namespace Player
{
	public abstract class ElementalState : IState
	{
        #region Fields
        #endregion

        #region Methods
        protected abstract void ActivateAbility();       
        #endregion
        
    }
}