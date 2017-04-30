using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Item heldItem;
    public float moveSpeed = 240f;

    private Rigidbody2D body;
    private Interactable closestInteractable;

    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    // Handle movement and interaction input
    void Update() {

        // Movement
        Vector2 velocity = body.velocity;
        float movement = Input.GetAxis("Horizontal");
        velocity.x = movement * Time.deltaTime * moveSpeed;
        body.velocity = velocity;

        // Interaction
        if (Input.GetButtonDown("Fire1") == true) {
            if (closestInteractable != null && closestInteractable.CanInteract(this)) {
                closestInteractable.Interact(this);
            }
        }
    }

    // Set closest interactable once we're in range
    void OnTriggerEnter2D(Collider2D other) {
        Interactable otherInter = other.GetComponent<Interactable>();
        if (otherInter != null && otherInter.CanInteract(this)) {
            closestInteractable = otherInter;
        }
    }

    // Change the closest interactable once we're out of range
    void OnTriggerExit2D(Collider2D other) {
        Interactable otherInter = other.GetComponent<Interactable>();
        if (otherInter != null) {
            closestInteractable = null;
        }
    }
}
