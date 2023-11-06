using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GoToScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Closed Game");
    }
}
