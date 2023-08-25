using System;
using UnityEngine;

public class RoulettRewarder : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private MultiplierChooser _multiplierChooser;
    [SerializeField] private LevelEnder _levelEnder;
    [SerializeField] private Animator _animator;

    public void OnbuttonClick()
    {
        _animator.enabled = false;
        Invoke(nameof(TryWatchADs), 0.5f);
    }

    private void TryWatchADs()
    {

    }


    private void OnReward()
    {
        //   _wallet.AddReawardedCoins((int)(_wallet.CoinAmountOnLevel * _multiplierChooser.CurrentMultiplier));

        OnClose();
    }

    private void OnClose()
    {
        _levelEnder.OnNoThanks();
    }
}