using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Path Config" , fileName = "EnemyPath")]
public class EnemyPathConfig : ScriptableObject
{
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private GameObject enemyPrefab;
    
    public GameObject GetEnemyPrefab(){return enemyPrefab;}
    public List<Transform> GetPathPrefab() {
        var path = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            path.Add(child);
            
        }
        return path;
    }
    public float GetEnemySpeed() { return enemyPrefab.GetComponent<Enemy>().EnemySpeed; }
    public float GetEnemyDelay() { return enemyPrefab.GetComponent<Enemy>().EnemyDelay; }
}