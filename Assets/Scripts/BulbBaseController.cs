using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbBaseController : Interactable {
    public override void Interact(GameObject player) {
        Transform bulb = player.transform.FindChild("Lightbulb");
        if (bulb != null) {
            bulb.parent = transform;
            bulb.localPosition = new Vector2(0, -1f);
        }
    }

//    void OnTriggerStay2D(Collider2D other) {
//        Debug.Log("Player in me!");
//    }
}
