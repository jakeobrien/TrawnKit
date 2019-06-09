using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _sprite;
    [SerializeField]
    private TrawnInput _trawnInput;
    [SerializeField]
    private PlayerEvent _scoredEvent;

    private PlayerInfo _info;

    public void SetPlayerInfo(PlayerInfo info)
    {
        _info = info;
        _sprite.color = info.color;
    }

    private void Update()
    {
        if (_trawnInput.GetButtonDown(TrawnButton.Blue, _info.player))
        {
            _info.score++;
            _scoredEvent.Fire(_info.player);
        }

        var input = _trawnInput.GetStickInput(_info.player);
        transform.position += (Vector3)input * Time.deltaTime * 2f;
    }

}
