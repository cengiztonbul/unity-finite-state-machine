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
		AntAI.States.RunAway runAway = new AntAI.States.RunAway(finiteStateMachine, gameObject, GameObject.FindGameObjectWithTag("Enemy").transform, 5);

		ITransition walkToIdle = new WalkToIdle(gameObject, walk.target, walk, idle);
		ITransition idleToWalk = new AntAI.Transitions.IdleToWalk(idle, walk, 1, 3);
		ITransition anyToRunAway = new AntAI.Transitions.AnyToRunAway(runAway, transform, GameObject.FindGameObjectWithTag("Enemy").transform, 5);
		ITransition runAwayToIdle = new AntAI.Transitions.RunAwayToIdle(runAway, idle, 7, transform, GameObject.FindGameObjectWithTag("Enemy").transform);
		
		walk.Transitions.Add(walkToIdle);
		idle.Transitions.Add(idleToWalk);
		runAway.Transitions.Add(runAwayToIdle);
		finiteStateMachine.TransitionsFromAnyState.Add(anyToRunAway);
		finiteStateMachine.ChangeState(idle);
	}

	private void Update()
	{
		finiteStateMachine.Tick();
	}
}
