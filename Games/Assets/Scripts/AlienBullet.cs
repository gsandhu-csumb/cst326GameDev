using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 
public class AlienBullet : MonoBehaviour {
    private Rigidbody2D rigiB;
    public Sprite shipExplode;
    public float speed = 20;
    void Start () {
        rigiB = GetComponent<Rigidbody2D>();
        rigiB.velocity = Vector2.down * speed;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Wall") {Destroy (gameObject);}
        if(col.gameObject.tag == "Player"){
            col.GetComponent<SpriteRenderer> ().sprite = shipExplode;
            Application.LoadLevel(Application.loadedLevel);
            Destroy (gameObject);
            DestroyObject(col.gameObject, 0.5f);
            SceneManager.LoadScene("End Menu");
        }
         if(col.tag == "Shield") {
            Destroy (gameObject);
            DestroyObject(col.gameObject);
        }
    }
     void OnBecameInvisible(){
        Destroy (gameObject);
    }
}
