using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChanges : MonoBehaviour {

    Instantiating _listRef;
    [SerializeField] List<int> tempList = new List<int>();
    [SerializeField] Material mWithCollider, mWithoutCollider;
    int maxNumberOfTempObjects = 0;

    void Start() {
        _listRef = GetComponent<Instantiating>();
        StartCoroutine("ToggleCollider");
    }

    IEnumerator ToggleCollider() {
        int index; 
        while (true) {
            maxNumberOfTempObjects = (int) Mathf.Floor(_listRef.SpawnedCubeList.Count / 3);
            while (tempList.Count < maxNumberOfTempObjects ) {
                index = _listRef.SpawnedCubeList.IndexOf(_listRef.SpawnedCubeList[Random.Range(0, _listRef.SpawnedCubeList.Count)]);
                if (!tempList.Contains(index)) {
                    tempList.Add(index);
                    _listRef.SpawnedCubeList[index].GetComponent<BoxCollider>().enabled = false;
                    _listRef.SpawnedCubeList[index].GetComponent<MeshRenderer>().material = mWithoutCollider;
                }
                yield return null;
            }
            yield return new WaitForSecondsRealtime(5);
            for (int i = 0; i < _listRef.SpawnedCubeList.Count; i++) {
                _listRef.SpawnedCubeList[i].GetComponent<BoxCollider>().enabled = true;
                _listRef.SpawnedCubeList[i].GetComponent<MeshRenderer>().material = mWithCollider;
                yield return null;
            }
            tempList.Clear();
            yield return new WaitForSecondsRealtime(5);
        }
    }
    void OnDestroy(){_listRef.SpawnedCubeList.Clear();}
}