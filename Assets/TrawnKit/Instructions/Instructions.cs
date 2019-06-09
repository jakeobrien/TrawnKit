using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Instructions : MonoBehaviour
{

    [SerializeField]
    private GameInfo _gameInfo;
    [SerializeField]
    private TrawnButtonEvent _buttonEvent;
    [SerializeField]
    private Text _gameNameText;
    [SerializeField]
    private GameObject _textObject;
    [SerializeField]
    private Text _instructionsText;
    private bool _isLoading;

    private void Start()
    {
        StartCoroutine(DoInstructions());
    }

    private void OnEnable()
    {
        _textObject.SetActive(false);
        _gameNameText.text = _gameInfo.gameName;
        _buttonEvent.Event += OnButtonPress;
    }

    private void OnDisable()
    {
        _buttonEvent.Event -= OnButtonPress;
    }

    private void OnButtonPress(TrawnButton button, TrawnPlayer player)
    {
        if (!_isLoading && button == TrawnButton.Blue) LoadGameScene();
    }

    private IEnumerator DoInstructions()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (var instruction in _gameInfo.instructions)
        {
            _instructionsText.text = instruction;
            _textObject.SetActive(true);
            _textObject.transform.DOPunchScale(Vector3.one * 0.2f, 0.2f);
            yield return new WaitForSeconds(2f);
            _textObject.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        if (_isLoading) return;
        _isLoading = true;
        _gameInfo.sceneToLoad.LoadScene();
    }

}
