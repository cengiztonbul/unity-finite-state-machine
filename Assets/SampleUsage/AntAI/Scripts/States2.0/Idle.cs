using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateMachine.Abstract;

namespace AntAI.States
{
	public class Idle : IState
	{
		public GameObject gameObject; 

		public IFiniteStateMachine Context { get; set; }
		public List<ITransition> Transitions { get; set; }
		
		public Idle(GameObject gameObject, IFiniteStateMachine context)
		{
			Transitions = new List<ITransition>();

			Context = context;
			this.gameObject = gameObject;
		}

		public void OnStart()
		{
			gameObject.GetComponent<Renderer>().material.color = new Color(0.3f, 0.6f, 0.6f);
		}

		public void OnExit()
		{
		}

		public void Tick()
		{
		}
	}
}
