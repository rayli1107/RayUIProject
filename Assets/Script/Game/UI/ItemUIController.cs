using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Image _itemImage;
    [SerializeField]
    private RectTransform _itemCountPanel;
    [SerializeField]
    private TextMeshProUGUI _itemCountText;
#pragma warning restore 0649

    private InventoryItem _item;
    public InventoryItem item
    {
        get => _item;
        set
        {
            _item = value;
            _itemImage.sprite = _item == null ? null : _item.item.itemSprite;
            _itemImage.enabled = _item != null;

            bool stackable = _item != null && _item.item.stackable;
            _itemCountPanel.gameObject.SetActive(stackable);
            _itemCountText.text = stackable ? _item.count.ToString() : "";
        }
    }
}
