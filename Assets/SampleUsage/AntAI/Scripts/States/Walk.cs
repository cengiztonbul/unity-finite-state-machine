using FiniteStateMachine;
using UnityEngine;

namespace AntAI
{

	public class Walk : State
	{
		[SerializeField] Vector2 horizontalBorders;
		[SerializeField] Vector2 verticalBorders;

		public Vector3 target;
		private Vector3 walkDirection;

		public float speed = 3;

		public override void OnStart()
		{
			GetComponent<Renderer>().material.color = new Color(0.6f, 0.5f, 0.2f);

			target = RandomPosition();
			walkDirection = (target - transform.position).normalized;
		}

		public override void Tick()
		{
			transform.position += walkDirection * Time.deltaTime * speed;
		}

		public Vector3 RandomPosition()
		{
			Vector3 position = new Vector3
			{
				x = Random.Range(horizontalBorders.x, horizontalBorders.y),
				y = Random.Range(verticalBorders.x, verticalBorders.y)
			};

			return position;
		}
	}
}
