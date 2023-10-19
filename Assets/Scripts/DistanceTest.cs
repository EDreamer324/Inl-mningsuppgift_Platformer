using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTest : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] private float collisionDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerController.transform.position) < collisionDistance) {
            Debug.Log("Entered Collision zone");
        }
    }
}
