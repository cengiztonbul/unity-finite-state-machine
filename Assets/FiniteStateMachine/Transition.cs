using UnityEngine;

namespace FiniteStateMachine
{
	public class Transition : MonoBehaviour
	{
		public State nextState;		
		public State currentState;

		public virtual bool Condition()
		{
			return true;
		}

		public void SetCurrentState(State currentState)
		{
			this.currentState = currentState;
		}

		public virtual void ResetCondition() { }
	}
}
