
using UnityEngine;

public class AnimationSync : MonoBehaviour
{
    GameObject player;
    [SerializeField]GameObject platform;

    // Update is called once per frame
    void OnTriggerEnter(Collider other){
        other.gameObject.transform.SetParent(transform);
        
    }
    void OnTriggerExit(Collider other){
        other.gameObject.transform.SetParent(null);
        if(platform != null){
            Destroy(platform);
        }
    }
}
