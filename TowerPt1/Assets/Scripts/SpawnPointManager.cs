using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPointManager : MonoBehaviour
{
    public float r;
    public float tDp;
    public static int dp;
    void Start(){
        r = 1.6f;
        tDp = r;
        dp = 10;
    }
    void Update(){
        if(tDp <= 0)
        {dp++;tDp = r;}
        tDp -= Time.deltaTime;}
}
