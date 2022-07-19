using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
	[SerializeField]
	private List<CropState> GrowthStates;
	[SerializeField]
	private int CurrentState;
	public int SellPrice = 10;
	public int SeedPrice = 1;

	public void Start()
	{
		Initialize();
	}

	public void Initialize()
	{
		ResetState();
	}

	public void ResetState()
	{
		CurrentState = 0;
		foreach (CropState c in GrowthStates)
		{
			c.Hide();
		}
		GrowthStates[CurrentState].Show();
	}

	public void NextState()
	{
		if (CurrentState == GrowthStates.Count - 1)
		{
			ResetState();
			return;
		}

		GrowthStates[CurrentState].Hide();
		GrowthStates[++CurrentState].Show();
		GrowthStates[CurrentState].OnEvent(this);
	}
}