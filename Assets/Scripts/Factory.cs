using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    public Enemy Create() => Instantiate(_enemyPrefab);
}