using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    Lightbulb,
    Tape
}

public class Item : Interactable {
    public ItemType type;
    public float spriteSize = 1;

    public override void Interact(PlayerController player) {
        // Place the item graphic at the center of the player
        transform.parent = player.transform;
        transform.localPosition = new Vector2(0, 0);
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Forground";

        // Add this item to the player logic
        player.heldItem = this;
    }

    public override bool CanInteract(PlayerController player) {
        // By default items can only be interactable if the player doesn't hold any
        return player.heldItem == null;
    }
}
