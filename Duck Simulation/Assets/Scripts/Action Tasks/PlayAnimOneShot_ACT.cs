using System.Threading;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

	public class PlayAnimOneShot_ACT : ActionTask
	{
		public string animationName;
		public float animationLength;

		private float _timer;

		private int _animationHash;
		private int _noneHash;

		private Animator _animator;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			_animator = agent.GetComponent<Animator>();
			_animationHash = Animator.StringToHash(animationName);
			_noneHash = Animator.StringToHash("None");

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
			_animator.SetTrigger(_animationHash);

			_timer = animationLength;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			if (_timer <= 0)
			{
				_animator.SetTrigger(_noneHash);
				EndAction(true);
			}

			_timer -= Time.deltaTime;
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