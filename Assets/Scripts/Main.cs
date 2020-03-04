﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour
{
    public ScoreManager scoreManager;
    static Main _instance;
    public static String currentGamePath;
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
        currentGamePath = "";
;    }

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
    public void Creator()
    {
        print(" creator ");
        SceneManager.LoadScene(3);

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

    public void Import()
    {
        string file = EditorUtility.OpenFilePanel("Import game", "", "");
        if (file.EndsWith(".txt"))
        {
            string[] split = file.Split('/');
            print(split[split.Length - 1]);
            print("copy");
            FileUtil.CopyFileOrDirectory(file, Application.dataPath + "/data/"+split[split.Length-1]);
        }
    }

}
