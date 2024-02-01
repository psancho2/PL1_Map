using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    private Transform _myTransform;
    private Vector3 _NewPosition;
    private float OffsetX;
    private float OffsetY;
    public float HorX = 0.5f;
    public float HorY = -0.1f;
    public float VerX = 0.15f;
    public float VerY = 0.6f;
    private AnimatorComponent _myAnimator;
    private Vector3 _OffsetVector;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private LinkMovement _movement;
    private Collider2D _collider;
    private Quaternion _Rotation;
    private Vector3 _lastMovement;
    private Vector3 _OriginalPosition;

    // Start is called before the first frame update
    void Start()
    {
        _OriginalPosition = transform.position;
        _Rotation = transform.rotation;
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        OffsetX = VerX;
        OffsetY = -VerY;
        _OffsetVector = new Vector3(OffsetX, OffsetY, 0f);
        _myTransform = transform;
        transform.position = _targetTransform.position + _OffsetVector;
    }

    public void SummonSword()
    {
        transform.rotation = _Rotation;
        transform.position = _OriginalPosition;
        if (_lastMovement.x == -1)
        {
            transform.Rotate(Vector3.up, 180);
            OffsetX = -HorX;
            OffsetY = HorY;
            _OffsetVector = new Vector3(OffsetX, OffsetY, 0f);
        }
        else if (_lastMovement.x == 1)
        {
            OffsetX = HorX;
            OffsetY = HorY;
            _OffsetVector = new Vector3(OffsetX, OffsetY, 0f);
        }
        else if (_lastMovement.y == 1)
        {
            transform.Rotate(Vector3.forward, 90);
            OffsetX = -VerX;
            OffsetY = VerY;
            _OffsetVector = new Vector3(OffsetX, OffsetY, 0f);
        }
        else if (_lastMovement.y == -1 || _lastMovement.magnitude == 0)
        {
            transform.Rotate(Vector3.forward, 270);
            OffsetX = VerX;
            OffsetY = -VerY;
            _OffsetVector = new Vector3(OffsetX, OffsetY, 0f);
        }

        transform.position = _targetTransform.position + _OffsetVector;
        _spriteRenderer.enabled = true;
        _collider.enabled = true;
    }

    void Update()
    {
        if (_movement._directionVector != Vector3.zero)
        {
            _lastMovement = _movement._directionVector;
        }

    }
}