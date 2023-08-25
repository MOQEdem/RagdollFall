using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private CharacterBodyPartController _bodyPartController;
    [SerializeField] private BodyPartCostBook _costBook;

    private float _moneyEarnedPerLevel;

    public float MoneyEarnedPerLevel => _moneyEarnedPerLevel;
    public float Amount { get; private set; }

    public Action<float> AmountChanged;

    private void OnEnable()
    {
        _bodyPartController.BodyPartDestroyed += OnBodyPartDestroy;
    }

    private void OnDisable()
    {
        _bodyPartController.BodyPartDestroyed -= OnBodyPartDestroy;
    }

    private void Start()
    {
        AmountChanged?.Invoke(Amount);
    }

    public void Add(int addedAmount)
    {
        if (addedAmount > 0)
        {
            Amount += addedAmount;
            AmountChanged?.Invoke(Amount);
        }
    }

    public bool IsAbleToSpend(int demandedAmount)
    {
        return demandedAmount < Amount;
    }

    public void Spend(int spendedAmount)
    {
        if (spendedAmount > 0 && spendedAmount <= Amount)
        {
            Amount -= spendedAmount;
            AmountChanged?.Invoke(Amount);
        }
    }

    private void OnBodyPartDestroy(CharacterBodyPart part, float delayTime)
    {
        Add(_costBook.GetBodyPartCost(part));
    }
}