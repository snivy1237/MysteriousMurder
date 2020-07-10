using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidBody;
    public int speed;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {

        rigidBody.velocity = new Vector2(
            Input.GetAxis("Horizontal") * speed,
            Input.GetAxis("Vertical") * speed
        );
    }
}
