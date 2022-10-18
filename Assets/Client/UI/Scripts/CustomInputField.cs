using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CustomInputField : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _input;
    [SerializeField]
    private TextMeshProUGUI _label;

    public string InputText { get => _input.text; set => _input.text = value; }
    public float InputValue => float.Parse(_input.text);
}
