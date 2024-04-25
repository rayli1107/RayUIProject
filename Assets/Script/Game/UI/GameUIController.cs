using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private OptionsUIController _optionPanel;
    [SerializeField]
    private PlayerUIController _playerSimplePanel;
    [SerializeField]
    private PlayerUIController _playerDetailsPanel;
    [SerializeField]
    private InventoryUIManager _inventoryManager;
#pragma warning restore 0649

    public static GameUIController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void Initialize(PlayerState playerState)
    {
        _playerSimplePanel.Initialize(playerState);
        _playerDetailsPanel.Initialize(playerState);

        _inventoryManager.playerState = playerState;
        _inventoryManager.Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onOptionsButton()
    {
        _optionPanel.gameObject.SetActive(true);
    }
}
