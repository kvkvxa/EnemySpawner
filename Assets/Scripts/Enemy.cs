using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    private Vector3 _currentDirectionPoint;
    private Renderer _renderer;

    private float _moveSpeed = 2f;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        Move(_currentDirectionPoint);
    }

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
    }

    public void SetDirectionPoint(Vector3 directionPoint)
    {
        _currentDirectionPoint = directionPoint;
    }

    private void Move(Vector3 directionPoint)
    {
        Vector3 direction = directionPoint - transform.position;

        transform.Translate(direction.normalized * _moveSpeed * Time.deltaTime, Space.World);
    }
}