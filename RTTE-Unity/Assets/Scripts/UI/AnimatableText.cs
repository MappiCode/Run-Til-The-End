using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatableText : MonoBehaviour
{
    public enum Animations { idle, pulsate }

    [SerializeField] private Animations _activeAnimation;
    public Animations activeAnimation
    {
        get { return _activeAnimation; }
        set 
        { 
            _activeAnimation = value; 
            SetAnimation(value);
        }
    }

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        activeAnimation = _activeAnimation;
    }

    private void SetAnimation(Animations anim)
    {
        animator.SetTrigger(anim.ToString());
    }
}
