using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
	#region Looping
	[Title("Looping")]
	[SerializeField]
	private bool doesLoop;

	[ShowIfGroup("doesLoop")]
	public int numLoops, maxLoops;
	#endregion

	#region Length
	[Title("Length")]
	[SerializeField]
	private float duration;

	[ShowInInspector, Sirenix.OdinInspector.ReadOnly]
	[SerializeField]
	private float timeLeft;

	[ShowInInspector, Sirenix.OdinInspector.ReadOnly]
	[LabelText("Seconds Elapsed")]
	[SerializeField]
	private float elapsed;
	#endregion

	#region Hooks
	[Title("Hooks")]
	public UnityEvent OnEverySecond;

	[ShowIf("doesLoop")]
	public UnityEvent OnLoopComplete;

	[LabelText("X")]
	public int xSeconds;

	[ShowInInspector, Sirenix.OdinInspector.ReadOnly]
	[SerializeField]
	private bool xSecondsFlag = false;

	public UnityEvent OnXSecondsLeft;

	public UnityEvent OnComplete;
	#endregion

	private int numSeconds = 0;
	private TimerClass _timer;


	private void Awake()
	{
		ResetState();
	}

	private void ResetState()
	{
		numLoops = 0;
		if (maxLoops == 0)
			maxLoops = 1;
		xSecondsFlag = false;
		CancelTestTimer();
	}

	public void StartTestTimer()
	{
		ResetState();

		_timer = TimerClass.Register(
			duration: this.duration,
			onUpdate: secondsElapsed =>
			{
				timeLeft = (float)Math.Round(duration - secondsElapsed, 2);
				EverySecond(secondsElapsed);
				XSecondsLeft(secondsElapsed);
			},
			onComplete: () =>
			{
				LoopComplete();
				if (numLoops >= maxLoops)
					TimerComplete();
			},
			isLooped: doesLoop
			);
	}

	public void CancelTestTimer()
	{
		TimerClass.Cancel(_timer);
	}

	public void PauseTestTimer()
	{
		TimerClass.Pause(_timer);
	}

	public void ResumeTestTimer()
	{
		TimerClass.Resume(_timer);
	}

	private void TimerComplete()
	{
		numSeconds = 0;
		CancelTestTimer();
		OnComplete.Invoke();
		Debug.Log("Timer Complete");
	}

	private void LoopComplete()
	{
		numLoops++;
		OnLoopComplete.Invoke();
		Debug.Log(numLoops + " Loops");
	}

	private void EverySecond(float timeElapsed)
	{
		elapsed = (float)Math.Floor(timeElapsed + (numLoops * duration));
		if (elapsed > numSeconds)
		{
			numSeconds++;
			OnEverySecond.Invoke();
			Debug.Log(numSeconds + " Seconds");
		}
	}

	private void XSecondsLeft(float timeElapsed)
	{
		if (xSecondsFlag) return;
		if (timeElapsed + (numLoops * duration) >= (maxLoops * duration) - xSeconds)
		{
			xSecondsFlag = true;
			OnXSecondsLeft.Invoke();
			Debug.Log("xSecondsFlag Complete");
		}
	}
}