using System;
using UnityEditor;
using UnityEngine;

namespace Utils.UniqueId.Editor
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(UniqueIdAttribute))]
    public class UniqueIdDrawer : PropertyDrawer
    {
        public const int BUTTON_WIDTH = 100;
        
        private static bool NoIdSet(SerializedProperty property) => string.IsNullOrEmpty(property.stringValue);

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var propertyRect = new Rect(position.x, position.y, position.width - BUTTON_WIDTH, position.height);
            var buttonRect = new Rect(position.x + (position.width - BUTTON_WIDTH), position.y, BUTTON_WIDTH, position.height);
            
            GUI.enabled = false;

            if (NoIdSet(property))
            {
                SetNewPropertyId(property);
            }

            EditorGUI.PropertyField(propertyRect, property, label, true);

            GUI.enabled = true;

            if (GUI.Button(buttonRect, "Generate New"))
            {
                SetNewPropertyId(property);
            }
        }

        private void SetNewPropertyId(SerializedProperty property)
        {
            property.stringValue = GenerateNewId();
        }

        private static string GenerateNewId()
        {
            return Guid.NewGuid().ToString();
        }
    }
#endif
}