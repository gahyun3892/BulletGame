using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;              
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    private bool isGameover;
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;               //생존 시간 갱신
            timeText.text = "Time: " + (int)surviveTime; //갱신한 생존시간을 표시

        }
        else
        {
            if (Input.GetKey(KeyCode.R))
            {    
                SceneManager.LoadScene("Cartoon Cat");  
            }

        }
    }
    public void EndGame()
    {

        isGameover = true;       
        gameoverText.SetActive(true); 
        float bestTime = PlayerPrefs.GetFloat("BestTime");
 
        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;  
          
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
     
        recordText.text = "Best Time: " + (int)bestTime;
    }

}
