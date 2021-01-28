using System.Collections.Generic;
using FiniteStateMachine.Abstract;

namespace FiniteStateMachine.Concrete
{
	class FiniteStateMachine : IFiniteStateMachine
	{
		public IState InitialState { get; set; }

		public IState ActiveState { get; set; }
		
		public List<ITransition> TransitionsFromAnyState { get; set; }

		public FiniteStateMachine()
		{
			TransitionsFromAnyState = new List<ITransition>();
		}

		public void ChangeState(IState nextState)
		{
			if (ActiveState != null)
			{
				ActiveState.OnExit();
			}

			nextState.OnStart();
			ActiveState = nextState;
			
			foreach(ITransition transition in nextState.Transitions)
			{
				transition.InitTransition();
			}
		}

		public void Tick()
		{
			ActiveState?.Tick();
			CheckTransitions();
		}

		public void CheckTransitions()
		{
			foreach (ITransition transition in TransitionsFromAnyState)
			{
				if (transition.Condition())
				{
					ChangeState(transition.NextState);
				}
			}

			foreach (ITransition transition in ActiveState.Transitions)
			{
				if (transition.Condition())
				{
					ChangeState(transition.NextState);
				}
			}
		}
	}
}
