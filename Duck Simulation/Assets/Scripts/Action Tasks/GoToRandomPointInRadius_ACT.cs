using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions
{

	public class GoToRandomPointInRadius_ACT : ActionTask
	{
		public float radius;

		public BBParameter<Vector3> destination;

		private NavMeshAgent _navAgent;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			if (!destination.useBlackboard)
			{
				Debug.LogError("No connected blackboard variable for destination output. Please assign a blackboard reference.");
			}

			_navAgent = agent.GetComponent<NavMeshAgent>();

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
			//HACK: Conditional stops the action from setting a new destination twice after a short delay, which shouldn't be happening in the first place??
			//TODO: Figure out why the hell the first target is always near (0, 0, 0)
			if (!_navAgent.hasPath)
			{
				Vector2 randomPoint = (Vector2)agent.transform.position + Random.insideUnitCircle.normalized * radius;
				destination.value = new Vector3(randomPoint.x, 0f, randomPoint.y);
			}
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			if (!_navAgent.hasPath)
			{
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop()
		{

		}

		//Called when the task is paused.
		protected override void OnPause()
		{

		}
	}
}