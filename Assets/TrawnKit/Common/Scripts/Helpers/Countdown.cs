using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class Countdown : MonoBehaviour
{

    [SerializeField]
    private GameObject _visibleRoot;
    [SerializeField]
    private Text _countdownText;

    private bool _isCountingDown;
    private bool _stop;

    private void Start()
    {
        _visibleRoot.SetActive(false);
    }

    public IEnumerator DoCountdown(int fromNumber, float tickTime = 1f)
    {
        if (_isCountingDown) yield break;
        _stop = false;
        var wait = new WaitForSeconds(tickTime);
        _visibleRoot.SetActive(true);
        var number = fromNumber;
        while (true)
        {
            _countdownText.text = number.ToString();
            _countdownText.transform.DOPunchScale(Vector3.one * 0.2f, 0.5f);
            yield return wait;
            if (_stop) break;
            number--;
            if (number == 0) break;
        }
        _countdownText.text = 0.ToString();
        _visibleRoot.SetActive(false);
        _isCountingDown = false;
        _stop = false;
    }

    public void Stop()
    {
        _stop = true;
        _visibleRoot.SetActive(false);
        _isCountingDown = false;
    }

}
