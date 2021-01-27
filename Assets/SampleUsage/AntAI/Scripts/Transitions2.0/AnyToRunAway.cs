using UnityEngine;
using FiniteStateMachine.Abstract;
namespace AntAI.Transitions
{
	public class AnyToRunAway : ITransition
	{
		Transform transform;
		Transform enemy;

		public IState CurrentState { get; set; }
		public IState NextState { get; set; }

		float safeDistanceSqr;

		public AnyToRunAway(IState nextState, Transform transform, Transform enemy, float safeDistance)
		{
			this.NextState = nextState;
			this.transform = transform;
			this.enemy = enemy;
			safeDistanceSqr = safeDistance * safeDistance;
		}

		public bool Condition()
		{
			Debug.Log((enemy.position - transform.position).sqrMagnitude < safeDistanceSqr);
			return (enemy.position - transform.position).sqrMagnitude < safeDistanceSqr;
		}

		public void InitTransition() { }
	}
}
