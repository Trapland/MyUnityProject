using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    private Rigidbody2D body; // посилання на компонент

    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>(); // отримуємо посилання на компонент
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            body.AddForce(Vector2.up * 250);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            body.AddForce(Vector2.right * 100);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            body.AddForce(Vector2.left * 100);
        }
    }
}
