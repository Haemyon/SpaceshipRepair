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

    // �±׿� ���� �ٸ� ������ ó���ϰ� �ʹٸ�
    public void TryRepair()
    {
        switch (gameObject.tag)
        {
            case "Hat":
                // Hat ���� ����
                Debug.Log("Hat part processing");
                break;

            case "Window":
                // Window ���� ����
                Debug.Log("Window part processing");
                break;

            case "Wing":
                // Wing ���� ����
                Debug.Log("Wing part processing");
                break;

            case "Engine":
                // Engine ���� ����
                Debug.Log("Engine part processing");
                break;

            default:
                Debug.LogWarning("Unknown part type");
                break;
        }
    }
}
