using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour
{
    public GameObject button;
    public Vector3 shrinkSize, enlargeSize;
    public float animationDuration;
    public Vector3 finalPosition;
    public Vector3 initalPosition;

    public Ease easing;
    public Vector3 rotation;
    public void ShrinkUI()
    {
        button.transform.DOScale(shrinkSize,animationDuration).OnComplete(()=> button.transform.DOScale(Vector3.one, animationDuration));
    }
    public void EnlargeUI()
    {
        button.transform.DOScale(enlargeSize, animationDuration);
    }
    public void MoveButton()
    {
        //move = vector 3 end value, animation duration
        button.transform.DOLocalMove(finalPosition, animationDuration).SetEase(easing).OnComplete(()=> ReversePositionButton());
    }
    public void ReversePositionButton()
    {
        button.transform.DOLocalMove(initalPosition, animationDuration).SetEase(easing).OnComplete(()=> MoveButton());
    }
    public void ShakeButton()
    {
        //float duration, strength = 1 min, vibrato = 10 min, randomness = 90 min
        button.transform.DOShakePosition(5,250,10,90);
        button.transform.DOShakeScale(5,250,10,90);
    }
    public void FadeButton()
    {
        Image colorButton;
        colorButton = button.GetComponent<Image>();
        colorButton.DOFade(0,animationDuration);
    }
    public void RotateButton()
    {
        //vector3, duration, rotate mode
        button.transform.DOLocalRotate(rotation,5,RotateMode.FastBeyond360);
    }
    public void JumpButton()
    {
        //jump = vector3 end postion, float jump power, int number of jumps, float duration
        button.transform.DOLocalJump(finalPosition,8.5f,6,2);
    }
}
