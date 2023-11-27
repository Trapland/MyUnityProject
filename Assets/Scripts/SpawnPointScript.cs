using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;
    [SerializeField] 
    private GameObject myPipePrefab;
    [SerializeField]
    private GameObject applePrefab;
    //private float pipeSpawnPeriod = 4f;     // час у секундах між появою труб
    private float pipeCountdown;             // залишок часу до появи труби
    private float foodCountdown;             // залишок часу до появи їжі
    // Start is called before the first frame update
    void Start()
    {
        pipeCountdown = GameState.pipePeriod;
        foodCountdown = pipeCountdown / 2f;
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        pipeCountdown -= Time.deltaTime;
        if(pipeCountdown <= 0 )
        {
            pipeCountdown = GameState.pipePeriod;
            foodCountdown = pipeCountdown / 2f;
            SpawnPipe();
        }
        if(foodCountdown > 0)
        {
            if (foodCountdown - Time.deltaTime <= 0)
            {
                SpawnFood();
                foodCountdown = 0;
            }
            else
            {
                foodCountdown -= Time.deltaTime;
            }
        }

    }

    private void SpawnFood()
    {
        if(Random.value < GameState.DPS / 2 + 0.2)
        {
            var apple = GameObject.Instantiate(applePrefab); // ~ new PipePrefab
            apple.transform.position = this.transform.position + Vector3.up * Random.Range(-4f, 4f);
        }
        
    }

    private void SpawnPipe()
    {
        if (Random.value < 0.5f)
        {
            var pipe = GameObject.Instantiate( pipePrefab ); // ~ new PipePrefab
            pipe.transform.position = this.transform.position + Vector3.up * Random.Range(-1.4f, 1.4f);
        }
        else
        {
            var pipe = GameObject.Instantiate(myPipePrefab); // ~ new my PipePrefab
            pipe.transform.position = this.transform.position + Vector3.up * Random.Range(-1.4f, 1.4f);
        }
        
    }
}
