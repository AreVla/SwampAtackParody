using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCount : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        _spawner.WaveCountChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _spawner.WaveCountChanged -= OnValueChanged;
    }

    private void OnValueChanged(int wave)
    {
        wave++;
        _text.text = wave.ToString();
    }
}
