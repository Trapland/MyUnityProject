using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private float pipeSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(pipeSpeed * Time.deltaTime * Vector3.left);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision detected: " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger detected: " + collision.gameObject.name);
    }
    /*
     * З точки зору взаємодії  між собою колайдери поділяються на фізичні та тригери
     * Фізичні колайдери "відпрацьовують" зіткнення засобами двигуна Юніті та
     * передають у скріпт подію OnCollisionEnter2D
     * Тригер-колайдери не беруть участь у двигуні, лише передають подію OnTriggerEnter2D
     *
     * Події взаємно виключні - або тригер, або колізія. Не обидві відразу,
     * навіть якщо один з колайдерів фізичний, а інший тригер.
     *
     * Подію отримує кожен скрипт, що бере участь у зіткненні. Якщо один з колайдерів фізичний,
     * інший тригер -- обидва отримують подію "Тригер"
     *
     * Хоча б один з учасників зіткнення повинен мати компонент RigidBody,
     * інакше колізії не детектуються.
     */
}
