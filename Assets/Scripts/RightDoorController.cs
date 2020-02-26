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

            if(!QuestionScript.leftAnswerIsTrue[pc.step]){
                print("Bien joué !");
            }
            else{
                print("Mauvaise réponse...");
            }
            pc.step += 1;
        }
    }
}
