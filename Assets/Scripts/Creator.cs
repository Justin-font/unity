using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Creator : MonoBehaviour
{
    public string gameName;
    public List<Question> questions;
    public GameObject gameNameInput;

    public string questionSubject;
    public string falseResponse;
    public string trueResponse;
    public GameObject myPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameName = "unamed";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void storeGameName(string text)
    {
        gameName = text;
    }

    public void storeQuestion(string text)
    {
        questionSubject = text;
    }


    public void storeFalseResponse(string text)
    {
        falseResponse = text;
    }

    public void storeTrueResponse(string text)
    {
        trueResponse = text;
    }






    public void addQuestion()
    {
        Question question = new Question();

        question.question = questionSubject;
        question.falseResponse = falseResponse;
        question.trueResponse = trueResponse;

        questions.Add(question);

        questionSubject = "";
        falseResponse = "";
        trueResponse = "";
            GameObject questionDetail = (GameObject)Instantiate(myPrefab);
            questionDetail.transform.SetParent(GameObject.Find("Grid_question").transform, false);
            questionDetail.transform.localScale = new Vector3(1, 1, 1);
           // questionDetail.SetSizeWithCurrentAnchors()
            //questionDetail.


    }

    public void generate()
    {

        print(questions);
        print(gameName);
        string jsonData = JsonUtility.ToJson(questions, true);

        DateTime dt = System.DateTime.Now;
        long time = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        File.WriteAllText(Application.dataPath + "/data/_" + gameName +  "_" +time + ".txt", jsonData);

        SceneManager.LoadScene(0);
    }


}
