using FiniteStateMachine;
using UnityEngine;

public class RunAwayToIdle : Transition
{
	[SerializeField] Transform enemy;

	public float safeDistance = 10;
	private float safeDistanceSqr;
	
	private void Start()
	{
		enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
		safeDistanceSqr = safeDistance * safeDistance;
	}

	public override bool Condition()
	{
		return DistanceSqrToEnemy() > safeDistanceSqr;
	}

	public float DistanceSqrToEnemy()
	{
		return (currentState.transform.position - enemy.position).sqrMagnitude;
	}
}
