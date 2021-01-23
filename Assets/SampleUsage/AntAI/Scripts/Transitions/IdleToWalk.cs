using FiniteStateMachine;
using UnityEngine;

public class IdleToWalk : Transition
{
	[SerializeField] float minIdleTime = 2;
	[SerializeField] float maxIdleTime = 5;
	
	private float _idleTime;
	private float _startTime;

	public override void ResetCondition()
	{
		_startTime = Time.time;
		_idleTime = Random.Range(minIdleTime, maxIdleTime);
	}

	public override bool Condition()
	{
		return Time.time - _startTime > _idleTime;
	}
}
