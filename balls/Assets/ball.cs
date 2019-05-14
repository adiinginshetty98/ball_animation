using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float movespeed=200f;
    public float verforce = 20f;
    public Rigidbody rb;
    private Renderer rend;
    private Light malight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        malight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputx = Input.GetAxis("Horizontal");
        float inputz = Input.GetAxis("Vertical");

        float movex = inputx * movespeed * Time.deltaTime;
        float movez = inputz * movespeed * Time.deltaTime;

        //transform.Translate(movex,0f,movez);
        rb.AddForce(movex,0f,movez);



        float ver = verforce * Time.deltaTime;     //for vertical movement.
        if(Input.GetKey("e"))
        {
            rb.AddForce(0f,ver,0f);
        }
        if (Input.GetKey("q"))
        {
            rb.AddForce(0f, -ver, 0f);
        }

        if(Input.GetMouseButton(0))
        {
            rb.AddForce(ver, ver, ver);
        }
        if (Input.GetMouseButton(1))
        {
            rb.AddForce(-ver, -ver, -ver);
        }
    }



    void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "wall1")
        {
            rend.material.color = Color.red;
            malight.color = Color.red;
        }
        else if (col.collider.name == "wall2")
        {
            rend.material.color = Color.yellow;
            malight.color = Color.yellow;
        }
        else if (col.collider.name == "wall3")
        {
            rend.material.color = Color.cyan;
            malight.color = Color.cyan;
        }
        else if (col.collider.name == "wall4")
        {
            rend.material.color = Color.green;
            malight.color = Color.green;
        }
        else if (col.collider.name == "floor")
        {
            rend.material.color = Color.blue;
            malight.color = Color.blue;
        }
        else if (col.collider.name == "ceiling")
        {
            rend.material.color = Color.magenta;
            malight.color = Color.magenta;
        }
    }
}
