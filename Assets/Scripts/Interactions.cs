using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactions : MonoBehaviour
{
     PlayerMovement _playerMovement;
     public static int coins;
    void Start(){
        _playerMovement = GetComponent<PlayerMovement>();
    }
    void OnTriggerEnter(Collider other){
        if(other.tag == "Death"){
            SceneManager.LoadScene("DeathScreen", LoadSceneMode.Single);
            coins = 0;
        }
        if(other.tag == "Interactible"){
            Destroy(other.gameObject);
            coins++;
        }
        if(other.tag == "Finish"){
            SceneManager.LoadScene("GameFinished", LoadSceneMode.Single);
        }
    }
}
