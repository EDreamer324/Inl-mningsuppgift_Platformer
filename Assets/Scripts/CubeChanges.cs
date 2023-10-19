using UnityEngine;

public class CubeChanges : MonoBehaviour {

    InstantiateCubes listReference;

    void Start() {
        listReference = GetComponent<InstantiateCubes>();
    }
    void FixedUpdate() {
        /*
        for (int i = 0; i < listReference.gameObjectList.Count; i++) {
            listReference.gameObjectList[Random.Range(0, listReference.gameObjectList.Count)].GetComponent<BoxCollider>().enabled = false;
        }
        */
    }
}