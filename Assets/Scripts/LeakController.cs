using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakController : Interactable {

    public TextMesh textBox;
    public ElectricityGeneratorController generator;

    private const float PRESSURE_CHANGE = 20f;
    private bool _isSealed = false;
    private bool isSealed {
        get {
            return _isSealed;
        }
        set {
            _isSealed = value;
            if (_isSealed) {
                textBox.text = "Sealed Leak";
                generator.incomingWater += PRESSURE_CHANGE;
                // TODO: Add code to change electricity generator here.
            } else {
                textBox.text = "Leak";
                generator.incomingWater -= PRESSURE_CHANGE;
            }
        }
    }

    new protected void Awake() {
        base.Awake();
        textBox = transform.GetComponentInChildren<TextMesh>();
    }

    public override void Interact(PlayerController player) {
        isSealed = !isSealed;
        // Remove glow if the player can't stick it again
        if (player.heldItem == null) {
            glow.SetActive(false);
        }
    }

    // The player needs ducktape to interact
    public override bool CanInteract(PlayerController player) {
        if (isSealed) {
            return player.heldItem == null || player.heldItem.type == ItemType.Tape;
        }
        return player.heldItem != null && player.heldItem.type == ItemType.Tape;
    }
}
