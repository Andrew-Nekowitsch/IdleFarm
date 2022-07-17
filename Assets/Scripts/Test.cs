using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	[SerializeField] private int _numLoops;
	[SerializeField] private int maxLoops;
	private Timer _testTimer;
	[SerializeField] private float duration;

	private void Awake()
	{
		ResetState();
	}

	private void ResetState()
	{
		_numLoops = 0;
		CancelTestTimer();
	}

	public void StartTestTimer()
	{
		ResetState();

		// this is the important code example bit where we register a new timer
		_testTimer = Timer.Register(
			duration: this.duration,
			onUpdate: secondsElapsed =>
			{
				Debug.Log("Timer ran update callback: " + secondsElapsed + " seconds");
			},
			onComplete: () =>
			{
				_numLoops++;
				GetComponent<ColorChanger>().ChangeColor();
				if(_numLoops >= maxLoops)
				{
					CancelTestTimer();
				}
			},
			isLooped: true
			);
	}

	public void CancelTestTimer()
	{
		Timer.Cancel(_testTimer);
	}

	public void PauseTestTimer()
	{
		Timer.Pause(_testTimer);
	}

	public void ResumeTestTimer()
	{
		Timer.Resume(_testTimer);
	}
}