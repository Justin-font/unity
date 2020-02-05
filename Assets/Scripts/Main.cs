using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour
{
    public ScoreManager scoreManager;
    static Main _instance;
    
    public static Main Instance
    {
        get
        {
            if(_instance == null){
                _instance = GameObject.FindObjectOfType<Main>();
            }
            return _instance;
        }
    }

    public void GameOver()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
//        scoreManager.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchGame()
    {
        print("launch game ");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void StartGame()
    {
        print("start game ");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    public void BackToMenu()
    {
        SceneManager.LoadScene(0);

    }

    internal static Questions readJSON(String path)
    {
        print(path);
        String jsonString;
        jsonString = File.ReadAllText(path);
        print(jsonString);
        Questions questions = JsonUtility.FromJson<Questions>(jsonString);
        return questions;
    }



}
