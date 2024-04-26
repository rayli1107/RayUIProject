using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private RectTransform _panelUnlocked;
    [SerializeField]
    private RectTransform _panelLocked;
    [SerializeField]
    private Image _imageLevel;
    [SerializeField]
    private TextMeshProUGUI _labelLevel;
    [SerializeField]
    private Button[] _buttonStars;
#pragma warning restore 0649

    private LevelData _level;
    public LevelData level
    {
        get => _level;
        set { 
            _level = value;
            _panelLocked.gameObject.SetActive(_level.locked);
            _panelUnlocked.gameObject.SetActive(!_level.locked);
            if (!_level.locked)
            {
                _imageLevel.sprite = _level.levelImage;
                _labelLevel.text = _level.levelName;
                for (int i = 0; i < _buttonStars.Length; ++i)
                {
                    _buttonStars[i].interactable = i < _level.stars;
                }
            }
        }
    }

    public void onPlayButton()
    {
        GlobalSceneManager.LoadGameScene(level);
    }
}
