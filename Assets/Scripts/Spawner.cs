using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ArenaSetter _arenaSetter;
    [SerializeField] private Factory _factory;
    [SerializeField] private Timer _timer;

    private float _thresholdDistance = 0.5f;

    private void OnEnable()
    {
        _timer.OnComplete += Spawn;
        _timer.StartTimer();
    }

    private void OnDisable()
    {
        _timer.OnComplete -= Spawn;
    }

    private void Spawn()
    {
        Enemy newEnemy = _factory.Create();
        newEnemy.transform.position = GetRandomSpawnPoint();

        _timer.StartTimer();
    }


    private Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(Random.Range(-_arenaSetter.Width / 2f + _thresholdDistance, _arenaSetter.Width / 2f - _thresholdDistance),
            1f,
            Random.Range(-_arenaSetter.Length / 2f + _thresholdDistance, _arenaSetter.Length / 2f - _thresholdDistance));
    }
}