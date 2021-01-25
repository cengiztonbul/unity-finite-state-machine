using UnityEngine;
using FiniteStateMachine.Abstract;

namespace AntAI.Transitions
{
    public class IdleToWalk : ITransition
    {
		public IState CurrentState { get; set; }
		public IState NextState { get; set; }
		
		private float _time = 0;
		private float _idleTime;
		private float _minIdleTime;
		private float _maxIdleTime;

		public IdleToWalk(IState currentState, IState nextState, float minIdleTime, float maxIdleTime)
		{
			this.CurrentState = currentState;
			this.NextState = nextState;
			_minIdleTime = minIdleTime;
			_maxIdleTime = maxIdleTime;
		}

		public bool Condition()
		{
            return Time.time - _time > _idleTime;
		}

		public void InitTransition()
		{
			_idleTime = Random.Range(_minIdleTime, _maxIdleTime);
			_time = Time.time;
		}
	}
}
