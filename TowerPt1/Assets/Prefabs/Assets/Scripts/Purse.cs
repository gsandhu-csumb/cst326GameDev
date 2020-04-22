using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purse : MonoBehaviour
{
    public int health = 3;
    public int purseTracker = 0;
    void OnMouseDown(){
        health--;
        Debug.Log (health);
        if(health ==0){
            
            purseTracker+=50;
            Destroy (gameObject);
        }
    }
}
