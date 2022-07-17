using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
	GameObject cube;
	readonly Color[] colors = { Color.red, Color.white, Color.black, Color.gray, Color.green, Color.blue, Color.magenta };

	void Start()
	{
		cube = gameObject.transform.parent.gameObject;
		Debug.Log(cube.name);
	}

	public void ChangeColor()
	{
		//Get the Renderer component from the new cube
		var cubeRenderer = cube.GetComponent<Renderer>();

		//Call SetColor using the shader property name "_Color" and setting the color to red
		Color c;
		do
		{
			c = colors[Random.Range(0, colors.Length)];
		} while (c == cubeRenderer.material.color);
		cubeRenderer.material.SetColor("_Color", c);
	}
}
