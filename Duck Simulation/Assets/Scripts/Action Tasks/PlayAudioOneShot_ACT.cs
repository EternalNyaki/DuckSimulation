using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

	public class PlayAudioOneShot_ACT : ActionTask
	{
		public AudioClip audioClip;

		private AudioSource _audioSource;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			_audioSource = agent.GetComponent<AudioSource>();
			if (_audioSource == null)
			{
				Debug.LogError("Agent does not have an Audio Source component. Please add one before using any audio-related actions");
			}

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
			_audioSource.PlayOneShot(audioClip);
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{

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