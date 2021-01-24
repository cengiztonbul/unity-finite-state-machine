using System.Collections.Generic;

namespace FiniteStateMachine.Abstract
{
	public interface IState
	{
		IFiniteStateMachine Context { get; set; }

		List<ITransition> Transitions { get; set; }

		void OnStart();

		void Tick();

		void OnExit();
	}
}
