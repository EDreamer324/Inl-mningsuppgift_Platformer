using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChanges : MonoBehaviour {

    InstantiateCubes _listRef;
    [SerializeField] List<int> tempList = new List<int>();
    [SerializeField] Material mWithCollider, mWithoutCollider;
    public bool easy, medium, hard;
    int maxNumberOfTempObjects = 0;

    void Start() {
        _listRef = GetComponent<InstantiateCubes>();
        //StartCoroutine("ToggleCollider");

    }

    IEnumerator ToggleCollider() {
        int index; 
        maxNumberOfTempObjects = (int) Mathf.Floor(_listRef.gameObjectList.Count / 3);
        while (true) {
            
            while (tempList.Count < maxNumberOfTempObjects ) {
                index = _listRef.gameObjectList.IndexOf(_listRef.gameObjectList[Random.Range(0, _listRef.gameObjectList.Count)]);
                if (!tempList.Contains(index)) {
                    tempList.Add(index);
                    _listRef.gameObjectList[index].GetComponent<BoxCollider>().enabled = false;
                    _listRef.gameObjectList[index].GetComponent<MeshRenderer>().material = mWithoutCollider;
                }
                yield return null;
            }
            yield return new WaitForSecondsRealtime(5);
            for (int i = 0; i < _listRef.gameObjectList.Count; i++) {
                _listRef.gameObjectList[i].GetComponent<BoxCollider>().enabled = true;
                _listRef.gameObjectList[i].GetComponent<MeshRenderer>().material = mWithCollider;
                yield return null;
            }
            tempList.Clear();
            yield return new WaitForSecondsRealtime(5);
        }
    }
    void OnDestroy(){_listRef.gameObjectList.Clear();}
}