using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class changeScene : MonoBehaviour
{
    public void changeToScene(int changeTheScene){
    SceneManager.LoadScene (changeTheScene);
    }
}
