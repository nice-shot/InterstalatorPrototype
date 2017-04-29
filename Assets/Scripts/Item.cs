using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable {
    public ItemType type;

    public override void Interact(GameObject player) {
        transform.parent = player.transform;
        transform.localPosition = new Vector2(0, 0);
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Forground";

        PlayerItemHandling playerController = player.GetComponent<PlayerItemHandling>();
        playerController.heldItemType = type;
        playerController.heldItem = gameObject;
    }

    public override bool CanInteract(GameObject player) {
        PlayerItemHandling playerController = player.GetComponent<PlayerItemHandling>();
        return playerController.heldItemType == ItemType.None;
    }
}
