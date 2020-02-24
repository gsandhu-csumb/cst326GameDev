using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class LevelParserStarter : MonoBehaviour
{
    public string filename;
    
    public Text coinsKeeper;
    
    public Text gameTimer;
    
    public GameObject Rock;

    public GameObject Brick;

    public GameObject QuestionBox;

    public GameObject Stone;
    
    public LayerMask gameMask;
  
    public int coinCounter;
    
    public float gameStart;
    
    public float len = 225f;
    
    public Transform parentTransform;
    
    // Start is called before the first frame update
    
    void Start()
    {
        RefreshParse();
       // coinCounter = 10;
        //coinsKeeper.text = coinCounter.ToString();
    }
    
    void Update(){
        float gametime = 100f - Time.time;
        //float timeKeep = gametime;
        //Debug.Log(timeKeep);
        gameTimer.text = "Time \n" + gametime.ToString("f0");
        if(gametime <= 0){
            Debug.Log("Game Over");
            //Application.Quit();
        }
     if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitray;
            UnityEngine.Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitray, len, gameMask)){
                if (hitray.collider.name == "Brick(Clone)"){
                    Destroy(hitray.collider.gameObject);}
                if (hitray.collider.name == "QuestionMark(Clone)"){
                    coinCounter = coinCounter + 1;
                    coinsKeeper.text = "x" + coinCounter.ToString();
                }
                Debug.Log(hitray.collider.name);
            }
        }

    }


    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;
            //Vector3 thisVector = new Vector3(row, column,0);
            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                Vector3 thisVector = new Vector3(row, column, 0);
                foreach (var letter in letters)
                {
                    //Call SpawnPrefab
                    SpawnPrefab(letter, new Vector3(column,-row,0));
                    column = column + 1;
                }
                row = row +1;
            }

            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;
        //ToSpawn = Brick;
    
        switch (spot)
        {
            /*

            case 'b': Debug.Log("Spawn Brick"); break;
            case '?': Debug.Log("Spawn QuestionBox"); break;
            case 'x': Debug.Log("Spawn Rock"); break;
            case 's': Debug.Log("Spawn Rock"); break;
             */
            
            case 'b': ToSpawn =Brick; break;
            case '?': ToSpawn =QuestionBox; break;
            case 'x': ToSpawn =Rock; break;
            case 's': ToSpawn =Stone; break;

            //default: Debug.Log("Default Entered"); break;
            default: return;
                //ToSpawn = //Brick;       break;
        }

        ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        ToSpawn.transform.localPosition = positionToSpawn;
    }
    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
    
}
