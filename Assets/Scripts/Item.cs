using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable {
    public override void Interact(GameObject player) {
        transform.parent = player.transform;
        transform.localPosition = new Vector2(0, 0);
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Forground";
    }
}
