using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ethanMovement : MonoBehaviour
{
    float speed =0;
    float rotSpeed=80;
    float gravity = 0;
    Vector3 moveDir = Vector3.zero;
    CharacterController controller;
    Animator anim;
    
    void OnTriggerEnter(Collider collison){
        if(collison.name == "Brick(Clone)"){
            Destroy(gameObject);
        }
        if(collison.name == "QuestionMark(Clone)"){
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrounded){
            if(Input.GetKey(KeyCode.RightArrow)){
                anim.SetInteger ("conditions", 1);
                moveDir = new Vector3 (1,0,0);
                transform.Rotate(0, 0, 0);
                moveDir *= speed;
                
            }
            if(Input.GetKeyUp(KeyCode.RightArrow)){
                anim.SetInteger ("conditions", 0);
                moveDir = new Vector3 (0,0,0);
                transform.Rotate(0, 0, 0);
            }
        }
       
            if(Input.GetKey(KeyCode.LeftArrow)){
                anim.SetInteger ("conditions", 1);
                moveDir = new Vector3 (-1,0,0);
                transform.Rotate(0, 180, 0);
                speed = 10;
                moveDir *= speed;
               // moveDir.x -= gravity * Time.deltaTime;
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow)){
                anim.SetInteger ("conditions", 0);
                moveDir = new Vector3 (0,0,0);
                transform.Rotate(0, 0, 0);
                speed=1;
                
            }
            if(Input.GetKey(KeyCode.LeftShift)){
                           anim.SetInteger ("conditions", 2);
                           //moveDir = new Vector3 (0,0,0);
                           speed=20;
            }
            if(Input.GetKeyUp(KeyCode.LeftShift)){
                           anim.SetInteger ("conditions", 0);
                           moveDir = new Vector3 (0,0,0);
                           speed=1;
            }
            if(Input.GetKey(KeyCode.Space)){
                                      anim.SetInteger ("conditions", 3);
                                      moveDir = new Vector3 (moveDir.x,10,0);

                       }
                       if(Input.GetKeyUp(KeyCode.Space)){
                                      anim.SetInteger ("conditions", 0);
                                      moveDir = new Vector3 (0,0,0);
                                      speed=1;
                       }
                     
            moveDir.x += gravity * Time.deltaTime;
        controller.Move (moveDir * Time.deltaTime);
    }
}

