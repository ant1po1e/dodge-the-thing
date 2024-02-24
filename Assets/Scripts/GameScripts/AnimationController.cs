using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    #region Singleton
    public static AnimationController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public Animator camAnim;
    public Animator playerAnim;


    public void PlayCameraAnimation(string anim, bool isActive)
    {
        camAnim.SetBool(anim, isActive);
    }

    public void PlayPlayerAnimation(string anim, bool isActive)
    {
        playerAnim.SetBool(anim, isActive);
    }
}
