using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPointManager : MonoBehaviour
{
    public static int dp;
    public float timeu;
    public float rate;
    void Start(){
        timeu = rate;
        rate = 1.6f;
        dp = 12;
    }
    void Update(){
        if(timeu <= 0){
            dp++;
            timeu = rate;
        }
        timeu -= Time.deltaTime;
    }
}
