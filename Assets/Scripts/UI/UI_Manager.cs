using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    #region Singleton
    public static UI_Manager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("fix this " + gameObject.name);
        }
        else
            instance = this;
    }
    #endregion

    [SerializeField]
    private GameObject backLogScrollView;              // ��α� ��ũ�Ѻ�

   [SerializeField]
    private GameObject pausePopup;                     // ����(Ÿ��) ��ư
    

    public bool isAuto;                                // ���� �ؽ�Ʈ ���

    [SerializeField]
    private GameObject popUpObj;                       // �˾�â
    [SerializeField]
    private GameObject gameOptionObj;                  // ���� �κ� ��� ���(�ӽ�)
    [SerializeField]
    private GameObject chapterSelectObj;               // é�� ���� ���

    public GameManager gameManager;


    #region Button Click Next Scene
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void StartPrologue()
    {
        SceneManager.LoadScene(1);
    }

    /*
    public void StartChapter1()
    {

    }


    public void StartChapter2()
    {

    }

    public void StartChapter3()
    {

    }

    public void StartChapter4()
    {

    }

    */

    public void GameExit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.ExitPlaymode();
    }

    #endregion

    #region Dialogue Logic
    public void BackLogOn()
    {
        backLogScrollView.gameObject.SetActive(true); 
    }

    public void BackLogOff()
    {
        backLogScrollView.gameObject.SetActive(false);
    }

    public void Pause()
    {
        pausePopup.gameObject.SetActive(true);
    }

    public void PauseOut()
    {
        pausePopup.gameObject.SetActive(false);
    }

    public void AutoOn()
    {
        isAuto = true;
    }

    public void AutoOff()
    {
        isAuto = false;
    }
    #endregion

    #region GameOption
    public void ChapterListOn()
    {
        gameOptionObj.gameObject.SetActive(false);
        chapterSelectObj.gameObject.SetActive(true);
    }

    public void ChapterListOff()
    {
        chapterSelectObj.gameObject.SetActive(false);
        gameOptionObj.gameObject.SetActive(true);
    }

    public void popUpOn()
    {
        popUpObj.gameObject.SetActive(true);
    }

    public void popUpOff()
    {
        popUpObj.gameObject.SetActive(false);
    }


    #endregion

    public void Save()
    {

    }
}
