using UnityEngine;

public class DirectionSetter : MonoBehaviour
{ 
    [SerializeField] private ArenaSetter _arenaSetter;

    private float _directionAreaWidthDivider = 2f;
    private float _directionAreaLengthDivider = 2f;

    public Vector3 GetRandomDirectionPoint()
    {
        return new Vector3(
            Random.Range(-_arenaSetter.Width / _directionAreaWidthDivider, _arenaSetter.Width / _directionAreaWidthDivider),
            1f,
            Random.Range(-_arenaSetter.Length / _directionAreaLengthDivider, _arenaSetter.Length / _directionAreaLengthDivider)
            );
    }
}