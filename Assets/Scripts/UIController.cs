using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider sliderStamina;

    public void SetStamina(float maxStamina, float currentStamina)
    {
        float newPosition = currentStamina / maxStamina;

        sliderStamina.value = newPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
