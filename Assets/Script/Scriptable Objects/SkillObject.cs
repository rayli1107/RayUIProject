using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill Object")]
public class SkillObject : ScriptableObject
{
    public string skillName;
    public Sprite skillSprite;
    public int skillCooldown;
}
