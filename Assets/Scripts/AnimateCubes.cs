
using UnityEngine;

public class AnimateCubes : MonoBehaviour
{
    InstantiateCubes _listRef;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        _listRef = GetComponent<InstantiateCubes>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
