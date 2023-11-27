using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScript : MonoBehaviour
{
    private TMPro.TextMeshProUGUI clock;
    [SerializeField]                                // Два різні способи одержати
    private TMPro.TextMeshProUGUI pipesPassedTmp;   // доступ до елементів сцени
                                                    // (у т.ч. UI) - через link
    private float gameTime;                         // або через пошук

    [SerializeField]
    private Image vitalityIndicator;

    private float DPS;

    void Start()
    {
        // Знайти компонент TextMeshProUGUI у іншого GameObject "ClockTMP"
        clock = GameObject.Find("ClockTMP").GetComponent<TMPro.TextMeshProUGUI>();

        GameState.vitality = 1f; // повне життя на початку гри

        

        gameTime = 0;


    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        DPS = GameState.DPS / 20f * Time.deltaTime + 0.00001f;
    }
    private void LateUpdate()
    {
        int time = (int)gameTime;
        int hour = time / 3600;
        int minute = (time % 3600) / 60;
        int second = time % 60;
        int decisecond = (int)((gameTime - time) * 10);
        clock.text = $"{hour:00}:{minute:00}:{second:00}.{decisecond:0}";
        if(GameState.vitality > 0 )
        {
            GameState.vitality -= DPS;
        }
        else if( GameState.vitality < 0 )
        {
            GameState.vitality = 0;
            Debug.Log("GameState.vitality = " + GameState.vitality);
        }
        vitalityIndicator.fillAmount = GameState.vitality;
        pipesPassedTmp.text = GameState.pipesPassed.ToString();
    }
}
