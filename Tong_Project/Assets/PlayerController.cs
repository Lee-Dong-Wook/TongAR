/*
 - 작성 일시 : 2019년 01월 22일 
 - 수정 일시 : 
 - 작성자    : 이동욱 
 - 작성 목적 : 해당 스크립트은 화면에 보이는 위치를 찍었을 때 플레이어가 그 위치로 이동하는지 확인 하기 위함.
 - 사용 기능명 및 기능 설명 
   1. MovePosition() : 스크린에 터치한 좌표에 해당하는 월드 좌표로 플레이어를 이동.  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
     NavMeshAgent navMeshController;

    Camera camera;

    

    void Start()
    {
        navMeshController = GetComponent<NavMeshAgent>();

        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();    
    }
    
    void Update()
    {
       
        if (Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began)
        {
            T_MovePosition();
        }

        if(Input.GetMouseButtonDown(0))
        {
            M_MovePosition();
        }
    }

    void T_MovePosition()
    {
        Ray orderToRay = camera.ScreenPointToRay(Input.GetTouch(0).position);

        RaycastHit rayInfo;

        if(Physics.Raycast(orderToRay,out rayInfo,Mathf.Infinity))
        {
            navMeshController.destination = rayInfo.point;
        }
    }

    void M_MovePosition()
    {
        Ray orderToRay = camera.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit rayInfo;

        if (Physics.Raycast(orderToRay, out rayInfo, Mathf.Infinity))
        {
            navMeshController.destination = rayInfo.point;
        }
    }
}
