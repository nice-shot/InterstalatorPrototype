using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Item heldItem;
    public float moveSpeed = 240f;
	private float currSpeed = 0f;
	private Animator animator = null;
	private int animatorSpeed = 0;
	private SpriteRenderer sr; 

    protected Rigidbody2D body;
    private Interactable closestInteractable;


    virtual protected void Start() {
        body = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator> ();
		animatorSpeed = Animator.StringToHash ("speed");
		sr = GetComponent<SpriteRenderer> ();
    }

    // Handle movement and interaction input
    virtual protected void Update() {

        // Movement
        HandleMovement();

        // Interaction
        if (Input.GetButtonDown("Fire1") == true) {
            if (closestInteractable != null && closestInteractable.CanInteract(this)) {
                closestInteractable.Interact(this);
            }
        }

        // Drop off current item
        if (Input.GetButtonDown("Fire2") == true && heldItem != null) {
            DropItem();
        }
    }

    // Set closest interactable once we're in range
    void OnTriggerStay2D(Collider2D other) {
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

    virtual protected void DropItem() {
        heldItem.transform.SetParent(null);
        Vector3 pos = heldItem.transform.position;
        pos.y = -heldItem.spriteSize;
        heldItem.transform.position = pos;
        SpriteRenderer sprite = heldItem.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Interactable Item";

        heldItem = null;
    }

    virtual protected void HandleMovement() {
        Vector2 velocity = body.velocity;
        float movement = Input.GetAxis("Horizontal");
        velocity.x = movement * Time.deltaTime * moveSpeed;
        body.velocity = velocity;
		currSpeed = velocity.x;
		animator.SetFloat (animatorSpeed, velocity.x);
		sr.flipX = (currSpeed > 0.01f);
    }
}
