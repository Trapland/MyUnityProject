using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;
    private float pipeSpawnPeriod = 4f;     // час у секундах між появою труб
    private float pipeCountdown;             // залишок часу до появи
    // Start is called before the first frame update
    void Start()
    {
        pipeCountdown = pipeSpawnPeriod;
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        pipeCountdown -= Time.deltaTime;
        if(pipeCountdown <= 0 )
        {
            pipeCountdown = pipeSpawnPeriod;
            SpawnPipe();
        }
        
    }
    private void SpawnPipe()
    {
        var pipe = GameObject.Instantiate( pipePrefab ); // ~ new PipePrefab
        pipe.transform.position = this.transform.position + Vector3.up * Random.Range(-1.4f, 1.4f);
    }
}
