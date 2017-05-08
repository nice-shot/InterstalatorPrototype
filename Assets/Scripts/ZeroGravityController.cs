using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravityController : MonoBehaviour {

    private bool isZeroG;
    private Rigidbody2D body;

	void Start () {
        body = GetComponent<Rigidbody2D>();
        isZeroG = body.gravityScale == 0;
	}
	
	void Update () {
        if ((body.gravityScale == 0) != isZeroG) {
            isZeroG = !isZeroG;
            ChangedToZeroG();
        }
	}

    private void ChangedToZeroG() {
        if (!isZeroG) {
            return;
        }
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
