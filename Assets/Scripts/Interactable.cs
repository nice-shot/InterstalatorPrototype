using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
    public GameObject glow;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && CanInteract(other.gameObject)) {
            glow.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            glow.SetActive(false);
        }
    }

    abstract public void Interact(GameObject player);

    virtual protected bool CanInteract(GameObject player) {
        return true;
    }
}
