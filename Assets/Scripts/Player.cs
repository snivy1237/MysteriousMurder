using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidBody;
    public int speed;
    public bool whiteKey;
    public enum dirCompass {N,E,S,W,NE,SE,NW,SW};
    public dirCompass facingDir = dirCompass.S;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();   
    }



    void setCompassDir()
    {
        //Set Direction
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A))
            {
                facingDir = dirCompass.NW;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                facingDir = dirCompass.NE;
            }
            else
            {
                facingDir = dirCompass.N;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A))
            {
                facingDir = dirCompass.SW;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                facingDir = dirCompass.SE;
            }
            else
            {
                facingDir = dirCompass.S;
            }
        }else if(Input.GetKey(KeyCode.A))
        {
            facingDir = dirCompass.W;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            facingDir = dirCompass.E;
        }
    }

    Vector3 getVFacing()
    {
        switch (facingDir)
        {
            case dirCompass.N:
                return transform.up;
            case dirCompass.E:
                return transform.right;
            case dirCompass.S:
                return -transform.up;
            case dirCompass.W:
                return -transform.right;
            default:
                return transform.up;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        rigidBody.MovePosition(rigidBody.position + (inputVector * speed * Time.fixedDeltaTime));

    }

    void Update()
    {
        setCompassDir();
        //Interaction Call
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Press E");
            Vector3 faceDir = getVFacing();
            RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, faceDir, 1);
            Debug.DrawLine(transform.position, transform.position + faceDir * 1, Color.green, 0.1f);
            foreach (RaycastHit2D obj in hit)
            {
                Debug.Log(obj.collider.name);
                //Call Interact Method on Each interacted object
                Component Inter = obj.collider.gameObject.GetComponent<Interactable>();
                if (Inter)
                {
                    Debug.Log("Interactable");
                }
            }
        }
    }
}
