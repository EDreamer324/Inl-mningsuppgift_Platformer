using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    [SerializeField] GameObject originalCube;
    GameObject duplicatedCube;
    CubeChanges _Coroutineref;
    
    public List<GameObject> gameObjectList = new List<GameObject>();



    public int numberOfCubes;
    Vector3 spawnPosition;
    [SerializeField] float collisionCheckSphereRadius = 5;
    int debugSpawnedObjects;


    // Start is called before the first frame update
    void Start() {
        _Coroutineref = GetComponent<CubeChanges>();
        StartCoroutine("InstantiateObject");
    }



    IEnumerator InstantiateObject() {
        for (int i = 0; i < numberOfCubes; i++) {
            spawnPosition = new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), Random.Range(-30, 30));

            if (!Physics.CheckSphere(spawnPosition, collisionCheckSphereRadius)) {
                duplicatedCube = Instantiate(originalCube, spawnPosition, Random.rotation);
                gameObjectList.Add(duplicatedCube);
                debugSpawnedObjects++;
            }
            yield return null;
        }
        Debug.Log(debugSpawnedObjects);
        _Coroutineref.StartCoroutine("ToggleCollider");
    }
}
