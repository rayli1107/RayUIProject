using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem
{
    public Item item { get; private set; }
    public int count;

    public InventoryItem(Item item, int count = 1)
    {
        this.item = item;
        this.count = count;
    }
}

public class PlayerStat
{
    public enum STAT_TYPE
    {
        HP,
        MP,
        ATTACK,
        DEFENSE,
        MAGIC,
    };

    public string label { get; private set; }
    public STAT_TYPE stat_type { get; private set; }
    public int baseAttribute;
    public int bonusAttribute;
    private int multiplier;

    public int value => baseAttribute + bonusAttribute * multiplier;

    public PlayerStat(
        STAT_TYPE stat_type,
        string label,
        int baseAttribute,
        int multiplier)
    {
        this.label = label;
        this.baseAttribute = baseAttribute;
        this.multiplier = multiplier;
        bonusAttribute = 0;
        this.stat_type = stat_type;
    }
}

public class PlayerState
{
    private PlayerObject _playerObject;
    public Action callback;

    public int availableAttributes { get; private set; }
    private Dictionary<PlayerStat.STAT_TYPE, PlayerStat> _stats;

    public List<InventoryItem> weapons { get; private set; }
    public List<InventoryItem> armors { get; private set; }
    public List<InventoryItem> items { get; private set; }

    public string playerName => _playerObject.playerName;
    public Sprite playerSprite => _playerObject.playerSprite;
    public PlayerStat statHp => _stats[PlayerStat.STAT_TYPE.HP];
    public PlayerStat statMp => _stats[PlayerStat.STAT_TYPE.MP];
    public PlayerStat statAttack => _stats[PlayerStat.STAT_TYPE.ATTACK];
    public PlayerStat statDefense => _stats[PlayerStat.STAT_TYPE.DEFENSE];
    public PlayerStat statMagic => _stats[PlayerStat.STAT_TYPE.MAGIC];

    private const int _multiplierHP = 10;
    private const int _multiplierMP = 10;

    private List<InventoryItem> convertItems(List<Item> items)
    {
        List<InventoryItem> results = new List<InventoryItem>();
        foreach (Item item in items)
        {
            results.Add(new InventoryItem(item));
        }
        return results;
    }

    public PlayerState(
        System.Random random,
        PlayerObject playerObject,
        List<Item> weapons,
        List<Item> armors,
        List<Item> items)
    {
        _playerObject = playerObject;
        availableAttributes = 10;
        this.weapons = convertItems(weapons);
        this.armors = convertItems(armors);
        this.items = convertItems(items);
        foreach (InventoryItem item in this.items)
        {
            item.count = random.Next(5, 15);
        }

        _stats = new Dictionary<PlayerStat.STAT_TYPE, PlayerStat>();
        _stats[PlayerStat.STAT_TYPE.HP] = new PlayerStat(
            PlayerStat.STAT_TYPE.HP, "HP", _playerObject.hp, _multiplierHP);
        _stats[PlayerStat.STAT_TYPE.MP] = new PlayerStat(
            PlayerStat.STAT_TYPE.MP, "MP", _playerObject.mp, _multiplierMP);
        _stats[PlayerStat.STAT_TYPE.ATTACK] = new PlayerStat(
            PlayerStat.STAT_TYPE.ATTACK, "Attack", _playerObject.attack, 1);
        _stats[PlayerStat.STAT_TYPE.DEFENSE] = new PlayerStat(
            PlayerStat.STAT_TYPE.DEFENSE, "Defense", _playerObject.defense, 1);
        _stats[PlayerStat.STAT_TYPE.MAGIC] = new PlayerStat(
            PlayerStat.STAT_TYPE.MAGIC, "Magic", _playerObject.magic, 1);
    }

    public bool TryAllocateAttribute(PlayerStat.STAT_TYPE statType)
    {
        if (availableAttributes > 0)
        {
            --availableAttributes;
            ++_stats[statType].bonusAttribute;
            callback?.Invoke();
            return true;
        }
        return false;
    }

    public bool ReturnAttribute(PlayerStat.STAT_TYPE statType)
    {
        PlayerStat stat = _stats[statType];
        if (stat.bonusAttribute > 0)
        {
            --stat.bonusAttribute;
            ++availableAttributes;
            callback?.Invoke();
            return true;
        }
        return false;
    }

    public PlayerStat getStat(PlayerStat.STAT_TYPE statType)
    {
        return _stats[statType];
    }
}

public class GameController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Transform _rotateObject;
    [SerializeField]
    private Slider _speedSlider;
    [SerializeField]
    private PlayerObject _playerObject;
    [SerializeField]
    private List<Item> _weapons;
    [SerializeField]
    private List<Item> _armors;
    [SerializeField]
    private List<Item> _items;
#pragma warning restore 0649

    public System.Random Random { get; private set; }

    private int _speed;
    private PlayerState _playerState;

    private void Awake()
    {
        Random = new System.Random(System.Guid.NewGuid().GetHashCode());
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!GlobalGameConfig.isInitialized)
        {
            GlobalSceneManager.LoadMenuScene();
        }
        _speed = 100;
        _speedSlider.value = _speed;
        _playerState = new PlayerState(Random, _playerObject, _weapons, _armors, _items);
        GameUIController.Instance.Initialize(_playerState);
    }

    public void onSliderValueChange()
    {
        _speed = (int)_speedSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        _rotateObject.Rotate(Vector3.forward, _speed * Time.deltaTime);
    }


}
