using System.Collections.Generic;
using System.Linq;
using SimpleEventBus.SimpleEventBus.Runtime;
using SimpleGame.Events;
using SimpleGame.Storages;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;

namespace SimpleGame.Managers
{
    public class SoundEffectsManager : MonoBehaviour
    {
        [SerializeField, Required] private SoundsStorage _sounds;
        [SerializeField, Required] private AudioMixerGroup _sfxGroup;   

        private List<AudioSource> _audioSources = new List<AudioSource>();

        private void OnEnable()
        {
            GlobalEvents.AddListener<SoundRequestEvent>(OnSoundRequested);
        }
        
        private void OnDisable()
        {
            GlobalEvents.RemoveListener<SoundRequestEvent>(OnSoundRequested);
        }

        private void OnSoundRequested(SoundRequestEvent ev)
        {
            var clip = _sounds.Sounds.FirstOrDefault(s => s.SoundType == ev.SoundType)?.Clip;
            if (clip == null)
            {
                Debug.LogError($"SoundEffectsManager: {gameObject.name} has no sound clip for type {ev.SoundType}");
                return;
            }

            var audioSource = _audioSources.FirstOrDefault(a => !a.isPlaying);
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.outputAudioMixerGroup = _sfxGroup;

                _audioSources.Add(audioSource);
            }

            audioSource.clip = clip;
            audioSource.pitch = Random.Range(0.8f, 1.2f);

            audioSource.Play();
        }
    }
}