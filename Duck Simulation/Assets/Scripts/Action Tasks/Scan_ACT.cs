using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

	public class Scan_ACT : ActionTask
	{
		public BBParameter<Transform> output;
		public float initialRadius;
		public float radiusIncreaseRate;
		public LayerMask layerMask;

		private float _detectionRadius;

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
			_detectionRadius = initialRadius;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			Collider[] detectedColliders = Physics.OverlapSphere(agent.transform.position, _detectionRadius, layerMask);
			if (detectedColliders.Length > 0)
			{
				output.value = detectedColliders[0].transform;
				EndAction(true);
			}

			_detectionRadius += radiusIncreaseRate * Time.deltaTime;
			if (_detectionRadius >= 100f)
			{
				EndAction(false);
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