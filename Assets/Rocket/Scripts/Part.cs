using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite _baseSprite;
    [SerializeField] private Sprite _brokenSprite;

    private bool _isFixed = true;
    public bool IsFixed
    {
        get => _isFixed;
        set
        {
            _isFixed = value;
            UpdatePart();
        }
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        UpdatePart();
    }

    public void UpdatePart()
    {
        if (_spriteRenderer)
        {
            if (_isFixed)
            {
                _spriteRenderer.sprite = _baseSprite;
            }
            else
            {
                _spriteRenderer.sprite = _brokenSprite;
                //Debug.Log($"{gameObject.tag} is now broken.");
            }
        }
    }

    public string GetPartTag()
    {
        return gameObject.tag;
    }

    // 태그에 따라 다른 로직을 처리하고 싶다면
    public void TryRepair()
    {
        switch (gameObject.tag)
        {
            case "Hat":
                // Hat 관련 로직
                Debug.Log("Hat part processing");
                break;

            case "Window":
                // Window 관련 로직
                Debug.Log("Window part processing");
                break;

            case "Wing":
                // Wing 관련 로직
                Debug.Log("Wing part processing");
                break;

            case "Engine":
                // Engine 관련 로직
                Debug.Log("Engine part processing");
                break;

            default:
                Debug.LogWarning("Unknown part type");
                break;
        }
    }
}
