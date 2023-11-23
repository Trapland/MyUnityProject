using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private Toggle controlWToggle;
    [SerializeField]
    private Slider pipePeriodSlider;
    [SerializeField]
    private Slider vitality;
    private bool isShown;
    // Start is called before the first frame update
    void Start()
    {
        isShown = content.activeInHierarchy;
        ToggleMenu(isShown);
        GameState.isWkeyEnabled = controlWToggle.isOn;
        SetPipePeriod(pipePeriodSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ToggleMenu(!isShown);
        }
    }
    private void ToggleMenu(bool isDisplayed)
    {
        if (isDisplayed)
        {
            isShown = true;
            content.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            isShown = false;
            content.SetActive(false);
            Time.timeScale = 1f;
        }

    }
    public void CloseButtonClick()
    {
        ToggleMenu(!isShown);
    }
    public void ControlToggleWChanged(Boolean value)
    {
        GameState.isWkeyEnabled = value;
    }
    public void PipePeriodSliderChanged(Single value)
    {
        //Debug.Log("PipePeriodSliderChanged:");
        SetPipePeriod(value);
    }
    private void SetPipePeriod(Single sliderValue)
    {
        GameState.pipePeriod = 6f - (6f - 2f) * sliderValue; 
    }
}
