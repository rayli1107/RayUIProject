using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUIManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private QuestUIController _prefabQuestController;
#pragma warning restore 0649

    public void Initialize(List<QuestEntry> quests) {
        foreach (QuestEntry quest in quests)
        {
            QuestUIController questController = Instantiate(
                _prefabQuestController, _prefabQuestController.transform.parent);
            questController.quest = quest;
            questController.gameObject.SetActive(true);
        }
    }
}
