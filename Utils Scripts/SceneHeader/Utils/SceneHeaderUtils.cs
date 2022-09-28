#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Utils.SceneHeader
{
    public static class SceneHeaderUtils
    {
        [MenuItem(SceneHeaderStatics.GROUP_SELECTED_MENU_ITEM)]
        public static void GroupSelected()
        {
            if (!Selection.activeTransform) return;
            var go = new GameObject(Selection.activeTransform.name + " Group");
            
            go.transform.SetSiblingIndex(Selection.activeTransform.GetSiblingIndex());
            go.transform.position = FindCenterPoint(Selection.transforms);
            go.transform.SetParent(Selection.activeTransform.parent);

            Undo.RegisterCreatedObjectUndo(go, "Group Selected");

            foreach (var transform in Selection.transforms)
            {
                Undo.SetTransformParent(transform, go.transform, "Group Selected");
            }

            Selection.activeGameObject = go;
        }

        private static Vector3 FindCenterPoint(IReadOnlyList<Transform> objects)
        {
            switch (objects.Count)
            {
                case 0:
                    return Vector3.zero;
                case 1:
                    return objects[0].TryGetComponent<Renderer>(out var ren) ? ren.bounds.center : objects[0].transform.position;
            }

            var bounds = new Bounds(objects[0].transform.position, Vector3.zero);
            foreach (var transform in objects)
            {
                if (transform.TryGetComponent<Renderer>(out var ren) && ren.GetType() != typeof(ParticleSystemRenderer))
                    bounds.Encapsulate(ren.bounds);
                else
                    bounds.Encapsulate(transform.position);
            }
            return bounds.center;
        }

        [MenuItem(SceneHeaderStatics.CREATE_HEADER_MENU_ITEM, false, 0)]
        public static void CreateSceneHeader()
        {
            var sceneHeader = new GameObject
            {
                tag = SceneHeaderStatics.EDITOR_TAG
            };

            sceneHeader.AddComponent<SceneHeader>();
            sceneHeader.transform.hideFlags = HideFlags.NotEditable | HideFlags.HideInInspector;
            Undo.RegisterCreatedObjectUndo(sceneHeader, SceneHeaderStatics.HEADER_CREATED_UNDO_TAG);
            Selection.activeGameObject = sceneHeader;
        }
    }
}
#endif