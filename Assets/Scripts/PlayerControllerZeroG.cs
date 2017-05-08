using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerZeroG : PlayerController {
    override protected void DropItem() {
        ZeroGravityItem zeroGItem = (ZeroGravityItem)heldItem;
        zeroGItem.mainItem.transform.SetParent(null);
        SpriteRenderer sprite = zeroGItem.mainItem.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Interactable Item";

        Rigidbody2D body = zeroGItem.mainItem.GetComponent<Rigidbody2D>();
        body.simulated = true;

        BoxCollider2D collider = zeroGItem.mainItem.GetComponent<BoxCollider2D>();
        collider.isTrigger = false;

        heldItem = null;
    }
}
