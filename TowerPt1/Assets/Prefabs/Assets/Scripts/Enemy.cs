using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform follower;
    public Image healthBar;
    public LayerMask mask;
    public float speed;
    private int wpi;
    public float startHealth = 3;
    private int purseTracker = 0;
    public float length = 300f;
    public int health = 3;
    void Start(){
        speed = 1f;
        wpi = 0;
        follower = Waypoints.points[0];
    }
    void Update(){
        Vector3 dir = follower.position - transform.position;
              transform.Translate(dir.normalized*speed*Time.deltaTime);
              if (Vector3.Distance(transform.position, follower.position) <= 0.1f){NextWaypoint();}
    }
    void NextWaypoint(){
        if(wpi >= Waypoints.points.Length-1){
            Destroy(gameObject);
            return;}
        wpi++;
        follower = Waypoints.points[wpi];}
    void OnMouseDown(){
        health--;
        purseTracker = purseTracker + 50;
        if(health == 0){
            Debug.Log ("Purse: " + purseTracker);
            Destroy (gameObject);
        }
    }
}
