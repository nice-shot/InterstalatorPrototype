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

    new protected void Awake(){
        base.Awake();
		sr = GetComponent<SpriteRenderer> ();
	}

    public override void Interact(PlayerController player) {
		if (isCovered) {
			sr.sprite = leaking;
			lightManager.Water = totalWater - leakingWater;
		} else {
			sr.sprite = covered;
			lightManager.Water = totalWater;
		}
		isCovered = !isCovered;
    }

    override public bool CanInteract(PlayerController player) {
        bool playerHasTape = player.heldItem != null && player.heldItem.type == ItemType.Tape;
		bool connectedToElectricityGenerator = (lightManager == null);
		return 
			(!isCovered && playerHasTape && connectedToElectricityGenerator) || 
			(isCovered && playerHasTape && connectedToElectricityGenerator);
    }
}
