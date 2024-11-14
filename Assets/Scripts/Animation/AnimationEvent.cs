using Assets.Scripts.Interfaces;
using UnityEngine;

[RequireComponent(typeof(IAnimEventExecute))]
public class AnimationEvent : MonoBehaviour
{
    //public AnimationClip AnimationClip;
    public Animator Animator;
   
    public float Time;
    public int AnimClipIndex;

    void Start()
    {
        AnimationClip AnimationClip;
        Animator Animator;

        UnityEngine.AnimationEvent animEvent;
        animEvent = new UnityEngine.AnimationEvent
        {
            //intParameter = 12345,
            time = Time,
            functionName = "AnimationEventFunc"
        };

        Animator = GetComponent<Animator>();
        AnimationClip = Animator.runtimeAnimatorController.animationClips[AnimClipIndex];
        AnimationClip.AddEvent(animEvent);
    }

    public void AnimationEventFunc()
    {
        if (!TryGetComponent<IAnimEventExecute>(out var ExecutableObject))
        {
            Debug.LogError("AnimationEvent is missing required IAnimEventExecute");
            return;
        }

        ExecutableObject?.Execute();
    }
}

