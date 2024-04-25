using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUIManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private SkillUIController _prefabSkillPanel;
#pragma warning restore 0649

    public static SkillUIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddSkillPanel(SkillObject skillObject, SkillContext skillContext, int index)
    {
        SkillUIController skillPanel = Instantiate(_prefabSkillPanel, transform);
        skillPanel.skillObject = skillObject;
        skillPanel.skillContext = skillContext;
        skillPanel.skillIndex = index;
        skillPanel.gameObject.SetActive(true);
        skillPanel.Initialize();
    }
}
