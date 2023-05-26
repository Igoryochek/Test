using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;
    [SerializeField] private Vector3 _offset;

    private Camera _camera;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;

    }
    private void Start()
    {
        _camera = Camera.main;
        _slider.transform.position = _camera.WorldToScreenPoint(transform.parent.position + _offset);
    }

    private void Update()
    {
        _slider.transform.position = _camera.WorldToScreenPoint(transform.parent.position + _offset);
    }
    private void OnHealthChanged(float count)
    {
        _slider.value = count;
    }
}
