using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    public GameObject bulbsContainer;
    private Lightbulb[] bulbs;

	// TODO: THESE ARE TEST FIELDS. ERASE THEM LATER. 
	public float TEST_WATER = 30f; 
	public int TEST_FRAMES = 20; 
	private int TEST_COUNTER = 0;

	private float _water; 
	public float Water {
		set { 
			_water = value;
			Electricity = _water * waterToElectricityRatio;
		}
		get { return _water;}
	}
	private float _electricity;
    public float Electricity {
        set {
			_electricity = value;
            SpreadElectricity(value);
        }
		get { return _electricity;  }
    }
	public float waterToElectricityRatio = 1f;

	// Use this for initialization
	void Start () {
        bulbs = bulbsContainer.GetComponentsInChildren<Lightbulb>();
    }
	
	// Update is called once per frame
	void Update () {

		//TODO: REMOVE IF STATEMENT (KEEP ITS BODY)
		if (++TEST_COUNTER % TEST_FRAMES == 0) {
			Water = TEST_WATER;
		}

    }

    private void SpreadElectricity(float amount) {
        int bulbsNum = bulbs.Length;
        float singleBulbElectricity = amount / bulbsNum;
        foreach (Lightbulb l in bulbs) {
            l.Electricity = singleBulbElectricity;
        }
    }
}
