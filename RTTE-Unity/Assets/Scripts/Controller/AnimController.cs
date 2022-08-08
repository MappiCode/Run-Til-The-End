using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    [Serializable]
    private struct AssignedAnimator
    {
        public string name;
        public Animator animator;
    }
    [SerializeField] private AssignedAnimator[] animators;

    private void Start()
    {
        // Some Initalizations
        DeactivadeAnimator("player");
    }

    public void ActivateAnimator(string animatorName)
    {
        AnimatorActivation(animatorName, true);
    }
    public void DeactivadeAnimator(string animatorName)
    {
        AnimatorActivation(animatorName, false);
    }

    private void AnimatorActivation(string animatorName, bool enabled)
    {
        Animator anim = animators.Where(x => x.name == animatorName).FirstOrDefault().animator;
        if (anim != null)
            anim.enabled = enabled;
        else
            Debug.LogWarning("There is no AssignedAnimator named " + animatorName + " in the AnimController!");
    }
}
