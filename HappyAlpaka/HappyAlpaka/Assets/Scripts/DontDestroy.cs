/*  
 *  작성일 : 2019.04.18
 *  작성자 : 손지해       (thswlgo38@gmail.com)
 *  내  용 : 씬 재호출 시 씬상의 오브젝트들이 Destroy 되는것을 막기위한 스크립트
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
