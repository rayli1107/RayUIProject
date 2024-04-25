using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Image _imageFill;
    [SerializeField]
    private Image _imageSprite;
    [SerializeField]
    private Button _skillButton;
    [SerializeField]
    private TextMeshProUGUI _textHotkeyLabel;
#pragma warning restore 0649

    public SkillObject skillObject;
    public SkillContext skillContext;
    public int skillIndex;

    private void Awake()
    {
    }

    public void Initialize()
    {
        _imageSprite.sprite = skillObject == null ? null : skillObject.skillSprite;
        _imageFill.fillAmount = 0f;
        _textHotkeyLabel.text = skillIndex.ToString();
    }

    public void OnEnable()
    {
        Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _skillButton.interactable = skillContext == null ? false : skillContext.active;
        _imageFill.fillAmount =
            skillContext == null || skillObject == null ?
            0f :
            skillContext.cooldown / skillObject.skillCooldown;
    }

    public void onSkillButton()
    {
        skillContext.cooldown = skillObject.skillCooldown;
    }
}
