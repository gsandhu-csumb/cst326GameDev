using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class endGame : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -=1 * Time.deltaTime;
        
        if(currentTime <= 0){
            currentTime =0;
            SceneManager.LoadScene("Start Menu");
        }
    }
}
