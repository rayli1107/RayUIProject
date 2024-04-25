using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Button _buttonAdd;
    [SerializeField]
    private Button _buttonRemove;
    [SerializeField]
    private TextMeshProUGUI _textLabel;
    [SerializeField]
    private PlayerStat.STAT_TYPE _statType;
#pragma warning restore 0649

    private PlayerUIController _playerUIController;

    private void Awake()
    {
        _playerUIController = GetComponentInParent<PlayerUIController>();
    }

    public void UpdateValue()
    {
        if (_playerUIController != null && _playerUIController.playerState != null)
        {
            PlayerStat stat = _playerUIController.playerState.getStat(_statType);
            _textLabel.text = string.Format("{0}: {1}", stat.label, stat.value);
            _buttonAdd.gameObject.SetActive(_playerUIController.playerState.availableAttributes > 0);
            _buttonRemove.gameObject.SetActive(stat.bonusAttribute > 0);
        }
    }

    public void onAddButton()
    {
        Debug.Log("PlayerStatController.onAddButton");
        _playerUIController.playerState.TryAllocateAttribute(_statType);
    }

    public void onRemoveButton()
    {
        Debug.Log("PlayerStatController.onRemoveButton");
        _playerUIController.playerState.ReturnAttribute(_statType);
    }

    private void OnEnable()
    {
        UpdateValue();
    }
}
