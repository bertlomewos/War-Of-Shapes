using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider sli;
    public Gradient gradient;
    public Image fill;

    public void maxHealth(float health)
    {
        sli.value = health;
        sli.maxValue = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void setHealth(float health)
    {
        sli.value = health;
        fill.color = gradient.Evaluate(sli.normalizedValue);
    }
}
