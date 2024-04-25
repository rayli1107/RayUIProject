using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillContext
{
    public bool active => cooldown < 0f;
    public float cooldown;
}

public class SkillManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private SkillObject[] _skills;
    [SerializeField]
    private RectTransform _skillPanel;
    [SerializeField]
    private SkillUIController _prefabSkillController;
#pragma warning restore 0649
    private SkillContext[] _skillContexts;

    private void OnEnable()
    {
        _skillContexts = new SkillContext[_skills.Length];
        for (int i = 0; i < _skills.Length; ++i)
        {
            _skillContexts[i] = new SkillContext();
            _skillContexts[i].cooldown = -1f;

            SkillUIManager.Instance.AddSkillPanel(
                _skills[i], _skillContexts[i], i + 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (SkillContext skill in _skillContexts)
        {
            if (!skill.active)
            {
                skill.cooldown -= Time.deltaTime;
            }
        }
        
    }
}
