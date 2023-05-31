using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int enemiesAlive = 0;
    public int round =0;

    public GameObject[] spawnPoints;


    public GameObject  enemyPrefab;
    public Text roundnumber;

    public GameObject endScreen;

    public Text roundSurvived;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive ==0)
        {
            round ++;
            NextWave(round);
            
            roundnumber.text="Round: "+round.ToString() ;
        }
    }

    public void NextWave(int round)
    {   

        for (int i = 0; i < round; i++)
        {
          GameObject spawnPoint = spawnPoints[Random.Range(0,spawnPoints.Length)];

          GameObject enemySpawned = Instantiate(enemyPrefab,spawnPoint.transform.position,Quaternion.identity);
          enemySpawned.GetComponent<enemyManager>().gameManager = GetComponent<GameManager>();
          enemiesAlive ++;
        }
        
    }
    public void Restart(){
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void EndGame(){

          Time.timeScale =0;
          Cursor.lockState = CursorLockMode.None;
          endScreen.SetActive(true);
          roundSurvived.text =round.ToString();
    }
}
