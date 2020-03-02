using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Bullet : MonoBehaviour {
    public float speed = 50;
    public Sprite deadAlien;
    private Rigidbody2D rigidBody;
    public int highScore = 0;
    public int score;
    string highScoreKey = "HighScore";
    void Start () {
        var hiscoretxt = GameObject.Find("hiScore").GetComponent<Text>();

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.up * speed;
        highScore = PlayerPrefs.GetInt(highScoreKey,0);
        hiscoretxt.text = highScore.ToString("0000");

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        var scoreTxt = GameObject.Find("Score").GetComponent<Text>();
        var hiscoretxt = GameObject.Find("hiScore").GetComponent<Text>();
        score = int.Parse(scoreTxt.text);
        
        if (col.tag == "Wall") {Destroy (gameObject);}
        if(col.gameObject.tag == "Alien")
        {
            if(col.gameObject.name == "Alien2" || col.gameObject.name == "Alien2 (1)" || col.gameObject.name == "Alien2 (2)" || col.gameObject.name == "Alien2 (3)"|| col.gameObject.name == "Alien2 (4)"|| col.gameObject.name == "Alien2 (5)"|| col.gameObject.name == "Alien2 (6)"){
                score += 500;
                speed++;
            }
            if(col.gameObject.name == "Alien3"|| col.gameObject.name == "Alien3 (1)" || col.gameObject.name == "Alien3 (2)" || col.gameObject.name == "Alien3 (3)"|| col.gameObject.name == "Alien3 (4)"|| col.gameObject.name == "Alien3 (5)"|| col.gameObject.name == "Alien3 (6)"){
                score += 250;
                speed++;

            }
            if(col.gameObject.name == "Alien4"|| col.gameObject.name == "Alien4 (1)" || col.gameObject.name == "Alien4 (2)" || col.gameObject.name == "Alien4 (3)"|| col.gameObject.name == "Alien4 (4)"|| col.gameObject.name == "Alien4 (5)"|| col.gameObject.name == "Alien4 (6)"){
              score += 100;
              speed++;


            }
            if(col.gameObject.name == "Alien5"|| col.gameObject.name == "Alien5 (1)" || col.gameObject.name == "Alien5 (2)" || col.gameObject.name == "Alien5 (3)"|| col.gameObject.name == "Alien5 (4)"|| col.gameObject.name == "Alien5 (5)"|| col.gameObject.name == "Alien5 (6)"){
              score += 50;
              speed++;

            }
            hiscoretxt.text = highScore.ToString("0000");
            scoreTxt.text = score.ToString("0000");
            /*if(score > PlayerPrefs.GetInt("Hiscore", 0)){
               PlayerPrefs.SetInt("hiScore", 0);
               hiscoretxt.text = score.ToString("0000");
            }*/
            col.GetComponent<SpriteRenderer> ().sprite = deadAlien;
            Destroy (gameObject);
            DestroyObject(col.gameObject, 0.5f);
        }
        if (col.tag == "Shield") {
            Destroy (gameObject);
            DestroyObject(col.gameObject);
        }
    }
     void OnBecameInvisible(){
        Destroy (gameObject);
    }
     void OnDisable(){
         if(score>highScore){
             PlayerPrefs.SetInt(highScoreKey, score);
             PlayerPrefs.Save();
             //PlayerPrefs.DeleteAll();
         }
     }
}
