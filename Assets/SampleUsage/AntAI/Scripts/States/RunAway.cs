using FiniteStateMachine;
using UnityEngine;

public class RunAway : State
{
	[SerializeField] float speed = 5;
	Transform enemy;

	private void Start()
	{
		enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
	}

	public override void OnStart()
	{
		GetComponent<Renderer>().material.color = new Color(0.8f, 0.2f, 0.3f);
	}

	public override void Tick()
	{
		transform.position += RunDirection() * speed * Time.deltaTime;
	}

	public Vector3 RunDirection()
	{
		return (transform.position - enemy.position).normalized;
	}
}
