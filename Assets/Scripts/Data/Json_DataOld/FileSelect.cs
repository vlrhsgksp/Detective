using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class FileSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject creatPanel;
    [SerializeField]
    private TextMeshProUGUI[] slotText;
    [SerializeField]
    private TextMeshProUGUI fileName;


    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;

        Create();       // ����� �����Ͱ� ������ Create() ȣ��
        // ����� �����Ͱ� ������ ��������� �̵�
        DataManager.instance.Load();
        GoHome();  // �ӽ�
    }

    public void Create()
    {
        creatPanel.gameObject.SetActive(true);
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}
