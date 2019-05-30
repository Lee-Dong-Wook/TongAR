/// <summary>
/// 작성 일시  : 2019. 04. 07. 
/// 수정 일시  : 2019. 05. 16.
/// 수정자     : 이동욱 
/// e-mail : dongwookRaynor@gmail.com 
/// 기능       : AI 애니메이션 
/// </summary>
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIanimController : MonoBehaviour
{
    private Animator anim;
    
  
    private void Awake()
    {
        anim = GetComponent<Animator>(); //반드시 필요 
        
    }
  
    public void AnimJumpTrue()
    {
        Debug.Log("anim active");
        anim.SetBool("isJumping", true);
    }

    public void AnimJumpFalse()
    {
        anim.SetBool("isJumping", false);
        Debug.Log("anim disable");
    }
}
