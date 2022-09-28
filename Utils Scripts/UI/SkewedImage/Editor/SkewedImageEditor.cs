using UnityEditor;
using UnityEditor.UI;

namespace Playgig.UI.SkewedImage
{
    [CustomEditor(typeof(SkewedImage))]
    [CanEditMultipleObjects]
    public class SkewedImageEditor : ImageEditor
    {
        private SkewedImage _targetSkewedImage;
        
        private SerializedObject _serialScript;
        private SerializedProperty _skewXValueProperty;
        private SerializedProperty _skewYValueProperty;
        
        protected override void OnEnable()
        {
            _targetSkewedImage = (SkewedImage)target;
            _serialScript = new SerializedObject(_targetSkewedImage);
            
            _skewXValueProperty = _serialScript.FindProperty(nameof(_targetSkewedImage.SkewXValue));
            _skewYValueProperty = _serialScript.FindProperty(nameof(_targetSkewedImage.SkewYValue));
            
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            EditorGUILayout.Space(5);
            
            EditorGUILayout.LabelField("Skew Values:", EditorStyles.boldLabel);
            ShowPropertyField(_skewXValueProperty);
            ShowPropertyField(_skewYValueProperty);
            
            EditorGUILayout.Space(5);

        }
        
        private void ShowPropertyField(SerializedProperty serializedProperty)
        {
            _serialScript.Update();
            EditorGUILayout.PropertyField(serializedProperty);
            _serialScript.ApplyModifiedProperties();
        }
    }
}