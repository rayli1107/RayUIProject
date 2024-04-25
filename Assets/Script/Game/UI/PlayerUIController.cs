using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Image _imageFace;
    [SerializeField]
    private TextMeshProUGUI _textName;
    [SerializeField]
    private TextMeshProUGUI _textLevel;
    [SerializeField]
    private Slider _sliderHP;
    [SerializeField]
    private Slider _sliderMP;
    [SerializeField]
    private TextMeshProUGUI _textAvailableStats;
    [SerializeField]
    private PlayerStatController _prefabStatController;

#pragma warning restore 0649

    public PlayerState playerState { get; private set; }

    public void Initialize(PlayerState playerState)
    {
        if (this.playerState != null)
        {
            this.playerState.callback -= onUpdate;
        }
        this.playerState = playerState;

        if (_imageFace != null)
        {
            _imageFace.sprite = playerState.playerSprite;
        }

        if (_textName != null)
        {
            _textName.text = playerState.playerName;
        }

        if (this.playerState != null && gameObject.activeInHierarchy)
        {
            this.playerState.callback += onUpdate;
            onUpdate();
        }
    }

    private void onUpdate()
    {
        if (_textLevel != null)
        {
            _textLevel.text = "Lvl 1";
        }

        if (_sliderHP != null)
        {
            PlayerStat stat = playerState.getStat(PlayerStat.STAT_TYPE.HP);
            _sliderHP.minValue = 0;
            _sliderHP.maxValue = stat.value;
            _sliderHP.value = stat.value;
        }

        if (_sliderMP != null)
        {
            PlayerStat stat = playerState.getStat(PlayerStat.STAT_TYPE.MP);
            _sliderMP.minValue = 0;
            _sliderMP.maxValue = stat.value;
            _sliderMP.value = stat.value;
        }

        if (_textAvailableStats != null)
        {
            _textAvailableStats.text = string.Format("Stats: {0}", playerState.availableAttributes);
        }

        foreach (PlayerStatController statController in GetComponentsInChildren<PlayerStatController>(true))
        {
            statController.UpdateValue();
        }
    }

    private void OnEnable()
    {
        if (playerState != null)
        {
            playerState.callback += onUpdate;
            onUpdate();
        }
    }

    private void OnDisable()
    {
        if (playerState != null)
        {
            playerState.callback -= onUpdate;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
