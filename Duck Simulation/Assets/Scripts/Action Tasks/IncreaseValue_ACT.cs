using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

	public class IncreaseValue_ACT : ActionTask
	{
		public BBParameter<float> value;
		public float increment;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			if (!value.useBlackboard)
			{
				Debug.LogError("No connected blackboard variable for destination output. Please assign a blackboard reference.");
			}


			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			value.value += increment * Time.deltaTime;
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