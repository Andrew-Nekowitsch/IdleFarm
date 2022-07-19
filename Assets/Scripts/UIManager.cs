using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
	public TMP_Text Gold;
	public TMP_Text Gems;
	public TMP_Text Energy;

	private void Update()
	{
		//Gems.text = DateTime.Now.ToString();
	}

	public void ChangeGold(int x)
	{
		Gold.text = x.ToString();
	}
	public void ChangeGold(string x)
	{
		Gold.text = x;
	}

	public void ChangeEnergy(int e, int maxE)
	{
		Energy.text = $"{e.ToString()}/{maxE.ToString()}";
	}
	public void ChangeEnergy(string e, string maxE)
	{
		Energy.text = $"{e}/{maxE}";
	}
}
