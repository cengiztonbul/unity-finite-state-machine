using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateMachine.Concrete;
using FiniteStateMachine.Abstract;
using AntAI.States;
using AntAI.Transitions;

public class Ant : MonoBehaviour
{
	private IFiniteStateMachine finiteStateMachine;

	private void Awake()
	{
		finiteStateMachine = new FiniteStateMachine.Concrete.FiniteStateMachine();
	}
	
	private void Start()
	{
		InitFSM();
	}

	private void InitFSM()
	{
		Walk walk = new Walk(gameObject, finiteStateMachine, new Vector2(-15, 15), new Vector2(-7, 7), 3);
		Idle idle = new Idle(gameObject, finiteStateMachine);
		
		ITransition walkToIdle = new WalkToIdle(gameObject, walk.target, walk, idle);
		ITransition idleToWalk = new AntAI.IdleToWalk(idle, walk, 1, 3);

		walk.Transitions.Add(walkToIdle);
		idle.Transitions.Add(idleToWalk);

		finiteStateMachine.ChangeState(idle);
	}

	private void Update()
	{
		finiteStateMachine.Tick();
		finiteStateMachine.CheckTransitions();
	}
}
