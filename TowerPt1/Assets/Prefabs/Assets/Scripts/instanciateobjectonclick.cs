using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciateobjectonclick : MonoBehaviour {
 Ray ray;
 RaycastHit hit;
 public GameObject prefab;
 public int purseAmount = 200;
 void Start () {
     
 }
 void Update () {
     if(purseAmount > -200){
     ray=Camera.main.ScreenPointToRay(Input.mousePosition);
     
     if(Physics.Raycast(ray,out hit))
     {
         if(Input.GetKey(KeyCode.Mouse0))
         {
             GameObject obj=Instantiate(prefab,new Vector3(hit.point.x,hit.point.y,hit.point.z), Quaternion.identity) as GameObject;
             purseAmount -= 5;
         }
     }
     Debug.Log(purseAmount*-1);
     }
     else{
         Debug.Log("You've spent too much money: " + purseAmount*-1);
     }
 }}
