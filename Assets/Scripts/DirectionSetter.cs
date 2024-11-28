using UnityEngine;

public class DirectionSetter : MonoBehaviour
{ 
    [SerializeField] private ArenaSetter _arenaSetter;

    public Vector3 GetRandomDirectionPoint()
    {
        return new Vector3(Random.Range(-_arenaSetter.Width / 2f, _arenaSetter.Width / 2f),
            1f,
            Random.Range(-_arenaSetter.Length / 2f, _arenaSetter.Length / 2f));
    }
}