using DG.Tweening;
using UnityEngine;

namespace Utils.DOTweens
{
    public class DOTweenPingPongAnim : MonoBehaviour
    {
        [Header("Animation Configuration")]
        [SerializeField] private PingPongDirection pingPongDirection = PingPongDirection.UpDown;
        [SerializeField] private float distanceToPingPong = 35;
        [SerializeField] private float pingPongDuration = 0.75f;
        [SerializeField] private Ease easeType = Ease.InOutSine;
        [SerializeField] private bool activateOnEnable = true;

        private Vector3 _localStartingPosition;

        private void Awake()
        {
            _localStartingPosition = transform.localPosition;
        }

        private void OnEnable()
        {
            if (activateOnEnable)
                StartAnimation();
        }

        private void OnDisable()
        {
            StopAnimation();
        }

        private void ResetTransform()
        {
            switch (pingPongDirection)
            {
                case PingPongDirection.UpDown:
                    transform.localPosition = new Vector3(_localStartingPosition.x,
                        _localStartingPosition.y - distanceToPingPong / 2f, _localStartingPosition.z);
                    break;
                case PingPongDirection.LeftRight:
                    transform.localPosition = new Vector3(_localStartingPosition.x - distanceToPingPong / 2f,
                        _localStartingPosition.y, _localStartingPosition.z);
                    break;
                case PingPongDirection.FrontBack:
                    transform.localPosition = new Vector3(_localStartingPosition.x,
                        _localStartingPosition.y, _localStartingPosition.z - distanceToPingPong / 2f);
                    break;
                default:
                    Debug.LogError("Ping Ping Type Not registered");
                    break;
            }
        }

        public void StartAnimation()
        {
            ResetAnimation();

            switch (pingPongDirection)
            {
                case PingPongDirection.UpDown:
                    transform.DOLocalMoveY(transform.localPosition.y + distanceToPingPong, pingPongDuration)
                        .SetLoops(-1, LoopType.Yoyo).SetEase(easeType);
                    break;
                case PingPongDirection.LeftRight:
                    transform.DOLocalMoveY(transform.localPosition.x + distanceToPingPong, pingPongDuration)
                        .SetLoops(-1, LoopType.Yoyo).SetEase(easeType);
                    break;
                case PingPongDirection.FrontBack:
                    transform.DOLocalMoveY(transform.localPosition.z + distanceToPingPong, pingPongDuration)
                        .SetLoops(-1, LoopType.Yoyo).SetEase(easeType);
                    break;
                default:
                    Debug.LogError("Ping Ping Type Not registered");
                    break;
            }
        }

        private void ResetAnimation()
        {
            StopAnimation();
            ResetTransform();
        }

        public void StopAnimation()
        {
            transform.DOKill();
        }
    }

    public enum PingPongDirection
    {
        UpDown,
        LeftRight,
        FrontBack
    }
}