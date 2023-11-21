using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D body;
    private float forceFactor = 250f;

    private float continualForceFactor = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //body.AddForce(Vector2.right);
        if (Input.GetKeyDown(KeyCode.Space)) // на натискання
        {
            body.AddForce(Vector2.up * forceFactor);
        }
        if(Input.GetKey(KeyCode.W)) // "неперервний" - з кожен Update 
        {
            body.AddForce(Vector2.up *  continualForceFactor * Time.deltaTime);
        }
    }
}
