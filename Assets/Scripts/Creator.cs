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


    public List<string> questionsSubject;
    public List<string> falseResponse;
    public List<string> trueResponse;
    public GameObject myPrefab;

    public InputField inputfielTrue;
    public InputField inputfielFalse;
    public InputField inputfielQuestion;
    // Start is called before the first frame update
    void Start()
    {
        gameName = "unamed";
        questionsSubject = new List<string>(5);
        for (int i = 0; i < 5; i++)
            questionsSubject.Add("");


        falseResponse = new List<string>(5);
        for (int i = 0; i < 5; i++)
            falseResponse.Add("");
        trueResponse = new List<string>(5);
        for (int i = 0; i < 5; i++)
            trueResponse.Add("");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void storeGameName(string text)
    {
        gameName = text;
    }

    // 0
    public void storeQuestion(string text)
    {
        questionsSubject[0] = text;
    }

    public void storeFalseResponse(string text)
    {
        falseResponse[0] = text;
    }
    public void storeTrueResponse(string text)
    {
        trueResponse[0] = text;
    }
    // 1
    public void storeQuestion1(string text)
    {
        questionsSubject[1] = text;
    }

    public void storeFalseResponse1(string text)
    {
        falseResponse[1] = text;
    }
    public void storeTrueResponse1(string text)
    {
        trueResponse[1] = text;
    }// 2
    public void storeQuestion2(string text)
    {
        questionsSubject[2] = text;
    }

    public void storeFalseResponse2(string text)
    {
        falseResponse[2] = text;
    }
    public void storeTrueRespons2(string text)
    {
        trueResponse[2] = text;
    }// 3
    public void storeQuestion3(string text)
    {
        questionsSubject[3] = text;
    }

    public void storeFalseResponse3(string text)
    {
        falseResponse[3] = text;
    }
    public void storeTrueResponse3(string text)
    {
        trueResponse[3] = text;
    }// 4
    public void storeQuestion4(string text)
    {
        questionsSubject[4] = text;
    }

    public void storeFalseResponse4(string text)
    {
        falseResponse[4] = text;
    }
    public void storeTrueResponse4(string text)
    {
        trueResponse[4] = text;
    }
    //[Obsolete]
    //public void addQuestion()
    //{
    //    Question question = new Question();

    //    question.question = questionSubject;
    //    question.falseResponse = falseResponse;
    //    question.trueResponse = trueResponse;

    //       GameObject questionDetail = (GameObject)Instantiate(myPrefab);
    //       questionDetail.transform.SetParent(GameObject.Find("Grid_question").transform, false);
    //       questionDetail.transform.localScale = new Vector3(1, 1, 1);
    //    Text questionText = questionDetail.transform.FindChild("question").GetComponent<Text>();
    //    Text fasleText = questionDetail.transform.FindChild("false").GetComponent<Text>();
    //    Text trueText = questionDetail.transform.FindChild("true").GetComponent<Text>();
    //        questionText.text = questionSubject;
    //        fasleText.text = falseResponse;
    //         trueText.text = trueResponse;

    //    questions.Add(question);

    //    print("add" + questionSubject + falseResponse + trueResponse);

    //    inputfielTrue.Select();
    //    inputfielTrue.text = "";

    //    inputfielFalse.Select();
    //    inputfielFalse.text= "";

    //    inputfielQuestion.Select();
    //    inputfielQuestion.text = "";

    //    questionSubject = "";
    //    falseResponse = "";
    //    trueResponse = "";

    //}

    public void generate()
    {
        if (gameName == "unamed")
        {
        }
        else
        {

            print(questions.Count);
            print(gameName);

            for (int i = 0; i < 5; i++)
            {
                Question question = new Question();

                question.question = questionsSubject[i];
                question.falseResponse = falseResponse[i];
                question.trueResponse = trueResponse[i];
                print(question);
                questions.Add(question);

            }

            string jsonData = "";//);
            jsonData += "{";
            jsonData += "\"" + "questions" + "\"";
            jsonData += ": [";
            jsonData += JsonUtility.ToJson(questions[0]);
            questions.RemoveAt(0);
            foreach (Question q in questions)
            {
                jsonData += "," + JsonUtility.ToJson(q);
            }
            jsonData += "]}";
            print(jsonData);

            long time = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
            File.WriteAllText(Application.dataPath + "/data/_" + gameName + "_" + time + ".txt", jsonData);

            SceneManager.LoadScene(0);
        }
         
    }


}
