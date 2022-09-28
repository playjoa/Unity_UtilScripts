#if UNITY_EDITOR
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Utils.SceneHeader
{
    [CustomEditor(typeof(SceneHeader))]
    public class SceneHeaderEditor : Editor
    {
        private bool _titleChanged;
        private double _lastChangedTime;

        public static void UpdateAllHeader()
        {
            var allHeader = Object.FindObjectsOfType<SceneHeader>();

            foreach (var header in allHeader)
            {
                UpdateHeader(header, null, true);
            }
        }

        public static string GetSimpleTitle(string prefix, string title)
        {
            if (prefix == null || prefix.Length <= 0) return title;
            return GetSimpleTitle(prefix[0], title);
        }

        public static string GetSimpleTitle(char prefix, string title)
        {
            var maxCharLength = SceneHeaderStatics.MAX_NAME_LENGTH;
            var charLength = maxCharLength - title.Length;

            var leftSize = 0;
            var rightSize = 0;
            switch (SceneHeaderStatics.ALIGNMENT)
            {
                case SceneHeaderAlignment.Start:
                    leftSize = SceneHeaderStatics.MIN_PREFIX_LENGTH;
                    rightSize = charLength - leftSize;
                    break;
                case SceneHeaderAlignment.End:
                    rightSize = SceneHeaderStatics.MIN_PREFIX_LENGTH;
                    leftSize = charLength - rightSize;
                    break;
                case SceneHeaderAlignment.Center:
                    leftSize = charLength / 2;
                    rightSize = charLength / 2;
                    break;
            }

            var left = leftSize > 0 ? new string(prefix, leftSize) : "";
            var right = rightSize > 0 ? new string(prefix, rightSize) : "";

            var builder = new StringBuilder();
            builder.Append(left);
            builder.Append(" ");
            builder.Append(title);
            builder.Append(" ");
            builder.Append(right);

            return builder.ToString();
        }

        public static string GetFormattedTitle(string title)
        {
            return GetSimpleTitle(SceneHeaderStatics.PREFIX, title);
        }

        public static void UpdateHeader(SceneHeader header, string title = null, bool markAsDirty = false)
        {
            var targetTitle = title ?? header.title;

            header.name = GetFormattedTitle(targetTitle);

            if (markAsDirty)
                EditorUtility.SetDirty(header);
        }

        private void OnEnable() => Undo.undoRedoPerformed += OnUndoRedo;

        private void OnDisable() => Undo.undoRedoPerformed -= OnUndoRedo;

        public void OnUndoRedo() => UpdateHeader(target as SceneHeader, null, true);

        public override void OnInspectorGUI()
        {
            var typeProperty = serializedObject.FindProperty("type");

            var header = target as SceneHeader;

            serializedObject.Update();

            var titleProperty = serializedObject.FindProperty("title");
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(titleProperty);
            if (EditorGUI.EndChangeCheck())
            {
                UpdateHeader(header, titleProperty.stringValue, false);

                //Refresh the hierarchy to reflect the new name
                EditorApplication.RepaintHierarchyWindow();
            }

            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Refresh"))
            {
                UpdateAllHeader();
            }

            if (GUILayout.Button("Create Empty"))
            {
                var o = new GameObject("Empty");
                o.transform.SetSiblingIndex(((SceneHeader) target).transform.GetSiblingIndex() + 1);
                Undo.RegisterCreatedObjectUndo(o, "Create Empty");
            }

            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif