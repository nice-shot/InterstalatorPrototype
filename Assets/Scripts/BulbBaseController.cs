using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbBaseController : MonoBehaviour {
    public GameObject glowEffect;

    // Use this for initialization
    void Start() {
    }
	
    // Update is called once per frame
    void Update() {
		
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            glowEffect.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            glowEffect.SetActive(false);
        }
    }

//    void OnTriggerStay2D(Collider2D other) {
//        Debug.Log("Player in me!");
//    }
}
