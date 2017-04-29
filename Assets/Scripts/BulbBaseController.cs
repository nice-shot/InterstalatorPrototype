using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbBaseController : Interactable {
    public override void Interact(GameObject player) {
        if (player.transform.FindChild("Lightbulb")) {
            Debug.Log("GotLight!");
        }
    }

//    void OnTriggerStay2D(Collider2D other) {
//        Debug.Log("Player in me!");
//    }
}
