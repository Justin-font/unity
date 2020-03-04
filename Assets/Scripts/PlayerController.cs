using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 jump;
    private float time_spent_asleep;

    public int speed;
    public int step;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        step = 0;
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
        rb.rotation = Quaternion.Euler(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
     
            rb.AddForce(jump * 3.0f, ForceMode.Impulse);
            isGrounded = false;
        }

        if(rb.IsSleeping()){
            time_spent_asleep += Time.deltaTime;
            print(time_spent_asleep);

            if (time_spent_asleep > 2.0f){
                time_spent_asleep = 0.0f;
                rb.WakeUp();
                print("Test waking up");
            }
        }
        else{
            if (time_spent_asleep != 0.0f){
                print("Test not sleeping");
                time_spent_asleep = 0.0f;
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Door"))
        {
        
        }
    }

    void OnDisable()
    {

    }
}
