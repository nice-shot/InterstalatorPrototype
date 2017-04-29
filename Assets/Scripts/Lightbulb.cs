using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightbulb : MonoBehaviour {

    private Light _light; 
    public float maxPower = 20f;
    public float electricityToLightRatio = 10f;
	private float _electricity;
    public float Electricity {
		get { return _electricity; }
        set {
			_electricity = value;
			if (_electricity > maxPower) {
                TurnOff();
            } else {
                UpdateLight();
            }
        }
    }

	// Use this for initialization
	void Start () {
        _light = GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void TurnOff() {
        _light.intensity = 0f;
    }

    private void UpdateLight() {
		_light.intensity = Electricity / electricityToLightRatio;
    }

}
