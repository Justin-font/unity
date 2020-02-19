using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour
{
    public List<Text> leftAnswers;
    public List<Text> questions;
    public List<Text> rightAnswers;

    // Start is called before the first frame update
    void Start()
    {
        int index = 0;

        Questions load_questions = Main.readJSON("Assets/data/_game 1_.txt");

        foreach (Question question in load_questions.questions)
        {
            if (index < leftAnswers.Count){
                if (Random.Range(0, 1) == 0){
                    leftAnswers[index].text = question.trueResponse;
                    rightAnswers[index].text = question.falseResponse;
                }
                else{
                    leftAnswers[index].text = question.falseResponse;
                    rightAnswers[index].text = question.trueResponse;
                }
                questions[index].text = question.question;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
