using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator a = gameObject.GetComponent<Animator>();
        a.SetBool ("open", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
