using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

	public class Wait_ACT : ActionTask
	{
		public float waitTime;

		private float _timer;

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
			_timer = waitTime;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			_timer -= Time.deltaTime;

			if (_timer <= 0f)
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