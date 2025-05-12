using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace SimpleGame.Ui.Menu
{
    public class VolumeController : MonoBehaviour
    {
        [Header("Sliders")]
        [SerializeField, Required] private Slider _mainVolumeSlider;
        [SerializeField, Required] private Slider _sfxVolumeSlider;
        
        [SerializeField, Required] private AudioMixer _mixer;

        private void OnEnable()
        {
            _mainVolumeSlider.onValueChanged.AddListener(OnMainVolumeChanged);
            _sfxVolumeSlider.onValueChanged.AddListener(OnSfxVolumeChanged);
        }
        
        private void OnDisable()
        {
            _mainVolumeSlider.onValueChanged.RemoveListener(OnMainVolumeChanged);
            _sfxVolumeSlider.onValueChanged.RemoveListener(OnSfxVolumeChanged);
        }
        
        private void OnMainVolumeChanged(float value)
        {
            _mixer.SetFloat("MusicVolume", ConvertToDB(value));
        }
        
        private void OnSfxVolumeChanged(float value)
        {
            _mixer.SetFloat("SfxVolume", ConvertToDB(value));
        }

        private float ConvertToDB(float value)
        {
            if (value == 0)
                return -80f;

            return Mathf.Log10(value) * 20;
        }
    }
}