using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static bool end;
    
    public static float time;
    
    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        end = false;
        time = 0.0f;
        scoreText.text = "Temps : ";
    }

    // Update is called once per frame
    void Update()
    {
        if (!end){
            time += Time.deltaTime;
            scoreText.text = "Temps : " + time;
        }
    }

    public void Reset()
    {
    }

    public void NoMorePoints(){
        Main.Instance.GameOver();
    }
}
