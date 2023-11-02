using System.Collections;
using UnityEngine;

public class CoinsSceneManage : MonoBehaviour
{
    InstantiateCubes _listRef;
    [SerializeField]GameObject coin;
    void Start()
    {
        _listRef = GetComponent<InstantiateCubes>();
    }

    IEnumerator SpawnCoins(){
        yield return null;
        for(int i = 0; i < _listRef.gameObjectList.Count; i++){
            Instantiate(coin, _listRef.gameObjectList[i].transform.position, Quaternion.identity);
        }
    }
}
