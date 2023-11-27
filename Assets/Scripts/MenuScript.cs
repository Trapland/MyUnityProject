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
    private const string configFilename = "Assets/Files/config.json";
    private bool isShown;
    // Start is called before the first frame update
    void Start()
    {
        isShown = content.activeInHierarchy;
        ToggleMenu(isShown);
        if(LoadSettings())
        {
            controlWToggle.isOn = GameState.isWkeyEnabled;
            pipePeriodSlider.value = (6f - GameState.pipePeriod) / (6f - 2f);
            vitality.value = (2f - GameState.DPS) / (2f);
        }
        else
        {
            GameState.isWkeyEnabled = controlWToggle.isOn;
            SetPipePeriod(pipePeriodSlider.value);
            SetDPS(vitality.value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ToggleMenu(!isShown);
        }
    }
    private void SaveSettings()
    {
        System.IO.File.WriteAllText(configFilename, GameState.toJson());
    }

    private bool LoadSettings()
    {
        if(System.IO.File.Exists(configFilename))
        {
            GameState.fromJson(
            System.IO.File.ReadAllText(configFilename));
            return true;
        }
        return false;
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
        SaveSettings();
    }
    public void PipePeriodSliderChanged(Single value)
    {
        //Debug.Log("PipePeriodSliderChanged:");
        SetPipePeriod(value);
    }
    private void SetPipePeriod(Single sliderValue)
    {
        GameState.pipePeriod = 6f - (6f - 2f) * sliderValue;
        SaveSettings();

    }

    public void VitalitySliderChanged(Single value)
    {
        //Debug.Log("PipePeriodSliderChanged:");
        SetDPS(value);
    }

    private void SetDPS(Single sliderValue)
    {
        GameState.DPS = 2f - (2f) * sliderValue;
        SaveSettings();

    }
}
