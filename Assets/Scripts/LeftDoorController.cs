using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LeftDoorController : MonoBehaviour
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
            anim.SetBool("openLeft", true);

            PlayerController pc = other.gameObject.GetComponent(typeof(PlayerController)) as PlayerController;

            if(QuestionScript.leftAnswerIsTrue[pc.step]){
                print("Bien joué !");
            }
            else{
                print("Mauvaise réponse...");
            }

            other.gameObject.SetActive(false);
            Thread.Sleep(2000);
            other.gameObject.SetActive(true);
            pc.step += 1;
        }
    }
}
