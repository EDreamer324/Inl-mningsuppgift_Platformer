using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    [SerializeField] GameObject originalCube;
    [SerializeField] public List<GameObject> gameObjectList = new List<GameObject>();



    [SerializeField] int numberOfCubes;
    Vector3 spawnPosition;
    [SerializeField] float collisionCheckSphereRadius = 5;
    float sphereRadius = 3;
    int debugSpawnedObjects;


    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < numberOfCubes; i++) {
            gameObjectList.Add(originalCube);
        }
        StartCoroutine("InstantiateObject");
    }



    IEnumerator InstantiateObject() {
        for (int i = 0; i < gameObjectList.Count; i++) {
            spawnPosition = new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), Random.Range(-30, 30));

            if (!Physics.CheckSphere(spawnPosition, collisionCheckSphereRadius)) {
                Instantiate(gameObjectList[i], spawnPosition, Random.rotation);
                debugSpawnedObjects++;
            }
        }
        Debug.Log(debugSpawnedObjects);
        yield return null;
    }
}
