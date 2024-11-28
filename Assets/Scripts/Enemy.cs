using UnityEngine;

public class Enemy : MonoBehaviour
{
    private DirectionSetter _directionSetter;
    private Vector3 _currentDirectionPoint;
    private float _thresholdDistance = 0.2f;
    
    private float _moveSpeed = 2f;

    private void Awake()
    {
        if (_directionSetter == null)
        {
            _directionSetter = FindObjectOfType<DirectionSetter>();
        }

        _currentDirectionPoint = _directionSetter.GetRandomDirectionPoint();
    }

    private void Update()
    {
        Move(_currentDirectionPoint);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _currentDirectionPoint = _directionSetter.GetRandomDirectionPoint();
    }

    private void Move(Vector3 directionPoint)
    {
        if (Vector3.Distance(transform.position, directionPoint) < _thresholdDistance)
        {
            _currentDirectionPoint = _directionSetter.GetRandomDirectionPoint();
        }

        Vector3 direction = directionPoint - transform.position;

        transform.Translate(direction.normalized * _moveSpeed * Time.deltaTime, Space.World);
    }
}