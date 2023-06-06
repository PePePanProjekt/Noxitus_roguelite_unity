using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBarScript : MonoBehaviour
{
    public Slider experienceSlider;

    public void SetMaxExperience(int exp)
    {
        experienceSlider.maxValue = exp;
        experienceSlider.value = exp;
    }

    public void SetExperience(int exp)
    {
        experienceSlider.value = exp;
    }
}
