using System;
using Cinemachine;
using SimpleEventBus.SimpleEventBus.Runtime;
using SimpleGame.Events;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SimpleGame.Managers
{
    public class ImpulseSourceManager : MonoBehaviour
    {
        [SerializeField, Required] private CinemachineImpulseSource _gatesPassedSource;
        [SerializeField] private float _gatesPassedForce = 1;

        [Space(10)]
        [SerializeField, Required] private CinemachineImpulseSource _carBoughtSource;
        [SerializeField] private float _carBoughtForce = 1;

        private void OnEnable()
        {
            GlobalEvents.AddListener<GatesPassedEvent>(OnGatesPassed);
            GlobalEvents.AddListener<SpawnCarEvent>(OnCarSpawned);
        }

        private void OnDisable()
        {
            GlobalEvents.RemoveListener<GatesPassedEvent>(OnGatesPassed);
            GlobalEvents.RemoveListener<SpawnCarEvent>(OnCarSpawned);
        }

        private void OnGatesPassed(GatesPassedEvent ev)
        {
            _gatesPassedSource.GenerateImpulseWithForce(_gatesPassedForce);
        }
        
        private void OnCarSpawned(SpawnCarEvent ev)
        {
            _carBoughtSource.GenerateImpulseWithForce(_carBoughtForce);
        }
    }
}