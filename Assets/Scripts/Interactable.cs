using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
    public GameObject glow;

    void Start() {
        if (glow == null) {
            Transform glowSearch = transform.FindChild("Glow");
            if (glowSearch != null) {
                glow = glowSearch.gameObject;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null && CanInteract(player)) {
            glow.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null) {
            glow.SetActive(false);
        }
    }

    abstract public void Interact(PlayerController player);

    virtual public bool CanInteract(PlayerController player) {
        return true;
    }
}
