using UnityEngine;

public enum ItemType
{
    WEAPON,
    ARMOR,
    ITEM,
    QUEST,
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemSprite;
    public bool stackable = false;
}
