using GameData;
using TMPro;
using UnityEngine;

namespace Utils.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class GameVersionText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI txtGameVersion;

        private void OnValidate()
        {
            txtGameVersion = GetComponent<TextMeshProUGUI>();
        }

        private void Awake()
        {
            WriteGameVersion();
        }

        private void WriteGameVersion()
        {
            if (!txtGameVersion) return;
            txtGameVersion.text = StaticData.GAME_VERSION;
        }
    }
}