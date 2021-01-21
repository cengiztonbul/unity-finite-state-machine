using System.Collections.Generic;
using UnityEngine;

namespace FiniteStateMachine
{
	public class StateMachine : MonoBehaviour
	{
		[SerializeField] private List<Transition> transitionsFromAnyState;
		
		[SerializeField] private State initialState;

		private State currentState;

		private void Start()
		{
			ChangeState(initialState);
		}

		public void Update()
		{
			currentState?.Tick();
		}

		public void LateUpdate()
		{
			CheckTransition();
		}

		public void ChangeState(State nextState)
		{
			currentState?.OnExit();
			nextState.Init();
			nextState.OnStart();
			this.currentState = nextState;
		}

		public void CheckTransition()
		{
			foreach (Transition transition in currentState?.transitions)
			{
				if (transition.Condition())
				{
					ChangeState(transition.nextState);
				}
			}

			if (transitionsFromAnyState == null)
			{
				return;
			}

			foreach (Transition transition in transitionsFromAnyState)
			{
				if (transition.Condition())
				{
					ChangeState(transition.nextState);
				}
			}
		}
	}
}
