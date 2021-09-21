using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    protected void OnValueChanged(float MaxValue, float CurrentValue)
    {
        _slider.value = CurrentValue / MaxValue;
    }

    protected void OnValueChanged(int MaxValue, int CurrentValue)
    {
        _slider.value = (float)CurrentValue / MaxValue;
    }
}
