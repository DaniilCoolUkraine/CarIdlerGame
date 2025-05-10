using System.Collections;
using System.Linq;
using Cysharp.Threading.Tasks;
using SimpleEventBus.SimpleEventBus.Runtime;
using SimpleGame.Events;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Splines;

namespace SimpleGame
{
    public class CarController : MonoBehaviour
    {
        [SerializeField, Required] private SplineAnimate _follower;
        
        [SerializeField, Required] private ParticleSystem[] _fireTrail;
        [SerializeField] private int _seconds = 1;
        
        private float _newSpeed;
        private float _startSpeed;
        private Coroutine _speedCoroutine;
        
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
            if (_speedCoroutine!= null) 
                StopCoroutine(_speedCoroutine);

            _newSpeed = _follower.MaxSpeed + 1;
            _startSpeed = _follower.MaxSpeed;

            _speedCoroutine = StartCoroutine(UpdateSpeedSmoothly());
            ShowFireTrail().Forget();
        }

        private IEnumerator UpdateSpeedSmoothly()
        {
            try
            {
                float timeElapsed = 0f;

                while (timeElapsed < _seconds)
                {
                    timeElapsed += Time.deltaTime;
                    float t = timeElapsed / _seconds;
                    _follower.MaxSpeed = Mathf.Lerp(_follower.MaxSpeed, _newSpeed, t);
                    yield return null;
                }
            }
            finally
            {
                _follower.MaxSpeed = _newSpeed;
                _speedCoroutine = null;
            }
        }

        private async UniTaskVoid ShowFireTrail()
        {
            _fireTrail.ForEach(f => f.gameObject.SetActive(true));
            _fireTrail.ForEach(f => f.Play());
            await UniTask.Delay(_seconds * 1000);
            _fireTrail.ForEach(f => f.Stop());
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