using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D body;
    private float forceFactor = 250f;

    private float continualForceFactor = 1000f;

    private int scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        GameState.pipesPassed = 0;
        scoreValue = GameState.scoreValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreValue != GameState.scoreValue)
        {
            scoreValue = Convert.ToInt32(GameState.DPS) + Convert.ToInt32(GameState.isWkeyEnabled) + Convert.ToInt32(GameState.pipePeriod);
            GameState.scoreValue = scoreValue;
        }
        
        //body.AddForce(Vector2.right);
        if (Input.GetKeyDown(KeyCode.Space)) // на натискання
        {
            body.AddForce(Vector2.up * Time.timeScale * forceFactor);
        }
        if (Input.GetKey(KeyCode.D)) // на натискання
        {
            body.AddForce(Vector2.right * Time.timeScale * 1);
        }
        if (Input.GetKey(KeyCode.A)) // на натискання
        {
            body.AddForce(Vector2.left * Time.timeScale * 1);
        }
        if (Input.GetKey(KeyCode.W) && GameState.isWkeyEnabled) // "неперервний" - з кожен Update 
        {
            body.AddForce(Vector2.up *  continualForceFactor * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Transform parent = other.gameObject.transform.parent;
        if(parent != null && parent.gameObject.CompareTag("Pipe"))
        {
            //todo lose
        }
        else 
        {
            if (other.gameObject.CompareTag("Food"))
            {
                GameState.vitality = 1;
                GameObject.Destroy(other.gameObject);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Pipe"))
        {
            GameState.pipesPassed += scoreValue;
        }
    }
}
