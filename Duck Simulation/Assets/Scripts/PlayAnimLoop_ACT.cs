using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

	public class PlayAnimLoop_ACT : ActionTask
	{
		public string animationName;

		private Animator _animator;

		private int _animationHash;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			_animator = agent.GetComponent<Animator>();
			_animationHash = Animator.StringToHash(animationName);

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
			_animator.Play(_animationHash);
			if (!_animator.GetCurrentAnimatorStateInfo(0).loop)
			{
				_animator.StopPlayback();
				Debug.LogError("Given animation does not loop. Set it to loop in the Animator or use the PlayAnimOneShot action task");
			}

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{

		}

		//Called when the task is disabled.
		protected override void OnStop()
		{
			_animator.StopPlayback();
		}

		//Called when the task is paused.
		protected override void OnPause()
		{

		}
	}
}