using UnityEngine;
using TMPro;

public class WalletView : MonoBehaviour
{
    [SerializeField] private WalletViewUI _ui;

    private TMP_Text _text;
    private Wallet _wallet;
    private WalletViewTextReduction _reduction = new WalletViewTextReduction();

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _text = _ui.GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _wallet.AmountChanged += OnCoinsAmountChanged;
    }

    private void OnDisable()
    {
        _wallet.AmountChanged -= OnCoinsAmountChanged;
    }

    private void OnCoinsAmountChanged(float newAmount)
    {
        _text.text = _reduction.GetReductedText(newAmount);
    }

    private class WalletViewTextReduction
    {
        private int firstStepValue = 1000;
        private int secondStepValue = 1000000;
        private int thirdStepValue = 1000000000;
        private int reductionStep = 1000;

        public string GetReductedText(float value)
        {

            if (value < firstStepValue)
                return value.ToString("0");
            else if (value < secondStepValue)
                return (value / reductionStep).ToString("0.0") + 'k';
            else if (value < thirdStepValue)
                return (value / (reductionStep * reductionStep)).ToString("0.0") + 'm';
            else
                return value.ToString("0.0");
        }
    }
}
