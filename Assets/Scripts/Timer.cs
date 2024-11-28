using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float intervalInSeconds = 2f;
    private WaitForSeconds _wait;

    public event Action OnComplete;

    private void Awake()
    {
        _wait = new(intervalInSeconds);
    }

    public void StartTimer()
    {
        StartCoroutine(Count());
    }

    private IEnumerator Count()
    {
        yield return _wait;

        OnComplete?.Invoke();
    }
}
