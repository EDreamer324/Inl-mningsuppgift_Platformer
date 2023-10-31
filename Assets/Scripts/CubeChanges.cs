using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChanges : MonoBehaviour {

    InstantiateCubes listRef;
    [SerializeField] List<int> tempList = new List<int>();
    [SerializeField] Material mWithCollider, mWithoutCollider;

    void Start() {
        listRef = GetComponent<InstantiateCubes>();
        //StartCoroutine("ToggleCollider");

    }

    IEnumerator ToggleCollider() {
        int index;
        int maxNumberOfTempObjects = (int) Mathf.Floor(listRef.gameObjectList.Count / 2); 

        while (true) {
            
            while (tempList.Count < maxNumberOfTempObjects ) {
                index = listRef.gameObjectList.IndexOf(listRef.gameObjectList[Random.Range(0, listRef.gameObjectList.Count)]);
                if (!tempList.Contains(index)) {
                    tempList.Add(index);
                    listRef.gameObjectList[index].GetComponent<BoxCollider>().enabled = false;
                    listRef.gameObjectList[index].GetComponent<MeshRenderer>().material = mWithoutCollider;
                }
                yield return null;
            }
            yield return new WaitForSecondsRealtime(5);
            for (int i = 0; i < listRef.gameObjectList.Count; i++) {
                listRef.gameObjectList[i].GetComponent<BoxCollider>().enabled = true;
                listRef.gameObjectList[i].GetComponent<MeshRenderer>().material = mWithCollider;
                yield return null;
            }
            tempList.Clear();
            yield return new WaitForSecondsRealtime(5);
        }
    }
    void OnDestroy(){listRef.gameObjectList.Clear();}
}