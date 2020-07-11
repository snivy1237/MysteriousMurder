using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidBody;
    public int speed;
    public bool whiteKey;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.rotation.SetLookRotation(rigidBody.velocity);
        //transform.rotation.SetLookRotation(rigidBody.velocity);

        //Interaction Call
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Press E");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1);
            Debug.DrawLine(transform.position, transform.position+transform.right*1, Color.green,0.1f);
            Debug.Log(hit.collider.name);
        }

        Vector2 inputVector = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        rigidBody.MovePosition(rigidBody.position + (inputVector * speed * Time.fixedDeltaTime));    
    }
}
