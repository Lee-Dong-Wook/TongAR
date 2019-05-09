/*  
 *  작성일 : 2019.04.18
 *  작성자 : 손지해       (thswlgo38@gmail.com)
 *  내  용 : 어플리케이션 시작 시 보여지는 메인 메뉴에 대한 스크립트이다.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// 게임 화면 로드
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// 저장된 게임 선택 화면 로드
    /// </summary>
    public void LoadSavedData()
    {
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// 어플리케이션 종료
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
