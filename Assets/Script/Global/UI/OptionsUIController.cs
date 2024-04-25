using UnityEngine;
using UnityEngine.UI;

public class OptionsUIController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Slider _volumeSlider;
#pragma warning restore 0649


    // Start is called before the first frame update
    void OnEnable()
    {
        _volumeSlider.value = GlobalGameConfig.audioVolume;
    }

    public void onButtonClose()
    {
        gameObject.SetActive(false);
    }

    public void onVolumeSliderChange()
    {
        GlobalGameConfig.audioVolume = _volumeSlider.value;
    }
}
