using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerZeroG : PlayerController {
    public float zeroGSpeed = 10;
    private bool isZeroG;

    override protected void Start() {
        base.Start();
        isZeroG = body.gravityScale == 0;

    }

    override protected void Update() {
        if ((body.gravityScale == 0) != isZeroG) {
            isZeroG = !isZeroG;
            ChangedToZeroG();
        }
        base.Update();
    }

    override protected void HandleMovement() {
        if (body.gravityScale != 0) {
            base.HandleMovement();
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        body.AddForce(new Vector2(horizontal * zeroGSpeed, vertical * zeroGSpeed));
        body.AddTorque(-horizontal);
    }

    override protected void DropItem() {
        ZeroGravityItem zeroGItem = (ZeroGravityItem)heldItem;
        zeroGItem.mainItem.transform.SetParent(null);
        SpriteRenderer sprite = zeroGItem.mainItem.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Interactable Item";

        Rigidbody2D body = zeroGItem.mainItem.GetComponent<Rigidbody2D>();
        body.simulated = true;

        BoxCollider2D collider = zeroGItem.mainItem.GetComponent<BoxCollider2D>();
        collider.isTrigger = false;

        heldItem = null;
    }

    private void ChangedToZeroG() {
        if (!isZeroG) {
            body.rotation = 0;
            return;
        }
        // Reduce velocity to avoid flying to the other side
        Vector2 newInitialVelocity = body.velocity;
        newInitialVelocity.x *= 0.1f;
        body.velocity = newInitialVelocity;

        Debug.Log("Changing gravity");
        float verticalForce = Random.Range(8f, 15f);
        float horizontalForce = Random.Range(-4f, 4f);

        Vector2 forceUpwards = new Vector2(horizontalForce, verticalForce);
        Debug.Log("Adding upwards force: " + forceUpwards);
        body.AddForce(forceUpwards);

        float rotationForce = Random.Range(0.2f, 4f);
        Debug.Log("Adding rotation force: " + rotationForce);
        body.AddTorque(rotationForce);
    }
}
