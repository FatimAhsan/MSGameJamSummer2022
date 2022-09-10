using System.Collections;
using UnityEngine;

public class CharacterAnimation
{
    public Animator _animator;

    private static int RunKey = Animator.StringToHash("run");
    private static int WalkKey = Animator.StringToHash("walk");

    public CharacterAnimation(Animator animator)
    {
        _animator = animator;
    }
    public void PlayAnimation(AnimationTypes type)
    {
        switch (type)
        {
            case AnimationTypes.walk: PlayWalk(); break;
            case AnimationTypes.run: PlayRun(); break;
        }
    }
    private void PlayWalk()
    {
        _animator.SetTrigger(WalkKey);
    }
    private void PlayRun()
    {
        _animator.SetTrigger(RunKey);
    }
}