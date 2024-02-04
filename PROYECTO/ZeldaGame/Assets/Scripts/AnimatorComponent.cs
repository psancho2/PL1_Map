using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorComponent : MonoBehaviour
{

    private Animator mAnimator;
    private SpriteRenderer mRenderer;
    public bool isAttacking = false;
    public bool isDead = false;
    public bool takesDamage = false;
    public bool placeBomb = false;
    private Rigidbody2D mRigidbody;
    private LinkMovement mLinkMovement;
    private SpriteRenderer _mSprite;
    private LinkInput mLinkInput;
    [SerializeField] private SpriteRenderer _SwordSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mRigidbody = GetComponent<Rigidbody2D>();
        mLinkMovement = GetComponent<LinkMovement>();
        _mSprite = GetComponent<SpriteRenderer>();
        mLinkInput = GetComponent<LinkInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mLinkMovement._directionVector != Vector3.zero)
        {
            mAnimator.SetInteger("AnimState", 2);
            if (mLinkMovement._directionVector.x < 0)
            {
                _mSprite.flipX = true;
            }
            else
            {
                _mSprite.flipX = false;
            }
            mAnimator.SetFloat("MoveX", mLinkMovement._directionVector.x);
            mAnimator.SetFloat("MoveY", mLinkMovement._directionVector.y);
        }
        else
        {
            mAnimator.SetInteger("AnimState", 0);
        }
        if (isAttacking)
        {
            mAnimator.SetInteger("AnimState", 1);
        }
        if (takesDamage)
        {
            mAnimator.SetInteger("Animstate", 4);
        }
        if (placeBomb)
        {
            mAnimator.SetInteger("AnimState", 3);
        }

    }
}
