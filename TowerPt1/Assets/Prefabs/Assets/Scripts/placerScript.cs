using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class placerScript : MonoBehaviour
{
    private Renderer rend;
    public Color color1;
    public Color color2;
    public Color color3;
    public bool isTrue;
    void Start(){
        isTrue = true;
        rend = GetComponent<Renderer>();}
    void OnMouseDown(){
            if (SpawnPointManager.dp >= 3){
                rend.material.color = color3;
                isTrue = true;
                SpawnPointManager.dp -= 3;
    }else{rend.material.color = color2;}}
    void OnMouseEnter(){
        if (!isTrue){rend.material.color = color1;}}
    void OnMouseExit(){
        if (!isTrue){rend.material.color = color2;}}
}
