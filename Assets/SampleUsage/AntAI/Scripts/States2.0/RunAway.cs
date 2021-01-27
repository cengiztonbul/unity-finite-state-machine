using FiniteStateMachine.Abstract;
using System.Collections.Generic;
using UnityEngine;

namespace AntAI.States
{
	public class RunAway : IState
	{
		GameObject gameObject;
		Transform transform;
		Transform enemy;

		public IFiniteStateMachine Context { get; set; }
		public List<ITransition> Transitions { get; set; }

		float speed;

		public RunAway(IFiniteStateMachine context, GameObject gameObject, Transform enemy, float speed)
		{
			Transitions = new List<ITransition>();

			this.gameObject = gameObject;
			this.Context = context;
			this.transform = gameObject.transform;
			this.enemy = enemy;
			this.speed = speed;
		}

		public void OnStart()
		{
			gameObject.GetComponent<Renderer>().material.color = new Color(0.8f, 0.2f, 0.3f);
		}

		public void Tick()
		{
			transform.position += RunDirection() * speed * Time.deltaTime;
		}

		public void OnExit() { }

		public Vector3 RunDirection()
		{
			return (transform.position - enemy.position).normalized;
		}

	}
}
