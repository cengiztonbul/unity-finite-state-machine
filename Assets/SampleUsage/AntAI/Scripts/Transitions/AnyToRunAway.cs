using FiniteStateMachine;
using UnityEngine;

namespace AntAI
{
	public class AnyToRunAway : Transition 
	{
		Transform enemy;
		[SerializeField] float dangerDistance = 2;
		private float _dangerDistanceSqr;

		private void Awake()
		{
			enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
			_dangerDistanceSqr = dangerDistance * dangerDistance;
		}
	
		public override bool Condition()
		{
			return DistanceSqrToEnemy() < _dangerDistanceSqr;
		}

		public float DistanceSqrToEnemy()
		{
			return (transform.position - enemy.position).sqrMagnitude;
		}
	}
}
