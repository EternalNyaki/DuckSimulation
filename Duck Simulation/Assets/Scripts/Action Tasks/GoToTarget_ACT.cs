using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions
{

	public class GoToTarget_ACT : ActionTask
	{
		public BBParameter<Transform> target;

		[Tooltip("Should the position of the target be sampled only once or continually")]
		public bool sampleOnce = false;

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
			destination.value = target.value.position;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			if (!sampleOnce)
			{
				destination.value = target.value.position;
			}

			if (_navAgent.hasPath && _navAgent.remainingDistance <= 0.01f)
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