using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimController : MonoBehaviour
{
    public enum Animations { idle, pulsate }

    public static Dictionary<Animations, AnimationClip> animations = new Dictionary<Animations, AnimationClip>();

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        AnimationClip[] allAnims = animator.runtimeAnimatorController.animationClips;

        for (int i = 0; i < allAnims.Length; i++)
        {
            animations.Add((Animations)i, allAnims[i]);
        }
    }
}
