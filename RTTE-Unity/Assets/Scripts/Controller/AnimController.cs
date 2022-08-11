using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] private Animator[] animators;

    private void Start()
    {
        // Some Initalizations
        DeactivadeAnimator("Player");
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
        Animator anim = animators.Where(x => x.name == animatorName).FirstOrDefault();
        if (anim != null)
            anim.enabled = enabled;
        else
            Debug.LogWarning("There is no AssignedAnimator named " + animatorName + " in the AnimController!");
    }
}
