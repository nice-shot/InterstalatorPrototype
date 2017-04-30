using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerItemHandling : MonoBehaviour {
    public ItemType heldItemType;
    public GameObject heldItem;
    private Interactable closestInteractable;

	// Use this for initialization
	void Start () {
        heldItemType = ItemType.None;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") == true) {
            if (closestInteractable != null) {
                closestInteractable.Interact(gameObject);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        Interactable otherInter = other.GetComponent<Interactable>();
        if (otherInter != null && otherInter.CanInteract(gameObject)) {
            closestInteractable = otherInter;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        Interactable otherInter = other.GetComponent<Interactable>();
        if (otherInter != null) {
            closestInteractable = null;
        }
    }
}
