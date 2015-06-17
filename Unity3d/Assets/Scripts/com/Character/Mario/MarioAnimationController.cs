using UnityEngine;
using System.Collections;
using System;

public class MarioAnimationController : MonoBehaviour {

    public static readonly float ANIMATION_SPEED_MIN = 0.3f;

    [SerializeField]
    private Character m_characterState;

    [SerializeField]
    private Animator m_marioAnimator;

    [SerializeField]
    private Rigidbody2D m_marioRigibody;

    public void Start()
    {
        m_characterState = gameObject.GetComponent<Character>();
        m_marioAnimator = gameObject.GetComponent<Animator>();
        m_marioRigibody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void LateUpdate()
    {
        m_marioAnimator.SetFloat("state", m_characterState.currentState);
        m_marioAnimator.SetFloat("speedX", Mathf.Abs(m_marioRigibody.velocity.x));
        m_marioAnimator.SetFloat("speedY", m_marioRigibody.velocity.y);
        m_marioAnimator.SetFloat("isHolding", Convert.ToSingle(m_characterState.isHolding));
        m_marioAnimator.SetBool("isGrounded", m_characterState.isGrounded);
        m_marioAnimator.speed = Mathf.Abs(m_marioRigibody.velocity.x) + ANIMATION_SPEED_MIN;
    }
}
