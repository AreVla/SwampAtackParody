using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTheMoneyInShop : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.MoneyChanged+=OnMoneyChanged;
        _wallet.MoneyChanged?.Invoke(_wallet.CheckMoney());
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _text.text = money.ToString();
    }
}
