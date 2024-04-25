using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player")]
public class PlayerObject : ScriptableObject
{
    public string playerName;
    public Sprite playerSprite;

    public int hp;
    public int mp;
    public int attack;
    public int defense;
    public int magic;
}
