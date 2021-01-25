using UnityEngine;
using FiniteStateMachine.Abstract;
namespace AntAI.Transitions
{
	public class WalkToIdle : ITransition
	{
		public GameObject gameObject;
		public Transform transform;
		
		public IState CurrentState { get; set; }
		public IState NextState { get; set; }

		private readonly Transform _target;

		public WalkToIdle(GameObject gameObject, Transform target, IState currentState, IState nextState)
		{
			this.gameObject = gameObject;
			this.transform = gameObject.transform;
			CurrentState = currentState;
			NextState = nextState;

			_target = target;
		}

		public bool Condition()
		{
			return (_target.position - transform.position).sqrMagnitude < 0.3f;
		}

		public void InitTransition()
		{
		}
	}
}
