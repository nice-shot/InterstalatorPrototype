using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbSocketController : Interactable {
    public enum BulbState { None, Active, Broken };

    const float VOLT_TO_INTENSITY = 0.0125f;
    const float MAX_INTENSITY = 1f;

    public ElectricityGeneratorController generator;

    public BulbState bulbState = BulbState.None;
    public bool hasBulb { get { return bulbState == BulbState.Active; } }

    private TextMesh textBox;

    private float intensity;
    private float _incomingVolt;
    /// <summary>
    /// Gets or sets the incoming volt. The set operation also updates the light's intensity
    /// and prints it.
    /// </summary>
    /// <value>The incoming volt.</value>
    public float incomingVolt {
        get {
            return _incomingVolt;
        }
        set {
            _incomingVolt = value;
            intensity = _incomingVolt * VOLT_TO_INTENSITY;
            if (intensity > MAX_INTENSITY) {
                intensity = 0;
                bulbState = BulbState.Broken;
            }
            UpdateText();
        }
    }

    new protected void Awake() {
        base.Awake();
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
        bulbState = BulbState.Active;

        // Make the generator update changes. Should probably be some kind of event
        generator.updateDistribution();

        // Set text - Not necessary since updateDistribution does this
        //UpdateText();
    }

    override public bool CanInteract(PlayerController player) {
        return player.heldItem != null && player.heldItem.type == ItemType.Lightbulb && !hasBulb;
    }

    // Print how strong the light is - should be changed to some special graphic stuff
    private void UpdateText() {
        switch (bulbState) {
        case BulbState.None:
            textBox.text = "Empty Socket";
            break;
        case BulbState.Broken:
            textBox.text = "Light Broken";
            break;
        default:
            textBox.text = "Light Intensity: " + (int)(intensity * 100) + "%";
            break;
        }
    }
}
