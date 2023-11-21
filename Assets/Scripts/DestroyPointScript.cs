using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        GameObject.Destroy( // знищення об'єкту - повне, не лише деактивація
            other           // колайдер (компонент об'єкту)
            .gameObject     // об'єкт цього колайдеру
            .transform      // батьківський transform
            .parent         // об'єкт цього transform - батьківський об'єкт
            .gameObject);   // 
    }
}
