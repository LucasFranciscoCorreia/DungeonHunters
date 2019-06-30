using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider sliderStamina;
    public Text levelText;

    public void SetStamina(float maxStamina, float currentStamina)
    {
        float newPosition = currentStamina / maxStamina;

        sliderStamina.value = newPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = hero_script.GetCurrentXp().ToString();
    }
}
