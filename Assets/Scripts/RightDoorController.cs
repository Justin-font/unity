using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoorController : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("openRight", true);

            PlayerController pc = other.gameObject.GetComponent(typeof(PlayerController)) as PlayerController;

            if(pc.step < QuestionScript.leftAnswerIsTrue.Count && !QuestionScript.leftAnswerIsTrue[pc.step]){
                print("Bien joué !");
            }
            else{
                ScoreManager.time += 5.0f;
                print("Mauvaise réponse...");
            }

            Rigidbody rb = other.gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
            rb.Sleep();
            pc.step += 1;

            if(pc.step > 4){
                ScoreManager.end = true;
            }
        }
    }
}
