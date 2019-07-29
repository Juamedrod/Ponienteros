using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSprite : MonoBehaviour
{
    public Sprite play;
    public Sprite pause;
    public Image image;
    public Animator animator;

    public void PlaySprite()
    {
        image.sprite = play;
        animator.SetBool("pause", false);
    }

    public void PauseSprite()
    {
        image.sprite = pause;
        animator.SetBool("pause", true);
    }
}
