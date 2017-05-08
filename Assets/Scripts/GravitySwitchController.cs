using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitchController : Interactable {

    public Rigidbody2D[] bodysWithGravity;
    private bool gravityOn = true;

    public override void Interact(PlayerController player) {
        gravityOn = !gravityOn;

        // 1 is the basic gravity scale for all
        float gravityScale = gravityOn ? 1f : 0f;

        foreach (Rigidbody2D body in bodysWithGravity) {
            body.gravityScale = gravityScale;
        }
    }

    public override bool CanInteract(PlayerController player) {
        // Can only be interactable if the player doesn't hold any items
        return player.heldItem == null;
    }
}
