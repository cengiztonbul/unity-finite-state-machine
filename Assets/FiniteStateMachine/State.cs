using System.Collections.Generic;
using UnityEngine;

namespace FiniteStateMachine
{
	public abstract class State : MonoBehaviour
	{
		protected StateMachine context;
		
		public List<Transition> transitions;

		public virtual void OnStart() { }

		public virtual void Tick() { }

		public virtual void OnExit() { }

		public void Init()
		{
			ResetTransitions();
		}

		private void ResetTransitions()
		{
			foreach (Transition transition in transitions)
			{
				transition.SetCurrentState(this);
				transition.Reset();
			}
		}

		public void SetContext(StateMachine context)
		{
			this.context = context;
		}
	}
}
