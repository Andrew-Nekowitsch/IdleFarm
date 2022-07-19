using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CropState : MonoBehaviour
{
	public CropEvent Event;

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	public void OnEvent(Crop x)
	{
		Event.Invoke(x);
	}
}
