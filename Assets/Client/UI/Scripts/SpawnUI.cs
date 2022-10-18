using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUI : MonoBehaviour
{
    [SerializeField]
    private CustomInputField _speed;
    [SerializeField]
    private CustomInputField _delay;
    [SerializeField]
    private CustomInputField _lifeTime;
    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Button _stopButton;
    [SerializeField]
    private Button _changeButton;
    [SerializeField]
    private CubeSpawner _spawner;

    private void Awake()
    {
        _changeButton.onClick.AddListener(OnValuesChange);
        _startButton.onClick.AddListener(_spawner.StartSpawn);
        _stopButton.onClick.AddListener(_spawner.StopSpawn);
        SetTextFields();
    }

    private void SetTextFields()
    {
        _speed.InputText = _spawner.Speed.ToString();
        _delay.InputText = _spawner.Delay.ToString();
        _lifeTime.InputText = _spawner.LifeTime.ToString();
    }
    private void OnValuesChange()
    {
        var speed = _speed.InputValue;
        var delay = _delay.InputValue;
        var lifeTime = _lifeTime.InputValue;
        _spawner.ChangeValues(delay, speed, lifeTime);
    }
}
