using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 jump;

    public int speed;
    public Text question1;
    public Text question2;
    public Text question3;
    public Text question4;
    public Text question5;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        question1.text = "";
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);

        rb.AddForce(movement);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
     
            rb.AddForce(jump * 3.0f, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
