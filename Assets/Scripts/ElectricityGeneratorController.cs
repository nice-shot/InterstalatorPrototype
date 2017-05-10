using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityGeneratorController : MonoBehaviour {
    public GameObject lightsContainer;
    private const float WATER_TO_VOLT = 1f;

    private float _incomingWater = 2f;
    /// <summary>
    /// Gets or sets the incoming water. Set also updates the distribution.
    /// </summary>
    /// <value>The incoming water.</value>
    public float incomingWater {
        get { return _incomingWater; }
        set {
            _incomingWater = value;
            updateDistribution();
        }
    }

    void Start() {
        updateDistribution();
    }

    /// <summary>
    /// Distributes the generated electricity across the lights
    /// </summary>
    public void updateDistribution() {
        BulbSocketController[] sockets = lightsContainer.GetComponentsInChildren<BulbSocketController>();
        int activeSockets = 0;
        foreach (BulbSocketController socket in sockets) {
            if (socket.hasBulb) { activeSockets++; }
        }

        float volts = incomingWater * WATER_TO_VOLT;
        float voltsPerSocket = volts / activeSockets;
        foreach (BulbSocketController socket in sockets) {
            socket.incomingVolt = voltsPerSocket;
        }
    }
}
