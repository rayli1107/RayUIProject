using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private OptionsUIController _optionPanel;
    [SerializeField]
    private LevelUIManager _levelSelectPanel;
    [SerializeField]
    private LevelData[] _levels;
#pragma warning restore 0649

    // Start is called before the first frame update
    void Start()
    {
        GlobalGameConfig.Initialize();

        foreach (LevelData level in _levels)
        {
            _levelSelectPanel.AddLevel(level);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onNewGameButton()
    {
        //        GlobalSceneManager.LoadGameScene();
        _levelSelectPanel.gameObject.SetActive(true);
    }

    public void onOptionButton()
    {
        _optionPanel.gameObject.SetActive(true);
    }
}
