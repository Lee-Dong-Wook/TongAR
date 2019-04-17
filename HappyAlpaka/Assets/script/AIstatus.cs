/// <summary>
/// 작성 일시  : 2019. 04. 03. 
/// 수정 일시  : 2019. . .
/// 수정자     : 이동욱 
/// e-mail : dongwookRaynor@gmail.com 
/// 기능       : AI상태에 따라 오브젝트의 생명관리, 상태에 따라 할 수 있는 동작, 기능 등을 제어  
/// </summary>
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIstatus : MonoBehaviour
{

    enum Status { Best, Good, Bad, };       //AI 상태 열거형 

    Status status;

    private float maxValue = 100f;
   
    private float mood;                     //기분
    private float hunger;                   //배고픔   
    private float healthy;                  //건강     

    private void Living()                                   //기분, 배고픔, 건강 감소 
    {
        if (mood <= 0 || hunger <= 0 || healthy <= 0)
        {
            Debug.Log("AI died");
            Destroy(gameObject,1f);   
        }
        else
        {
            mood -= 0.5f;
            hunger -= 0.5f;
            healthy -= 0.5f;
            Debug.Log(" mood = " + mood + " hunger = " + hunger + " healthy = " + healthy);
        }
    }

    
    private void ChangeStatus()                             //수치변경이 되면 상태 변환 
    {
        if (mood >= 80 || hunger >= 80 || healthy >= 80)
        {
            status = Status.Best;
            Debug.Log(" Feel Best! ");
        }

        else if (mood >= 50 || hunger >= 50 || healthy >= 50) 
        {
            status = Status.Good;
            Debug.Log(" Feel Good! ");
        }

        else if (mood <= 10 || hunger <= 10 || healthy <= 10)
        {
            status = Status.Bad;
            Debug.Log(" Feel Bad! ");
        }
    }

    private void Awake()
    {
        mood = maxValue;
        hunger = maxValue;
        healthy = maxValue;
    }

    private void Update()
    {
        Living();
        ChangeStatus();

        switch (status)
        {
            case Status.Best :
                break;

            case Status.Good :
                break;

            case Status.Bad :

                break;
        }
        
    }
}
