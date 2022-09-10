using DG.Tweening;
using UnityEngine;

public class CharacterController : MonoBehaviour
{/*
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    private CharacterAnimation characterAnimation;
    private Sequence sequenceEnter;


    // Start is called before the first frame update
    void Start()
    {
        characterAnimation = new CharacterAnimation(_animator);
        PlayEnterSequence();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayDanceAnimation();
        }
    }

    private void Jump()
    {
        transform.DOJump(Vector3.zero, 2, 1, 1f);
    }

    private void PlayEnterSequence()
    {
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;

        sequenceEnter?.Kill();

        sequenceEnter = DOTween.Sequence()
            .AppendCallback(PlayWalkAnimation)
            .Join(transform.DOMove(endPoint.position, 3f))
            .Join(transform.DORotateQuaternion(endPoint.rotation, 1f));

    }

    private void PlayRunAnimation() => characterAnimation.PlayAnimation(AnimationTypes.run);
    private void PlayWalkAnimation() => characterAnimation.PlayAnimation(AnimationTypes.walk);

    */
}