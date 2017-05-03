using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbSocketController : Interactable {
    const float VOLT_TO_INTENSITY = 0.0125f;
    const float MAX_INTENSITY = 1f;

    public ElectricityGeneratorController generator;

    public bool hasBulb = false;

    private TextMesh textBox;

    private float intensity;
    private float _incomingVolt;
    public float incomingVolt {
        get {
            return _incomingVolt;
        }
        set {
            _incomingVolt = value;
            intensity = _incomingVolt * VOLT_TO_INTENSITY;
            if (intensity > MAX_INTENSITY) {
                intensity = 0;
            }
            UpdateText();
        }
    }

    new protected void Start() {
        base.Start();
        textBox = transform.GetComponentInChildren<TextMesh>();
    }

    public override void Interact(PlayerController player) {
        // Take bulb sprite from player and place on me
        Transform bulb = player.heldItem.transform;
        bulb.parent = transform;
        bulb.localPosition = new Vector2(0, -1f);
        SpriteRenderer sprite = bulb.gameObject.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Background Item";

        // Remove glow effect so we won't wait for the player to exit the collider
        glow.SetActive(false);

        // Remove the bulb from the player's logic and add to mine
        player.heldItem = null;
        hasBulb = true;

        // Make the generator update changes
        generator.updateDistribution();

        // Set text - Not necessary since updateDistribution does this
        //UpdateText();
    }

    override public bool CanInteract(PlayerController player) {
        return player.heldItem != null && player.heldItem.type == ItemType.Lightbulb && !hasBulb;
    }

    private void UpdateText() {
        if (hasBulb) {
            textBox.text = "Light Intensity: " + intensity;
        } else {
            textBox.text = "Empty Socket";
        }
    }
}
