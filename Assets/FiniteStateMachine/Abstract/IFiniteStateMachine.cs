using System.Collections.Generic;

namespace FiniteStateMachine.Abstract
{
	public interface IFiniteStateMachine
	{
		IState InitialState { get; set; }
		
		IState ActiveState { get; set; }

		List<ITransition> TransitionsFromAnyState { get; set; }

		void Tick();

		void ChangeState(IState nextState);

		void CheckTransitions();
	}
}
