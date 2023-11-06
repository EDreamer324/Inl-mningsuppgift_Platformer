using System.Collections.Generic;
using UnityEngine;

public class Instantiating : MonoBehaviour
{
    //Game Objects
    [SerializeField] GameObject originalCube;
    [SerializeField] GameObject coin;
    GameObject duplicatedCube;
    GameObject duplicatedCoin;
    //Lists
    public List<GameObject> SpawnedCubeList = new List<GameObject>();
    public List<GameObject> SpawnedCoinList = new List<GameObject>();
    //Vectors
    Vector3 cubeSpawnPosition;
    Vector3 coinSpawnRotation;
    Vector3 rotation = new Vector3(0,1,0);
    //Integers
    public int numberOfCubes;
    //Floats
    [SerializeField] float collisionCheckSphereRadius = 5;
    //References
    CubeChanges _coroutineRef;
    void Start(){
        _coroutineRef = GetComponent<CubeChanges>();
        SpawnCubes();
    }
    void SpawnCubes(){
        for (int i = 0; i < numberOfCubes; i++) {
            cubeSpawnPosition = new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), Random.Range(-30, 30));

            if (!Physics.CheckSphere(cubeSpawnPosition, collisionCheckSphereRadius)) {
                duplicatedCube = Instantiate(originalCube, cubeSpawnPosition, Quaternion.identity);
                SpawnedCubeList.Add(duplicatedCube);
            }
        }
        SpawnCoins();
    }
    void SpawnCoins(){
        coinSpawnRotation = new Vector3(90,0,0);
        int coinAmt = (int) Mathf.Floor(SpawnedCubeList.Count / 7);

        for(int i = 0; i < coinAmt; i++){
            Vector3 spawnPosition = new Vector3(SpawnedCubeList[i].transform.position.x, SpawnedCubeList[i].transform.position.y + 1.2f, SpawnedCubeList[i].transform.position.z);
            duplicatedCoin = Instantiate(coin, spawnPosition, Quaternion.Euler(coinSpawnRotation));
            duplicatedCoin.transform.SetParent(SpawnedCubeList[i].transform);

            SpawnedCoinList.Add(duplicatedCoin);
        }
        _coroutineRef.StartCoroutine("ToggleCollider");
    }
}
