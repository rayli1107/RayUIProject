using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Image _imageNew;
    [SerializeField]
    private Image _imageAccepted;
    [SerializeField]
    private Image _imageFinished;
    [SerializeField]
    private TextMeshProUGUI _labelName;
    [SerializeField]
    private Button _buttonAccept;
#pragma warning restore 0649

    private QuestEntry _quest;
    public QuestEntry quest
    {
        get => _quest;
        set
        {
            if (_quest != null)
            {
                _quest.callback -= OnUpdate;
            }
            _quest = value;
            if (_quest != null)
            {
                _quest.callback += OnUpdate;
            }
            OnUpdate();
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

    public void OnUpdate()
    {
        _imageNew.gameObject.SetActive(
            quest != null && quest.questState == QuestEntry.QUEST_STATE.NEW);
        _imageAccepted.gameObject.SetActive(
            quest != null && quest.questState == QuestEntry.QUEST_STATE.ACCEPTED);
        _imageFinished.gameObject.SetActive(
            quest != null && quest.questState == QuestEntry.QUEST_STATE.FINISHED);
        _labelName.text = quest == null ? "" : quest.questName;
        _buttonAccept.gameObject.SetActive(
            quest != null && quest.questState == QuestEntry.QUEST_STATE.NEW);
    }

    public void OnAcceptButton()
    {
        quest.questState = QuestEntry.QUEST_STATE.ACCEPTED;
    }
}
