/// <summary>
/// 작성 일시  : 2019. 04. 07. 
/// 수정 일시  : 2019. . .
/// 수정자     : 이동욱 
/// e-mail : dongwookRaynor@gmail.com 
/// 기능       : AI 동작 제어 
/// </summary>
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIanimController : MonoBehaviour
{
    private Animator anim;

    private Camera FirstPersonCamera;

    private Touch touch;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        FirstPersonCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
  
    public void AnimJumpTrue(){ anim.SetBool("isJumping", true); }

    public void AnimJumpFalse(){ anim.SetBool("isJumping", false);
}

    private void Update()
    {
        Interaction();
    }

    private void Interaction()
    {
        //If the player has not touched the screen, we are done with this update.
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        Ray raycast = FirstPersonCamera.ScreenPointToRay(touch.position);
        RaycastHit raycastHit;
        if (Physics.Raycast(raycast, out raycastHit))
        {
            Debug.Log("Something Hit");
            if (raycastHit.collider.tag == "AI")
            {
                AnimJumpTrue();
                //Anim.GetComponent<AIanimController>().AnimJumpTrue();
                Debug.Log("andy clicked");
            }
        }
        else
        {
            AnimJumpFalse();
            //Anim.GetComponent<AIanimController>().AnimJumpFalse();
            Debug.Log("No hit detected");
        }
    }


}
