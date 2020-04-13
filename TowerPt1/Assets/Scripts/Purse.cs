using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purse : MonoBehaviour
{
    public int health = 3;
    public int purseTracker = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnMouseDown(){
        health--;
        Debug.Log (health);
        if(health ==0){
            Debug.Log ("Yay Points");
            purseTracker+=50;
            Destroy (gameObject);
        }
    }
}
