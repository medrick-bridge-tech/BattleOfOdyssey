using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyPath
{
    public GameObject enemy;
    public EnemyPathConfig path;
    public Vector2 defaultDirection;
}

[CreateAssetMenu(fileName = "Enemies", menuName = "Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private List<EnemyPath> _enemyPaths;

    public List<EnemyPath> EnemyPaths => _enemyPaths;
}