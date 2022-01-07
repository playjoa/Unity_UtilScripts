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

        private Vector3 localStartingPosition;

        private void Awake() => localStartingPosition = transform.localPosition;

        private void OnEnable()
        {
            if (activateOnEnable)
                StartAnimation();
        }

        private void OnDisable() => StopAnimation();

        private void ResetTransform()
        {
            switch (pingPongDirection)
            {
                case PingPongDirection.UpDown:
                    transform.localPosition = new Vector3(localStartingPosition.x,
                        localStartingPosition.y - distanceToPingPong / 2f, localStartingPosition.z);
                    break;
                case PingPongDirection.LeftRight:
                    transform.localPosition = new Vector3(localStartingPosition.x - distanceToPingPong / 2f,
                        localStartingPosition.y, localStartingPosition.z);
                    break;
                case PingPongDirection.FrontBack:
                    transform.localPosition = new Vector3(localStartingPosition.x,
                        localStartingPosition.y, localStartingPosition.z - distanceToPingPong / 2f);
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
                    transform.DOLocalMoveX(transform.localPosition.x + distanceToPingPong, pingPongDuration)
                        .SetLoops(-1, LoopType.Yoyo).SetEase(easeType);
                    break;
                case PingPongDirection.FrontBack:
                    transform.DOLocalMoveZ(transform.localPosition.z + distanceToPingPong, pingPongDuration)
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

        public void StopAnimation() => transform.DOKill();
    }

    public enum PingPongDirection
    {
        UpDown,
        LeftRight,
        FrontBack
    }
}