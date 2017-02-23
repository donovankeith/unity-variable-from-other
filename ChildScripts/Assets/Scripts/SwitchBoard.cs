// SwitchBoard.cs
// Makes this object Green if most lights tagged `LightSwitch` are turned on in their scripts.
// Otherwise, light is red.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBoard : MonoBehaviour {

	public string tagName = "LightSwitch";
	GameObject[] lightSwitchObjects;
	private Light thisLight;

	// Use this for initialization
	void Start () {
		// Retrieve all objects containing the LightSwitch.cs script, indicated by marking them with the tag `LightSwitch`
		lightSwitchObjects = GameObject.FindGameObjectsWithTag (tagName);
		thisLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		int countLightsOn = 0;

		// Add up all the lights that are turned on.
		foreach (GameObject lightObject in lightSwitchObjects) {
			LightSwitch lightSwitch = lightObject.GetComponent<LightSwitch> ();  // Notice that this is retrieving the script's class.

			bool lightOn = lightSwitch.lightSwitch;  // Retrieve the variable state from the other object's script.
			if (lightOn)
				countLightsOn++;
		}

		int numLights = lightSwitchObjects.Length;
		float percentOn = (float)countLightsOn / (float)numLights;  // Cast the ints as floats so that you get floating point averages.

		// Most lights are off.
		if (percentOn < 0.5f) {
			thisLight.color = Color.red;
		}

		// Most lights are on
		else {
			thisLight.color = Color.green;
		}

	}
}
