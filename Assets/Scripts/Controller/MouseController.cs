using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
	public void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 100f))
			{
				if (hit.transform != null)
				{
					Interactable i = hit.transform.gameObject.GetComponent<Interactable>();
					if (i != null)
						i.BaseInteract();
					Debug.Log(hit.transform.gameObject.name);
				}
			}
		}
	}
}
