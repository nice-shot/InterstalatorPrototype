using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbBaseController : Interactable {
    public override void Interact(GameObject player) {
        Transform bulb = player.transform.FindChild("Lightbulb");
        if (bulb != null) {
            bulb.parent = transform;
            bulb.localPosition = new Vector2(0, -1f);
            SpriteRenderer sprite = bulb.gameObject.GetComponent<SpriteRenderer>();
            sprite.sortingLayerName = "Background Item";
            glow.SetActive(false);
        }
    }

    override protected bool CanInteract(GameObject player) {
        return player.transform.FindChild("Lightbulb") != null;
    }
}
