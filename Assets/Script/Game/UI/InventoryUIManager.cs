using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Toggle _tabWeapons;
    [SerializeField]
    private Toggle _tabArmors;
    [SerializeField]
    private Toggle _tabItems;
    [SerializeField]
    private RectTransform _panelScroll;
    [SerializeField]
    private Button _buttonPrev;
    [SerializeField]
    private Button _buttonNext;
    [SerializeField]
    private TextMeshProUGUI _labelScroll;
#pragma warning restore 0649

    private ItemUIController[] _itemControllers;
    public PlayerState playerState;

    private List<InventoryItem> _currentInventoryItems;
    private int _currentPage;

    private void Awake()
    {
        _itemControllers = GetComponentsInChildren<ItemUIController>(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Initialize()
    {
        _tabWeapons.Select();
        showWeapons();
    }

    private void OnEnable()
    {
        Initialize();
    }

    public void onValueChange(Toggle toggle)
    {
        if (toggle.isOn)
        {
            if (toggle == _tabWeapons)
            {
                showWeapons();
            }
            if (toggle == _tabArmors)
            {
                showArmors();
            }
            if (toggle == _tabItems)
            {
                showItems();
            }
        }
    }

    private void showInventory(List<InventoryItem> inventoryItems)
    {
        _currentInventoryItems = inventoryItems;
        _currentPage = 0;
        showInventoryPage();
    }

    private void showInventoryPage()
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }
        foreach (ItemUIController item in _itemControllers)
        {
            item.item = null;
        }
        _panelScroll.gameObject.SetActive(false);

        if (_currentInventoryItems != null)
        {
            int startIndex = _currentPage * _itemControllers.Length;
            for (int i = 0; i + startIndex < _currentInventoryItems.Count && i < _itemControllers.Length; ++i)
            {
                _itemControllers[i].item = _currentInventoryItems[i + startIndex];
            }

            if (_currentInventoryItems.Count > _itemControllers.Length)
            {
                _panelScroll.gameObject.SetActive(true);
                int pageCount = (_currentInventoryItems.Count - 1) / _itemControllers.Length + 1;
                _buttonPrev.gameObject.SetActive(_currentPage > 0);
                _buttonNext.gameObject.SetActive(_currentPage + 1 < pageCount);
                _labelScroll.text = string.Format("{0} / {1}", _currentPage + 1, pageCount);
            }
        }
    }

    private void showWeapons()
    {
        showInventory(playerState == null ? null : playerState.weapons);
    }

    private void showArmors()
    {
        showInventory(playerState == null ? null : playerState.armors);
    }

    private void showItems()
    {
        showInventory(playerState == null ? null : playerState.items);
    }

    public void onPrevButton()
    {
        --_currentPage;
        showInventoryPage();
    }

    public void onNextButton()
    {
        ++_currentPage;
        showInventoryPage();
    }
}
