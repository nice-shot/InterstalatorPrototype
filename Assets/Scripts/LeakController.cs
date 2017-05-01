using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakController : Interactable {
    public override void Interact(PlayerController player) {
        Debug.Log("You put duck tape on me!");
    }

    public override bool CanInteract(PlayerController player) {
        return player.heldItem != null && player.heldItem.type == ItemType.Tape;
    }
}
