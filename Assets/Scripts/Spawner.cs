using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ArenaSetter _arenaSetter;
    [SerializeField] private Factory _factory;
    [SerializeField] private Timer _timer;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Color _color;
    [SerializeField] private DirectionSetter _directionSetter;

    private Vector3 _directionPoint;

    private float _spawAreaDivider = 2f;
    private float _thresholdDistance = 0.5f;

    private void Awake()
    {
        _directionPoint = _directionSetter.GetRandomDirectionPoint();
    }

    private void OnEnable()
    {
        _timer.OnComplete += Spawn;
        _timer.StartTimer(autoRestart: true); 
    }

    private void OnDisable()
    {
        _timer.OnComplete -= Spawn;
    }

    private void Spawn()
    {
        Vector3 spawnPoint = GetRandomSpawnPoint();
        Enemy newEnemy = _factory.Create(_enemyPrefab, spawnPoint, _color);
        newEnemy.SetDirectionPoint(_directionPoint);

        _timer.StartTimer();
    }


    private Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(
            Random.Range(-_arenaSetter.Width / _spawAreaDivider + _thresholdDistance, _arenaSetter.Width / _spawAreaDivider - _thresholdDistance),
            1f,
            Random.Range(-_arenaSetter.Length / _spawAreaDivider + _thresholdDistance, _arenaSetter.Length / _spawAreaDivider - _thresholdDistance)
            );
    }
}