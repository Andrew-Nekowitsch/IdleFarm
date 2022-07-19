using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int Money = 50;
	public int Energy = 100;
	public int MaxEnergy = 100;
	public UIManager UI;

	private void Awake()
	{
		UI = GetComponent<UIManager>();
		UpdateUI();
	}

	public void OnCropSold(Crop x)
	{
		Debug.Log($"Sold {x.name}");
		ChangeMoney(x.SellPrice);
	}
	public void OnCropBought(Crop x)
	{
		Debug.Log($"Bought {x.name}");
		ChangeMoney(-x.SeedPrice);
	}

	public void SpendEnergy(int x)
	{
		x = Math.Abs(x);
		if (Energy < x) return;
		Energy -= x;
		UpdateUI();
	}
	public void RechargeEnergy(int x)
	{
		x = Math.Abs(x);
		if (Energy + x >= MaxEnergy)
		{
			Energy = MaxEnergy;
			UpdateUI();
			return;
		}
		Energy += x;
		UpdateUI();
	}

	public void OnMoneyChanged(int x)
	{
		ChangeMoney(x);
	}

	public void ChangeMoney(int x)
	{
		Money += x;
		UpdateUI();
	}

	private void UpdateUI()
	{
		UI.ChangeGold(Money);
		UI.ChangeEnergy(Energy, MaxEnergy);
	}
}
