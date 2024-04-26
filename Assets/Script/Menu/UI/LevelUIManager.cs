using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private LevelUIController _prefabLevelUIController;
#pragma warning restore 0649

    public void AddLevel(LevelData level)
    {
        LevelUIController levelController = Instantiate(
            _prefabLevelUIController, _prefabLevelUIController.transform.parent);
        levelController.level = level;
        levelController.gameObject.SetActive(true);
    }
}
