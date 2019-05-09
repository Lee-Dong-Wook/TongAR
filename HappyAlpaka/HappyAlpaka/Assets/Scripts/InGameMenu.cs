/*  
 *  작성일 : 2019.04.18
 *  작성자 : 손지해
 *  내  용 : 게임 진행 화면 우측 상단에 위치한 일시정지 버튼을 눌렀을 때 발생하는 이벤트에 대한 스크립트이다.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    private static bool gamePaused = false;      // 게임이 일시정지 되었는지 확인하기 위한 변수
    private GameObject pauseButton;              // 화면 우측 상단에 위치한 일시정지 버튼
    private GameObject pauseMenuUI;              // pauseButton 터치 시 화면에 보여지는 UI
    


    void Start()
    {
        pauseButton = GameObject.FindGameObjectWithTag("InGamePause");
        pauseMenuUI = GameObject.FindGameObjectWithTag("InGamePauseMenuUI");

        pauseButton.SetActive(true);            
        pauseMenuUI.SetActive(false);
    }

    /// <summary>
    /// 일시정치 버튼을 터치했을 때 실행되는 함수.
    /// pauseButton을 숨기고, pauseMenuUI를 보여준다.
    /// </summary>
    public void PauseButtonClicked()
    {
        pauseButton.SetActive(false);
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0;
        gamePaused = true;
    }

    /// <summary>
    /// pauseMenuUI의 MAINMENU 버튼 터치 시 실행되는 함수
    /// 어플리케이션 첫 화면인 메인 메뉴 씬을 호출하는 함수이다.
    /// 시스템을 활성화 한다.
    /// </summary>
    public void BackToMainMenu()
    {
        pauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1;
        gamePaused = false;
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// pauseMenuUI의 SAVE GAME버튼 클릭 시 실행되는 함수
    /// </summary>
    public void SaveGame()
    {

    }

    /// <summary>
    /// pauseMenuUI의 RESUME버튼 터치시 실행되는 함수
    /// pauseButton을 다시 보여주고, 시스템 중지를 해제한다.
    /// </summary>
    public void Resume()
    {
        pauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1;
        gamePaused = false;
    }

    /// <summary>
    /// 게임 종료 화면
    /// -------게임 종료 여부를 묻는 팝업 메뉴 추가하자.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
