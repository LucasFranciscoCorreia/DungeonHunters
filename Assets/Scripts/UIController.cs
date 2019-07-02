using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider sliderStamina;
    public Text levelValue;

    public void SetStamina(float maxStamina, float currentStamina)
    {
        float newPosition = currentStamina / maxStamina;

        sliderStamina.value = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        levelValue.text = hero_script.GetCurrentXp().ToString() + " / " + PlayerPrefs.GetInt("maxScore");
    }
}
