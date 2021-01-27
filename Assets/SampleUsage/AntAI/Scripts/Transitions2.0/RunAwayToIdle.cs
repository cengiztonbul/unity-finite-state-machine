using FiniteStateMachine.Abstract;
using UnityEngine;

namespace AntAI.Transitions
{
	public class RunAwayToIdle : ITransition
	{
		Transform transform;
		Transform enemy;

		public IState CurrentState { get; set; }
		public IState NextState { get; set; }
		
		private float safeDistanceSqr;
		
		public RunAwayToIdle(IState currentState, IState nextState, float safeDistance, Transform transform, Transform enemy)
		{
			this.transform = transform;
			this.enemy = enemy;
			this.NextState = nextState;
			this.CurrentState = currentState;
			safeDistanceSqr = safeDistance * safeDistance;
		}

		public bool Condition()
		{
			Debug.Log((enemy.position - transform.position).sqrMagnitude);
			return (enemy.position - transform.position).sqrMagnitude > safeDistanceSqr;
		}

		public void InitTransition() { }
	}
}
