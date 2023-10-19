using UnityEngine;

public class InteractionTest : MonoBehaviour {

    /*
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Object collided with");
    }
    */

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player triggered object");
        }
        //Debug.Log("Object triggered");
    }

    private void OnTriggerExit() {
        Destroy(gameObject);
    }
}