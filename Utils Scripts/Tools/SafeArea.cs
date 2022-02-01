using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Utils.Tools
{
    [RequireComponent(typeof(Canvas))]
    public class SafeArea : MonoBehaviour
    {
        public static UnityEvent onOrientationChange = new UnityEvent();
        public static UnityEvent onResolutionChange = new UnityEvent();
        public static bool isLandscape { get; private set; }

        private static List<SafeArea> helpers = new List<SafeArea>();

        private static bool screenChangeVarsInitialized = false;
        private static ScreenOrientation lastOrientation = ScreenOrientation.Portrait;
        private static Vector2 lastResolution = Vector2.zero;
        private static Rect lastSafeArea = Rect.zero;

        private Canvas canvas;
        private RectTransform rectTransform;

        private RectTransform safeAreaTransform;

        private void Awake()
        {
            if (!helpers.Contains(this))
                helpers.Add(this);

            canvas = GetComponent<Canvas>();
            rectTransform = GetComponent<RectTransform>();

            safeAreaTransform = transform.Find("SafeArea") as RectTransform;

            if (screenChangeVarsInitialized) return;
            lastOrientation = Screen.orientation;
            lastResolution.x = Screen.width;
            lastResolution.y = Screen.height;
            lastSafeArea = Screen.safeArea;

            screenChangeVarsInitialized = true;
        }

        private void Start()
        {
            ApplySafeArea();
        }

        private void Update()
        {
            if (helpers[0] != this)
                return;

            if (Application.isMobilePlatform)
            {
                if (Screen.orientation != lastOrientation)
                    OrientationChanged();

                if (Screen.safeArea != lastSafeArea)
                    SafeAreaChanged();
            }
            else
            {
                if (Screen.width != lastResolution.x || Screen.height != lastResolution.y)
                    ResolutionChanged();
            }
        }

        private void ApplySafeArea()
        {
            if (safeAreaTransform == null)
                return;

            var safeArea = Screen.safeArea;

            var anchorMin = safeArea.position;
            var anchorMax = safeArea.position + safeArea.size;
            var pixelRect = canvas.pixelRect;
            anchorMin.x /= pixelRect.width;
            anchorMin.y /= pixelRect.height;
            anchorMax.x /= pixelRect.width;
            anchorMax.y /= pixelRect.height;

            safeAreaTransform.anchorMin = anchorMin;
            safeAreaTransform.anchorMax = anchorMax;
        }

        private void OnDestroy()
        {
            if (helpers != null && helpers.Contains(this))
                helpers.Remove(this);
        }

        private static void OrientationChanged()
        {
            lastOrientation = Screen.orientation;
            lastResolution.x = Screen.width;
            lastResolution.y = Screen.height;

            isLandscape = lastOrientation == ScreenOrientation.LandscapeLeft ||
                          lastOrientation == ScreenOrientation.LandscapeRight ||
                          lastOrientation == ScreenOrientation.Landscape;
            onOrientationChange.Invoke();
        }

        private static void ResolutionChanged()
        {
            if (lastResolution.x == Screen.width && lastResolution.y == Screen.height)
                return;

            lastResolution.x = Screen.width;
            lastResolution.y = Screen.height;

            isLandscape = Screen.width > Screen.height;
            onResolutionChange.Invoke();
        }

        private static void SafeAreaChanged()
        {
            if (lastSafeArea == Screen.safeArea)
                return;

            lastSafeArea = Screen.safeArea;

            foreach (var t in helpers)
                t.ApplySafeArea();
        }

        private static Vector2 GetCanvasSize()
        {
            return helpers[0].rectTransform.sizeDelta;
        }

        public static Vector2 GetSafeAreaSize()
        {
            foreach (var t in helpers.Where(t => t.safeAreaTransform != null))
            {
                return t.safeAreaTransform.sizeDelta;
            }

            return GetCanvasSize();
        }
    }
}