using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

	public class Wander_ACT : ActionTask
	{
		public float wanderInterval;
		public BBParameter<Vector3> destination;

		private float _timeSinceLastChangedTarget;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
			destination.value = new Vector3(Random.insideUnitCircle.x, 0f, Random.insideUnitCircle.y) * 50f;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			_timeSinceLastChangedTarget += Time.deltaTime;

			if (_timeSinceLastChangedTarget >= wanderInterval)
			{
				destination.value = new Vector3(Random.insideUnitCircle.x, 0f, Random.insideUnitCircle.y) * 50f;

				_timeSinceLastChangedTarget -= wanderInterval;
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