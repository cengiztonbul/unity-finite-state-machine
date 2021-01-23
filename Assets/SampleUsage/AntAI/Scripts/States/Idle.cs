using UnityEngine;
using FiniteStateMachine;

namespace AntAI
{
	public class Idle : State
	{
		public override void OnStart()
		{
			GetComponent<Renderer>().material.color = new Color(0.3f, 0.6f, 0.6f);
		}
	}
}
