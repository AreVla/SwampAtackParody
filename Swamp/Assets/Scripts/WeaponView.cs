using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{

    [SerializeField] private Text _label;
    [SerializeField] private Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> BuyButtonClick; 

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnButtonClick);
        _buyButton.onClick.AddListener(TryToBuy);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnButtonClick);
        _buyButton.onClick.RemoveListener(TryToBuy);
    }

    private void TryToBuy()
    {
        if (_weapon.IsBought) 
            _buyButton.interactable = false;
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _label.text = _weapon.WeaponInfo.Name;
        _price.text = _weapon.WeaponInfo.Price.ToString();
        _icon.sprite = _weapon.WeaponInfo.Icon;
    }

    private void OnButtonClick()
    {
        BuyButtonClick?.Invoke(_weapon, this);
    }
}
