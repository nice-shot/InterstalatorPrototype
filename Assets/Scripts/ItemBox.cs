using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : Interactable {

    public GameObject itemToSpawn;

    public override void Interact(PlayerController player) {
        // Place new object sprite on player
        GameObject itemObject = Instantiate(itemToSpawn, player.transform);
        itemObject.transform.localPosition = new Vector2(0, 0);
        SpriteRenderer sprite = itemObject.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Forground";

        // Add this item to the player logic
        player.heldItem = itemObject.GetComponent<Item>();

        // Remove glow effect
        glow.SetActive(false);
    }

    public override bool CanInteract(PlayerController player) {
        // Can only be interactable if the player doesn't hold any items
        return player.heldItem == null;
    }
}
