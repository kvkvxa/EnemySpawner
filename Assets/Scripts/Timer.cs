using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _intervalInSeconds = 2f;
    private WaitForSeconds _wait;
    private bool _autoRestart;

    public event Action OnComplete;

    private void Awake()
    {
        _wait = new(_intervalInSeconds);
    }

    public void StartTimer(bool autoRestart = false)
    {
        _autoRestart = autoRestart;
        StopAllCoroutines();
        StartCoroutine(Count());
    }

    private IEnumerator Count()
    {
        yield return _wait;

        OnComplete?.Invoke();

        if (_autoRestart)
        {
            StartCoroutine(Count());
        }
    }
}
