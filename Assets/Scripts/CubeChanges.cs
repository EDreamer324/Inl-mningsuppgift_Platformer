using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChanges : MonoBehaviour {

    InstantiateCubes listRef;

    void Start() {
        listRef = GetComponent<InstantiateCubes>();
    }
    void FixedUpdate() {
        StartCoroutine("ColliderToggle");
    }

    IEnumerator ColliderToggle() {
        List<int> tmpList = new List<int>();
        int index;

        while (true) {
            tmpList.Clear();
            for (int i = 0; i < Mathf.Floor(listRef.gameObjectList.Count / 5); i++) {
                index = listRef.gameObjectList.IndexOf(listRef.gameObjectList[Random.Range(0, listRef.gameObjectList.Count)]);
                tmpList.Add(index);
                
            }
            yield return null;
        }
        /*while(listRef.gameObjectList[Random.Range(0, listRef.gameObjectList.Count)].GetComponent<BoxCollider>().enabled == true) {
            for (int i = 0; i < listRef.gameObjectList.Count; i++) {
            index = listRef.gameObjectList.IndexOf(listRef.gameObjectList[Random.Range(0, listRef.gameObjectList.Count)]);
            listRef.gameObjectList[index].GetComponent<BoxCollider>().enabled = false;
            Debug.Log("Collider off for " + index); 
            }
            for (int i = 0; i < listRef.gameObjectList.Count; i++) {
            index = listRef.gameObjectList.IndexOf(listRef.gameObjectList[Random.Range(0, listRef.gameObjectList.Count)]);
            listRef.gameObjectList[index].GetComponent<BoxCollider>().enabled = true;
            Debug.Log("Collider on for " + index); 
            }
        }
        yield return null;*/
    }
    void OnDestroy(){listRef.gameObjectList.Clear();}
}