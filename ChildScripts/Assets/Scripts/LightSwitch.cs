// LightSwitch.cs
// A simple class for turning lights on/off.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

	// Publicly accessible variable, this can be reached by other scripts.
	public bool lightSwitch = false;
	Light myLight;

	void Start()
	{
		myLight = GetComponent<Light> ();		
	}

	void Update()
	{
		// Turn light on/off in accordance with lightSwitch
		myLight.enabled = lightSwitch;
	}
}
