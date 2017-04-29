using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBurstController : Interactable {
	public LightManager lightManager = null;
	public bool isCovered = false;
	public Sprite covered = null; 
	public Sprite leaking = null; 
	public SpriteRenderer sr = null; 
	public float totalWater = 100f; 
	public float leakingWater = 80f;

	void Awake(){
		sr = GetComponent<SpriteRenderer> ();
	}

    public override void Interact(GameObject player) {
		if (isCovered) {
			sr.sprite = leaking;
			lightManager.Water = totalWater - leakingWater;
		} else {
			sr.sprite = covered;
			lightManager.Water = totalWater;
		}
		isCovered = !isCovered;
    }

    override public bool CanInteract(GameObject player) {
		bool playerHasTape = player.transform.FindChild("Ducktape") != null;
		bool connectedToElectricityGenerator = (lightManager == null);
		return 
			(!isCovered && playerHasTape && connectedToElectricityGenerator) || 
			(isCovered && playerHasTape && connectedToElectricityGenerator);
    }
}
