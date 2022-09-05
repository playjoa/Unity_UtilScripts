using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Utils.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextNumberCounter : MonoBehaviour
    {
        [Header("This Text")]
        [SerializeField] private TextMeshProUGUI text;
        
        [Header("Animation Configuration")]
        [SerializeField] private int countFps = 30;
        [SerializeField] private float animDuration = 2.5f;

        private int _value;
        private string _prefixText = string.Empty;
        private string _suffixText = string.Empty;
        private string _toStringFormat = string.Empty;
        
        private Coroutine _countingCoroutine;
        private WaitForSeconds _stepWaitTime = new WaitForSeconds(1f / 30f);
        private bool ObjectActive => gameObject.activeInHierarchy;
        
        public TextMeshProUGUI TextMeshGUI => text;
        public event Action OnCountComplete;
        
        private void OnValidate() => text ??= GetComponent<TextMeshProUGUI>();
        private void Awake() => _stepWaitTime = new WaitForSeconds(1f / countFps);

        private void OnDisable()
        {
            if (ResetAnimationCoroutine())
            {
                UpdateTextView(_value);
            }
        }
        
        public void InitiateValue(int setStartingValue) => _value = setStartingValue;
        
        public void SetValue(int newValue, string prefix = "", string suffix = "", string toStringFormat = "N0")
        {
            _prefixText = prefix;
            _suffixText = suffix;
            _toStringFormat = toStringFormat;
            UpdateText(newValue);
            _value = newValue;
        }

        private void UpdateText(int newValue)
        {
            ResetAnimationCoroutine();

            if (ObjectActive)
            {
                _countingCoroutine = StartCoroutine(CountText(newValue));
            }
            else
            {
                UpdateTextView(newValue);
            }
        }

        private bool ResetAnimationCoroutine()
        {
            if (_countingCoroutine == null) return false;
            
            StopCoroutine(_countingCoroutine);
            return true;
        }

        private void UpdateTextView(int count) => SetCustomText(text, count.ToString(_toStringFormat), _prefixText, _suffixText);
        
        private static void SetCustomText(TMP_Text tmpText, string text, string prefix = "", string suffix = "")
        {
            if (tmpText == null) return;
            tmpText.text = $"{prefix}{text}{suffix}";
        }
        
        private IEnumerator CountText(int newValue)
        {
            var previousValue = _value;
            UpdateTextView(previousValue);

            var stepAmount = newValue - previousValue < 0 ? 
                Mathf.FloorToInt((newValue - previousValue) / (countFps * animDuration)) : 
                Mathf.CeilToInt((newValue - previousValue) / (countFps * animDuration));

            if (previousValue < newValue)
            {
                while (previousValue < newValue)
                {
                    previousValue += stepAmount;

                    if (previousValue > newValue)
                        previousValue = newValue;

                    UpdateTextView(previousValue);
                    yield return _stepWaitTime;
                }
            }
            else
            {
                while (previousValue > newValue)
                {
                    previousValue += stepAmount;
                    
                    if (previousValue < newValue)
                        previousValue = newValue;

                    UpdateTextView(previousValue);
                    yield return _stepWaitTime;
                }
            }
            OnCountComplete?.Invoke();
        }
    }
}
