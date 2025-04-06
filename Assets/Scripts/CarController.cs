using SimpleEventBus.SimpleEventBus.Runtime;
using SimpleGame.Events;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Splines;

namespace SimpleGame
{
    public class CarController : MonoBehaviour
    {
        [SerializeField, Required] private SplineAnimate _follower;

        private void OnEnable()
        {
            GlobalEvents.AddListener<UpgradeSpeedEvent>(OnUpgradeSpeed);
        }

        private void OnDisable()
        {
            GlobalEvents.RemoveListener<UpgradeSpeedEvent>(OnUpgradeSpeed);
        }
        
        private void OnUpgradeSpeed(UpgradeSpeedEvent ev)
        {
            _follower.MaxSpeed += 1;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_follower != null)
                return;

            _follower = GetComponent<SplineAnimate>();
            UnityEditor.EditorUtility.SetDirty(this);
        }
#endif
    }
}