using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private OptionsUIController _optionPanel;
#pragma warning restore 0649

    // Start is called before the first frame update
    void Start()
    {
        GlobalGameConfig.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onNewGameButton()
    {
        GlobalSceneManager.LoadGameScene();
    }

    public void onOptionButton()
    {
        _optionPanel.gameObject.SetActive(true);
    }
}
