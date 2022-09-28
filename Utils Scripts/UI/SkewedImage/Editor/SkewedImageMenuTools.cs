using UnityEditor;
using UnityEngine;

namespace Playgig.UI.SkewedImage.Editor
{
    public static class SkewedImageMenuTools
    {
        private const string SkewedImagePath = "GameObject/UI/Skewed Image";
        private const string SkewedImageCreatedUndoTag = "Skewed Image";
        private const string SkewedImageDefaultName = "SkewedImage";
        
        [MenuItem(SkewedImagePath, false, 2003)]
        public static void CreateSkewedImage(MenuCommand menuCommand)
        {
            var sceneHeader = new GameObject
            {
                name = SkewedImageDefaultName
            };

            sceneHeader.AddComponent<SkewedImage>();
            Undo.RegisterCreatedObjectUndo(sceneHeader, SkewedImageCreatedUndoTag);
            Selection.activeGameObject = sceneHeader;
        }
    }
}