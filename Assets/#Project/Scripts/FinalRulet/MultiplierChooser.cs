using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class MultiplierChooser : MonoBehaviour
{
    [SerializeField] private TMP_Text _1_5Left;
    [SerializeField] private TMP_Text _2Left;
    [SerializeField] private TMP_Text _2_5Left;
    [SerializeField] private TMP_Text _3X;
    [SerializeField] private TMP_Text _1_5Right;
    [SerializeField] private TMP_Text _2Right;
    [SerializeField] private TMP_Text _2_5Right;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _blueColor;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private TMP_Text[] _texts;
    [SerializeField] private Wallet _wallet;

    private int _reward = 0;

    public float CurrentMultiplier { get; private set; }

    private void OnEnable()
    {
        //if (_wallet.CoinAmountOnLevel > 0)
        //    _reward = (int)(_wallet.CoinAmountOnLevel * _wallet.IncomeMultiplier);
        //else
        //    _reward = 50;
    }

    [UsedImplicitly]
    public void Set1_5X()
    {
        CurrentMultiplier = 1.5f;
        SetDefaultPreset();
        SetColorPreset(_1_5Left);
        float number = _reward * 1.5f;
        _moneyText.SetText("+" + Mathf.RoundToInt(number));
    }

    [UsedImplicitly]
    public void Set2X()
    {
        CurrentMultiplier = 2f;
        SetDefaultPreset();
        SetColorPreset(_2Left);
        float number = _reward * 2f;
        _moneyText.SetText("+" + Mathf.RoundToInt(number));
    }

    [UsedImplicitly]
    public void Set2_5X()
    {
        CurrentMultiplier = 2.5f;
        SetDefaultPreset();
        SetColorPreset(_2_5Left);
        float number = _reward * 2.5f;
        _moneyText.SetText("+" + Mathf.RoundToInt(number));
    }

    [UsedImplicitly]
    public void Set3X()
    {
        CurrentMultiplier = 3f;
        SetDefaultPreset();
        SetColorPreset(_3X);
        float number = _reward * 3f;
        _moneyText.SetText("+" + Mathf.RoundToInt(number));
    }

    [UsedImplicitly]
    public void Set1_5Right()
    {
        CurrentMultiplier = 1.5f;
        SetDefaultPreset();
        SetColorPreset(_1_5Right);
        float number = _reward * 1.5f;
        _moneyText.SetText("+" + Mathf.RoundToInt(number));
    }

    [UsedImplicitly]
    public void Set2Right()
    {
        CurrentMultiplier = 2f;
        SetDefaultPreset();
        SetColorPreset(_2Right);
        float number = _reward * 2f;
        _moneyText.SetText("+" + Mathf.RoundToInt(number));
    }

    [UsedImplicitly]
    public void Set2_5Right()
    {
        CurrentMultiplier = 2.5f;
        SetDefaultPreset();
        SetColorPreset(_2_5Right);
        float number = _reward * 2.5f;
        _moneyText.SetText("+" + Mathf.RoundToInt(number));
    }

    private void SetDefaultPreset()
    {
        foreach (var text in _texts)
        {
            text.color = _defaultColor;
            text.fontSizeMax = 34;
        }
    }

    private void SetColorPreset(TMP_Text text)
    {
        text.color = _blueColor;
        text.fontSizeMax = 50;
    }
}