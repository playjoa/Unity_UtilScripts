using UnityEngine;

namespace Utils.UniqueId.Components
{
    public class ScriptableObjectWithId : ScriptableObject
    {
        [UniqueId] 
        [SerializeField] private string id;
        public string Id => id;
    }
}