using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Alien : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    public float speed = 10;
    public Rigidbody2D rigiB;
    public Sprite strImg;
    public Sprite Imgalt;
    public Sprite shipExplode;
    public GameObject alienBullet;
    public float waitTimeBase = 3.0f;
    public float imgChange = 0.5f;
    public float frtMin = 1.0f;
    public float frtMax = 3.0f;
    void Start(){
        rigiB = GetComponent<Rigidbody2D>();
        rigiB.velocity = new Vector2 (1, 0) * speed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine (altAlien ());
        waitTimeBase = waitTimeBase + Random.Range (frtMin, frtMax);
    }
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.name == "Lw"){
                rigiB.velocity = new Vector2 (-1, 0) * speed;
                Vector2 position = transform.position;
                position.y -= 1;
                transform.position = position;
        }
        if (col.gameObject.name == "Rw"){
                rigiB.velocity = new Vector2 (1, 0) * speed;
                Vector2 position = transform.position;
                position.y -= 1;
                transform.position = position;
        }
        if (col.gameObject.tag == "Bullet"){
            Destroy (gameObject);
        }
    }
     public IEnumerator altAlien(){
        while (true) {
            if (spriteRenderer.sprite == strImg) {
                spriteRenderer.sprite = Imgalt;
            } else {spriteRenderer.sprite = strImg;}
            yield return new WaitForSeconds (imgChange);
        }
    }
     void FixedUpdate(){
        if (Time.time > waitTimeBase) {
            waitTimeBase = waitTimeBase + Random.Range (frtMin, frtMax);
            Instantiate (alienBullet, transform.position, Quaternion.identity);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            col.GetComponent<SpriteRenderer> ().sprite = shipExplode;
            Destroy (gameObject);
            DestroyObject (col.gameObject, 0.5f);
        }
    }
}
