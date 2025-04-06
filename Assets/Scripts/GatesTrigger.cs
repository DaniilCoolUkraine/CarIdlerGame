using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using SimpleEventBus.SimpleEventBus.Runtime;
using SimpleGame.Events;
using UnityEngine;

namespace SimpleGame
{
    public class GatesTrigger : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _vfxPrefab;

        private List<ParticleSystem> _vfxList = new List<ParticleSystem>();
        
        private void OnTriggerEnter(Collider other)
        {
            var particle = _vfxList.FirstOrDefault(vfx => !vfx.gameObject.activeSelf);
            if (particle != null)
                particle.gameObject.SetActive(true);
            else
            {
                particle = Instantiate(_vfxPrefab, transform);
                _vfxList.Add(particle);
            }
            
            WaitAndReturnToPool(particle).Forget();

            GlobalEvents.Publish(new GatesPassedEvent());
        }

        private async UniTaskVoid WaitAndReturnToPool(ParticleSystem particle)
        {
            await UniTask.WaitWhile(particle.IsAlive);
            if (particle != null)
                particle.gameObject.SetActive(false);
        }
    }
}