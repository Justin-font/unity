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

    public List<Text> leftAnswers;
    public List<Text> questions;
    public List<Text> rightAnswers;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
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

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Door"))
        {
            other.gameObject.SetActive (false);
        }
    }
}
