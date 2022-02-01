using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Utils.Tools;

namespace Utils.Animations
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextNumberCounter : MonoBehaviour
    {
        [Header("This Text")]
        [SerializeField] private TextMeshProUGUI text;
        
        [Header("Animation Configuration")]
        [SerializeField] private int countFps = 30;
        [SerializeField] private float animDuration = 2.5f;

        private string prefixText = string.Empty;
        private string suffixText = string.Empty;
        private int value;
        private Coroutine countingCoroutine;
        
        private const string NUMBER_FORMAT = "N0";
        private WaitForSeconds stepWaitTime = new WaitForSeconds(1f / 30f);

        public TextMeshProUGUI TextMeshGUI => text;
        public event Action OnCountComplete;

        public void InitiateValue(int setStartingValue) => value = setStartingValue;
        
        public void SetValue(int newValue, string prefix = "", string suffix = "")
        {
            prefixText = prefix;
            suffixText = suffix;
            UpdateText(newValue);
            value = newValue;
        }

        private void OnValidate() => text = GetComponent<TextMeshProUGUI>();

        private void Awake() => stepWaitTime = new WaitForSeconds(1f / countFps);

        private void UpdateText(int newValue)
        {
            if (countingCoroutine != null)
                StopCoroutine(countingCoroutine);
            
            countingCoroutine = StartCoroutine(CountText(newValue));
        }

        private void UpdateTextView(int count) => text.SetCustomText(count.ToString(NUMBER_FORMAT), prefixText, suffixText);
        
        private IEnumerator CountText(int newValue)
        {
            var previousValue = value;
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
                    yield return stepWaitTime;
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
                    yield return stepWaitTime;
                }
            }
            OnCountComplete?.Invoke();
        }
    }
}