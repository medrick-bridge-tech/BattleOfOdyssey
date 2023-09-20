using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyPath
{
    public GameObject Enemy;
    public EnemyPathConfig Path;
}

[CreateAssetMenu(fileName = "Enemies", menuName = "Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private List<EnemyPath> _enemyPaths;

    public List<EnemyPath> EnemyPaths => _enemyPaths;
}