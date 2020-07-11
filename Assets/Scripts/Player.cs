using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidBody;
    public int speed;
    public bool whiteKey = false;
    public enum dirCompass {N,E,S,W,NE,SE,NW,SW};
    public dirCompass facingDir = dirCompass.S;
    public Animator anim;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();   
        anim = GetComponent<Animator>();
    }


    void setCompassDir()
    {
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");
        if(hori > 0)
        {
            if(verti > 0)
            {
                Debug.Log("NE");
                facingDir = dirCompass.NE;
            }
            else if (verti < 0)
            {
                Debug.Log("SE");
                facingDir = dirCompass.SE;
            }
            else
            {
                Debug.Log("E");
                facingDir = dirCompass.E;
            }
        }
        else if(hori < 0)
        {
            if (verti > 0)
            {
                Debug.Log("NW");
                facingDir = dirCompass.NW;
            }
            else if (verti < 0)
            {
                Debug.Log("SW");
                facingDir = dirCompass.SW;
            }
            else
            {
                Debug.Log("W");
                facingDir = dirCompass.W;
            }
        }else
        {
            if (verti > 0)
            {
                Debug.Log("N");
                facingDir = dirCompass.N;
            }
            else if (verti < 0)
            {
                Debug.Log("S");
                facingDir = dirCompass.S;
            }
        }

    }

    void setCompassDir_OLD()
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
            anim.SetBool("Is_Walking_South", true);
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
            anim.SetBool("Walking_east", true);
        } else {
            anim.SetBool("Walking_east",false);
            anim.SetBool("Is_Walking_South", false);
        }
    }

    Vector3 getVFacing()
    {
        switch (facingDir)
        {
            case dirCompass.N:
                return transform.up;
            case dirCompass.E:
                anim.SetBool("Walking_east", true);
                return transform.right;
            case dirCompass.S:
                anim.SetBool("Is_Walking_South", true);
                return -transform.up;
            case dirCompass.W:
                return -transform.right;
            default:
                anim.SetBool("Walking_east",false);
                anim.SetBool("Is_Walking_South", false);
                return transform.up;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        setCompassDir();
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
                Interactable Inter = obj.collider.gameObject.GetComponent<Interactable>();
                if (Inter)
                {
                    Debug.Log("Interactable");
                    Inter.OnInteract(this.gameObject);
                }
            }
        }
    }
}
