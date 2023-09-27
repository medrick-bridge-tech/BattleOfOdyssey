using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(menuName = "Enemy Path Config" , fileName = "EnemyPath")]
    public class EnemyPathConfig : ScriptableObject
    {
        [SerializeField] private GameObject pathPrefab;
        public bool isStatic;

        public List<Transform> GetPathPrefab() {
            var path = new List<Transform>();
            foreach(Transform child in pathPrefab.transform)
            {
                path.Add(child);
            
            }
            return path;
        }
    }
}