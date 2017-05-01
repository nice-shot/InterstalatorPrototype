using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakController : Interactable {

    public TextMesh textBox;

    private bool _isSealed = false;
    private bool isSealed {
        get {
            return _isSealed;
        }
        set {
            _isSealed = value;
            if (_isSealed) {
                textBox.text = "Sealed Leak";
                // TODO: Add code to change electricity generator here.
            } else {
                textBox.text = "Leak";
            }
        }
    }

    void Start() {
        textBox = transform.GetComponentInChildren<TextMesh>();
    }

    public override void Interact(PlayerController player) {
        isSealed = !isSealed;
    }

    // The player needs ducktape to interact
    public override bool CanInteract(PlayerController player) {
        return player.heldItem != null && player.heldItem.type == ItemType.Tape;
    }
}
