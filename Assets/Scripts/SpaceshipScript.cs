using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    public GameObject spaceShipBullet;
    public float speed = 50;
    void FixedUpdate(){
        float horizontalMovement = Input.GetAxisRaw ("Horizontal");
        GetComponent<Rigidbody2D> ().velocity = new Vector2 (horizontalMovement, 0) * speed;
    }
    void Update(){
        if (Input.GetButtonDown ("Shoot")) {
            Instantiate (spaceShipBullet, transform.position, Quaternion.identity);
        }
    }
}
