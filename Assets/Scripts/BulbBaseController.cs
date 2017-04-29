using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbBaseController : Interactable {
    public override void Interact(GameObject player) {
        PlayerItemHandling playerController = player.GetComponent<PlayerItemHandling>();
        if (playerController.heldItemType == ItemType.Lightbulb) {
            Transform bulb = playerController.heldItem.transform;
            bulb.parent = transform;
            bulb.localPosition = new Vector2(0, -1f);
            SpriteRenderer sprite = bulb.gameObject.GetComponent<SpriteRenderer>();
            sprite.sortingLayerName = "Background Item";
            glow.SetActive(false);
            playerController.heldItemType = ItemType.None;
        }
    }

    override public bool CanInteract(GameObject player) {
        PlayerItemHandling playerController = player.GetComponent<PlayerItemHandling>();
        return playerController.heldItemType == ItemType.Lightbulb;
    }
}
