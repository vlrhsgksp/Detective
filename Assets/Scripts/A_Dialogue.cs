using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class A_Dialogue : MonoBehaviour
{
    public static A_Dialogue instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("fix this " + gameObject.name);
        }
        else
            instance = this;
    }

    

    [Header("DialogueGroup")]
    public TextMeshProUGUI dialogueTxt;       
    public TextMeshProUGUI nameTxt;
    public Image backGroundImg;                // ��� �̹���
    public GameObject next;                    // ȭ��ǥ ������Ʈ
    public GameObject textPrefab;              // ��α� ���� �ؽ�Ʈ ������
    public Transform parentContents;           // ��α��� Contents���� ��µ�

    /*
    [Header("DialogueSprite")]
    public Image character01;                  // ���л� ĳ����
    public Image character02;                  // ģ�� ĳ����
    public Image character03;                  // �����ο� ĳ����
    public Image character04;                  // ���ġ ĳ����
    */
    [Header("TextTypingGroup")]
    public float delay;                        //�ؽ�Ʈ ��� ������ 
    private bool isTextTyping;                 // �ؽ�Ʈ ��� ���� Ȯ��
    public bool isTextComplete = false;               // �ؽ�Ʈ ��� �ϼ� ���� Ȯ��
    private string completeText;               // �ϼ��� �ؽ�Ʈ

    private bool isDialoge;                   // ��ȭ ���� Ȯ��

    [Header("DialogueEnd")]
    public GameObject dialogueUI;              // ��ȭ�� ���� UI
    public GameObject InGameUI;                // �ΰ��� ���� UI

    [Header("Animation")]
    public Animator Hujung;                    // ȿ�� ���� �ִϸ�����
    public Animator YoungJin;                  // ���� ���� �ִϸ�����
    public Animator MinSeok;                   // �μ� ���� �ִϸ�����
    

    [Header("Direction")]
    public Animator fadeManager;                // ���̵� �� / �ƿ� ���� ȿ��

    [Header("DialogueNum")]
    public int dialogueID;                     // �ش� ��ȭ�� ID
    public int dialogueIndex;                  // ��ȭ �ε���

    
    public Scene NowScene;
    public int SceneNum;

    // Dialogue_Base ���� ������ Queue�� ����
    public Queue<Dialogue_Base.Info> dialogueInfo = new Queue<Dialogue_Base.Info>();

    private void Start()
    {
        dialogueInfo = new Queue<Dialogue_Base.Info>();
        dialogueIndex = dialogueIndex - 1;

        // ���� �������� ��ȭ�� ��ȭ �ε����� GameManager �Լ��� ����
        //dialogueID = GameManager.instance.dialgoueID;
        //dialogueIndex = GameManager.instance.dialogueIndex;
    }

    private void Update()
    {
        NowScene = SceneManager.GetActiveScene(); // �� �����Ӹ��� ���� �� Ȯ���ϱ�
        SceneNum = NowScene.buildIndex;
    }

    // ��ȭ ����Ʈ ����(EnQueue)
    public void EnqueuDialogue(Dialogue_Base db)
    {
        if (isDialoge) return;

        isDialoge = true;

        dialogueInfo.Clear();

        foreach(Dialogue_Base.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        DequeueDialogue();


    }

    //��ȭ ��� ����(DeQueue)
    public void DequeueDialogue()
    {
        #region TextTyping
        isTextComplete = false;

        // �ش� ��� ����Ʈ�� ���� �����ٸ� ��ȭ ���� �Լ��� �̵�
        if(dialogueInfo.Count == 0)
        {
            EndDialogue();
            return;
        }

        // �ؽ�Ʈ�� ��� ���� ��� 
        if(isTextTyping == true)
        {
            CompleteText();
            StopAllCoroutines();
            isTextTyping = false;
            isTextComplete = true;
            return;
        }
        #endregion

        #region DequeueCon
        // Dequeue, info(Dialogue_Base)�� �ִ� ���� ���
        Dialogue_Base.Info info = dialogueInfo.Dequeue();

        //dialogueIndex = info.dialogueIndex;
        
        completeText = info.myText;

        dialogueTxt.text = info.myText;

        backGroundImg.sprite = info.backGround;
        #endregion

        #region CharacterName
        if (info.isCheck == true)
        {
            Debug.Log("CheckOn");
        }

        if (info.charName == Name.Blank)
        {
            nameTxt.text = "";
        }

        if (info.charName == Name.Player)
        {
            nameTxt.text = "���ΰ�";
        }

        if (info.charName == Name.Hujung)
        {
            nameTxt.text = "��ȿ��";
        }

        if(info.charName == Name.YoungJin)
        {
            nameTxt.text = "�̿���";
        }

        if (info.charName == Name.Jisu)
        {
            nameTxt.text = "������";
        }

        if (info.charName == Name.MinSeok)
        {
            nameTxt.text = "���μ�";
        }

        if (info.charName == Name.Who)
        {
            nameTxt.text = "???";
        }
        #endregion

        #region CharacterAnim

        #region HujungAnim
        // ȿ�� �ִϸ��̼� ���
        if (info.h_Anim == H_Anim.H_Appear)
        {
            Hujung.Play("H_Appear");
        }

        if(info.h_Anim == H_Anim.H_DisAppear)
        {
            Hujung.Play("H_DisAppear");
        }

        if (info.h_Anim == H_Anim.Start)
        {
            Hujung.Play("H_Start");
        }
        #endregion

        #region YoungJinAnim
        if (info.y_Anim == Y_Anim.Y_Appear)
        {
            YoungJin.Play("Y_Appear");
        }

        if (info.y_Anim == Y_Anim.Y_DisAppear)
        {
            YoungJin.Play("Y_DisAppear");
        }

        if (info.y_Anim == Y_Anim.Start)
        {
            YoungJin.Play("Y_Start");
        }
        #endregion

        #region MinSeokAnim
        // �μ� �ִϸ��̼� ���
        if (info.m_Anim == M_Anim.M_Appear)
        {
            MinSeok.Play("M_Appear");
        }

        if (info.m_Anim == M_Anim.M_DisAppear)
        {
            MinSeok.Play("M_DisAppear");
        }

        if (info.m_Anim == M_Anim.Start)
        {
            MinSeok.Play("M_Start");
        }
        #endregion

        #endregion

        #region Direction
        if (info.direction == Direction.FadeIn)
        {
            fadeManager.Play("FadeIn");
        }

        if (info.direction == Direction.FadeOut)
        {
            fadeManager.Play("FadeOut");
        }
        #endregion

        #region BackLog
        // ��α� �ؽ�Ʈ ���
        GameObject clone = Instantiate(textPrefab, parentContents);
        if(info.charName == Name.Blank)
        {
            clone.GetComponent<TextMeshProUGUI>().text = dialogueTxt.text;
        }
        else
        {
            clone.GetComponent<TextMeshProUGUI>().text = nameTxt.text + " : " + dialogueTxt.text;
        }
        #endregion

        dialogueTxt.text = "";
        StartCoroutine(TypeText(info));
        dialogueIndex++;
    }

    // �ؽ�Ʈ �Է� �ڷ�ƾ
    IEnumerator TypeText(Dialogue_Base.Info info)
    {
        isTextTyping = true;
        next.SetActive(false);

        foreach(char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueTxt.text += c;
        }
        next.SetActive(true);
        isTextTyping = false;
        yield return new WaitForSeconds(2f);
        isTextComplete = true;
        
    }

    // �ؽ�Ʈ �ڵ��ϼ� �޼ҵ�(Ŭ�� �� �ڵ����� �ؽ�Ʈ�� �ϼ��ǵ���)
    private void CompleteText()
    {
        isTextComplete = true;
        dialogueTxt.text = completeText;
        next.SetActive(true);
    }

    // ��ȭ ���� �޼ҵ�
    public void EndDialogue()
    {
        isDialoge = false;
        dialogueUI.SetActive(false);
        ChapterCheck.instance.isPrologueComplete = true;
        SceneManager.LoadScene(0);
    }

}
