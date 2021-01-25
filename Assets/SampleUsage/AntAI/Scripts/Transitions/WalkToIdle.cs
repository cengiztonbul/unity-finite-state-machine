using FiniteStateMachine;
using UnityEngine;

namespace AntAI
{
	public class WalkToIdle : Transition
	{
		Vector3 target;

		public override bool Condition()
		{
			return (transform.position - ((Walk)currentState).target).sqrMagnitude < 0.5f;
		}
	}
}
