using System.Collections;
using UnityEngine;

namespace Utils.EditorTools
{
    public class ObjectScreenShotSaver : MonoBehaviour
    {
        [Header("File Settings")] 
        [SerializeField] private string directoryLocation = "C:/Users/MyUser/Desktop/";
        [SerializeField] private string folderName = "SkinPhotos";
        [SerializeField] private bool useGameObjectName;
        [SerializeField] private string prefixFileName = "img_";

        [Header("Screenshot Settings")] 
        [SerializeField] private float shutterTime = 0.1f;

        [Header("Objects to Screenshot")] 
        [SerializeField] private GameObject[] objectsToScreenShot;
        
        private GameObject _currentObjectToScreenShot;
        private const string TypeOfFile = ".png";

        private WaitForSeconds WaitForShutter => new WaitForSeconds(shutterTime);
        private string FolderLocation => directoryLocation + folderName;

        private string FileName(int numberFile)
        {
            if (useGameObjectName)
                return _currentObjectToScreenShot.name + TypeOfFile;
            
            return prefixFileName + numberFile + TypeOfFile;
        }

        private void OnValidate() => objectsToScreenShot = GetChildObjects();
        private void Awake() => DeactivateObjects();
        private void Start() => StartCoroutine(PrintAndSaveObjects());

        private GameObject[] GetChildObjects()
        {
            var childObjects = new GameObject[transform.childCount];

            for (var i = 0; i < childObjects.Length; i++)
                childObjects[i] = transform.GetChild(i).gameObject;

            return childObjects;
        }

        private void DeactivateObjects()
        {
            foreach (var g in objectsToScreenShot)
                g.SetActive(false);
        }

        private IEnumerator PrintAndSaveObjects()
        {
            yield return WaitForShutter;

            for (var i = 0; i < objectsToScreenShot.Length; i++)
            {
                _currentObjectToScreenShot = objectsToScreenShot[i];
                _currentObjectToScreenShot.SetActive(true);
                yield return WaitForShutter;
                
                yield return new WaitForEndOfFrame();
                var textureFromGameView = new Texture2D(Screen.width, Screen.height);
                textureFromGameView.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
                textureFromGameView.Apply();
                var textureGameViewBytes = textureFromGameView.EncodeToPNG();
                
                Destroy(textureFromGameView);
                SaveScreenShot(textureGameViewBytes, i);
                
                _currentObjectToScreenShot.SetActive(false);
            }
        }

        private void SaveScreenShot(byte[] screenShotBytes, int screenShotIndex)
        {
            CreateDirectory();

            var path = System.IO.Path.Combine(FolderLocation, FileName(screenShotIndex));
            System.IO.File.WriteAllBytes(path, screenShotBytes);
        }

        private void CreateDirectory()
        {
            if (System.IO.Directory.Exists(FolderLocation)) return;
            System.IO.Directory.CreateDirectory(FolderLocation);
        }
    }
}