using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbSocketController : Interactable {
    private bool hasBulb = false;

    public override void Interact(PlayerController player) {
        // Take bulb sprite from player and place on me
        Transform bulb = player.heldItem.transform;
        bulb.parent = transform;
        bulb.localPosition = new Vector2(0, -1f);
        SpriteRenderer sprite = bulb.gameObject.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Background Item";

        // Remove glow effect so we won't wait for the player to exit the collider
        glow.SetActive(false);

        // Remove the bulb from the player's logic and add mine
        player.heldItem = null;
        hasBulb = true;
    }

    override public bool CanInteract(PlayerController player) {
        return player.heldItem != null && player.heldItem.type == ItemType.Lightbulb && !hasBulb;
    }
}
