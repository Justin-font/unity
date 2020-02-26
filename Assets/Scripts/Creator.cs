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

    public InputField inputfielTrue;
    public InputField inputfielFalse;
    public InputField inputfielQuestion;
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

    [Obsolete]
    public void addQuestion()
    {
        Question question = new Question();

        question.question = questionSubject;
        question.falseResponse = falseResponse;
        question.trueResponse = trueResponse;

           GameObject questionDetail = (GameObject)Instantiate(myPrefab);
           questionDetail.transform.SetParent(GameObject.Find("Grid_question").transform, false);
           questionDetail.transform.localScale = new Vector3(1, 1, 1);
        Text questionText = questionDetail.transform.FindChild("question").GetComponent<Text>();
        Text fasleText = questionDetail.transform.FindChild("false").GetComponent<Text>();
        Text trueText = questionDetail.transform.FindChild("true").GetComponent<Text>();
            questionText.text = questionSubject;
            fasleText.text = falseResponse;
             trueText.text = trueResponse;

        questions.Add(question);

        print("add" + questionSubject + falseResponse + trueResponse);

        inputfielTrue.Select();
        inputfielTrue.text = "";

        inputfielFalse.Select();
        inputfielFalse.text= "";

        inputfielQuestion.Select();
        inputfielQuestion.text = "";

        questionSubject = "";
        falseResponse = "";
        trueResponse = "";

    }

    public void generate()
    {
           
        print(questions.Count);
        print(gameName);

        string jsonData = "";//);
        jsonData += "{";
        jsonData += "\"" + "questions" + "\"";
         jsonData += ": [";
        jsonData += JsonUtility.ToJson(questions[0]);
        questions.RemoveAt(0);
        foreach (Question q in questions)
        {
            jsonData += ","+JsonUtility.ToJson(q);
        }
        jsonData += "]}";
        print(jsonData);

        long time = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        File.WriteAllText(Application.dataPath + "/data/_" + gameName +  "_" +time + ".txt", jsonData);

        SceneManager.LoadScene(0);
    }


}
