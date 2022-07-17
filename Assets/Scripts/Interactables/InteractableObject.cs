using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interactable
{
	[SerializeField] private GameObject interaction;
	[SerializeField] private string animatorBoolName;
	private bool activated;

	protected override void Interact()
	{
		activated = !activated;
		if (interaction != null && !String.IsNullOrEmpty(animatorBoolName))
			interaction.GetComponent<Animator>().SetBool(animatorBoolName, activated);
	}
}
