using System;
using System.Collections.Generic;
using SimpleGame.General;
using UnityEngine;

namespace SimpleGame.Storages
{
    [CreateAssetMenu(fileName = "SoundsStorage", menuName = "Storage/SoundsStorage")]
    public class SoundsStorage : ScriptableObject
    {
        public List<Sound> Sounds;
    }

    [Serializable]
    public class Sound
    {
        public ESoundType SoundType;
        public AudioClip Clip;
    }
}