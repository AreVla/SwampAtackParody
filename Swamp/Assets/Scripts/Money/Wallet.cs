using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    private int _money;

    public UnityAction<int> MoneyChanged;

    private void Start()
    {
        AddMoney(500);
    }

    public void AddMoney(int money)
    {
        _money += money;
        MoneyChanged?.Invoke(_money);
    }

    public int CheckMoney()
    {
        return _money;
    }
}
