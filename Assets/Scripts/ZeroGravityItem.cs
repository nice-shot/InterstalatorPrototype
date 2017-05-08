using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravityItem : Item {
    private GameObject mainItem;
    void Start() {
        mainItem = transform.parent.gameObject;
    }

    public override void Interact(PlayerController player) {
        // Place the item graphic at the center of the player
        mainItem.transform.parent = player.transform;
        mainItem.transform.localPosition = new Vector2(0, 0);
        SpriteRenderer sprite = mainItem.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Forground";

        // Deactivate the rigidbody
        Rigidbody2D body = mainItem.GetComponent<Rigidbody2D>();
        body.Sleep();

        // Add this item to the player logic
        player.heldItem = this;
    }
}
