using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

	public class RandomTime_CDT : ConditionTask
	{
		public float minTime;
		public float maxTime;

		private float _timer;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable()
		{
			_timer = Random.Range(minTime, maxTime);
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable()
		{

		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck()
		{
			_timer -= Time.deltaTime;

			return _timer <= 0f;
		}
	}
}