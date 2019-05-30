/// <summary>
/// 작성 일시  : 2019. 05. 16. 
/// 수정 일시  : 2019. 05. 17.
/// 수정자     : 이동욱 
/// e-mail : dongwookRaynor@gmail.com 
/// 기능       : 알파카 오브젝트 조작 
/// </summary>
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlpacaController : MonoBehaviour
{

    private Touch               touch;
    private Camera              FirstPersonCamera;
    private AIanimController    AIanim;
    private Rigidbody           rb;

    private float               force            = 150f;
    private float               speed            = 1.0f; 
    private float               stoppingDistance = 1.6f;

    private bool                react            = false;  //반응했는지 알아내는 flag
    bool hitPlane = true;
    private void Awake()
    {
        
        Debug.Log("Alpaca control");
        FirstPersonCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        rb                = GetComponent<Rigidbody>();

        

    }
    private void Update()   
    {
        AlpacaInteraction();
    }

    private void AlpacaInteraction()
    {
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        Ray        raycast = FirstPersonCamera.ScreenPointToRay(touch.position);
        RaycastHit raycastHit;
        
        


        if (Physics.Raycast(raycast, out raycastHit))
        {
            Debug.Log("Something Hit");
            if ((raycastHit.collider.tag == "AI"))      //&& (hitPlane == true)
            {
                Debug.Log("alpaca clicked");
                
                React();       
            }
        }

        else
        {
            Debug.Log("No hit detected");
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "hitPlane")
    //    {
    //        hitPlane = true;
    //    }

    //    else
    //    {
    //        hitPlane = false; 
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void React()
    {   
            rb.AddForce(0, force, 0);
        
        react = true;
    }

    
  

private void FollowMetoPosition()
    {
        if(FirstPersonCamera != null)       //FirstPersonCamera에 카메라가 할당되어 있다면 조건문 참 
        {

            //알파카의 위치에서 카메라의 위치사이 거리가 stoppingDistance 보다 크면 실행 
            if (react == true && Vector3.Distance(transform.position, FirstPersonCamera.transform.position) > stoppingDistance)
            {
                Vector3 camPos   = FirstPersonCamera.transform.position;        //카메라의 위치를 담는 변수
                        camPos.y = 0;                                           //카메라 위치의 y좌표를 0으로 한다. 
                                                                                //알파카가 y축에 대해서는 항상 0으로 생각하여 위를 향하지 않는다. 

                //알파카 위치에서 카메라 위치까지 위치 이동 
                transform.position = Vector3.MoveTowards(transform.position, camPos, speed * Time.deltaTime);

                //벡터계산 
                var lookPos   = FirstPersonCamera.transform.position - transform.position;
                    lookPos.y = 0.0f;       //y축값은 0 

                var rotation       = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10.0f);
            }

            else
            {
                react = false;
            }
        }
    }
}
