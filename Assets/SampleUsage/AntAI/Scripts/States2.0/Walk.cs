using FiniteStateMachine.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AntAI.States
{
	public class Walk : IState
	{
		public GameObject gameObject;
		public Transform transform;

		private Vector2 _horizontalBorders;
		private Vector2 _verticalBorders;

		public Transform target;
		private Vector3 walkDirection;
		public float _speed = 5;

		public IFiniteStateMachine Context { get; set; }
		
		public List<ITransition> Transitions { get; set; }
		
		public Walk(GameObject gameObject, IFiniteStateMachine context, Vector2 horizontalBorders, Vector2 verticalBorders, float speed)
		{
			Transitions = new List<ITransition>();

			this.gameObject = gameObject;
			this.transform = gameObject.transform;
			Context = context;
			_horizontalBorders = horizontalBorders;
			_verticalBorders = verticalBorders;

			GameObject targetObj = new GameObject();
			targetObj.name = "AntTarget";
			target = targetObj.transform;
		}

		public void OnExit()
		{
		}

		public void OnStart()
		{
			gameObject.GetComponent<Renderer>().material.color = new Color(0.6f, 0.5f, 0.2f);

			target.position = RandomPosition();
			walkDirection = (target.position - transform.position).normalized;
		}

		public void Tick()
		{
			transform.position += walkDirection * Time.deltaTime * _speed;
		}

		public Vector3 RandomPosition()
		{
			Vector3 position = new Vector3
			{
				x = Random.Range(_horizontalBorders.x, _horizontalBorders.y),
				y = Random.Range(_verticalBorders.x, _verticalBorders.y)
			};

			return position;
		}
	}
}
