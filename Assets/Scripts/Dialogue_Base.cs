using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues")]
public class Dialogue_Base : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        [TextArea(3, 12)]
        public string myText;
        /*
        [Header("��ȭ �ε���")]
        public int dialogueIndex;
        */
        [Header("ĳ���� �̸�")]
        public Name charName;

        [Header("ȿ�� �ִϸ��̼�")]
        public H_Anim h_Anim;
        [Header("���� �ִϸ��̼�")]
        public Y_Anim y_Anim;
        [Header("�μ� �ִϸ��̼�")]
        public M_Anim m_Anim;

        [Header("����ȿ��")]
        public Direction direction;

        [Header("���� üũ")]
        public bool isCheck;

        [Header("��� �̹���")]
        public Sprite backGround;

    
    }

    public Info[] dialogueInfo;
    

}

public enum Name
{
    Blank,
    Player,
    Hujung,
    YoungJin,
    Jisu,
    MinSeok,
    Who
}

public enum H_Anim
{ 
    Idle,
    H_Appear,
    H_DisAppear,
    Start
}

public enum Y_Anim
{
    Idle,
    Y_Appear,
    Y_DisAppear,
    Start
}

public enum M_Anim
{
    Idle,
    M_Appear,
    M_DisAppear,
    Start
}


public enum Direction
{
    Blank,
    FadeIn,
    FadeOut
}

