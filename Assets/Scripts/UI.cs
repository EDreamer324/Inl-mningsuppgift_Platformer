using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour{    
    public TextMeshProUGUI _coinsCount;
    // Start is called before the first frame update
    void Start()
    {
        _coinsCount = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
       _coinsCount.text = Interactions.coins.ToString();
       if(scene.name == "GameFinished"){
        _coinsCount.text = "Your final score is: " + Interactions.coins.ToString();
       }
    }
}
