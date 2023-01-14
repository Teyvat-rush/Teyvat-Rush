using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [Header("UI���")]
    public Text textLabel;  //�Ի��������text
    //public GameObject SkipButton; //������ť
    //public GameObject AutoButton; //�Զ����Ű�ť
    public GameObject Panel_Dialog; //�Ի����panel
    public GameObject Image_Next;
    public GameObject panel_CardSlot;
    public GameObject panel_Sun;
    public GameObject button_Menu;
    public GameObject Panel_ProgressBar;
    public GameObject panel_SelectCard;
    //public Text AutoText; //�Զ����Ű�ť�ġ��Զ����š��ı���text������ʵ���Զ��ֶ��л��Ĺ��ܣ�
    //public GameObject Warning; //������Ұ������������Ҫ�ɲ�Ҫ
    [Header("�ı��ļ�")]
    public TextAsset textfile; //�����ı���txt�ļ�
    public int index; //���е��˵ڼ��仰������ʵ�ֻ�������
    public float textSpeed = 0.05f; //ÿ���ֶ�ò��ܳ���

    //[Header("ͷ��")]
    //public GameObject A; //��ɫ��ͷ���Լ�����
    //public GameObject B; //��ɫ��ͷ���Լ�����
    //��Ϊ��ֱ�Ӱ����ֺ�ͷ���Ϊ���������ˣ�����ֻ������һ��GameObect
    public bool textStarted;  //�жϵ�һ��Ի��Ƿ�ʼ
    public bool textFinished; //�ж���仰�Ƿ�������ǡ���仰����
    //float i = 0f; //�ж��Ƿ�Ϊ�Զ������ֶ�����

    public List<string> textList = new List<string>(); //��txt�ļ��ĶԻ����ݵ����б���
    // Start is called before the first frame update
    void Awake()
    {
        textStarted = false;
        GetTextFromFile(textfile);
        index= 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(textFinished)
        {
            Image_Next.SetActive(true);
        }
        else
        {
            Image_Next.SetActive(false);
        }
        textSpeed = 0.05f;
        if (Input.GetKeyDown(KeyCode.Mouse0) && index == textList.Count)
        {
            
            
            EndDialogue();//����������������Ҳ��ŵ������һ��Ļ������������Ի��ĺ���
            
        }

        if(index==0 &&!textStarted)
        {
            textStarted=true;
            StartCoroutine(SetTextUI());//���������������ͬʱһ�仰�Ѿ������ˣ��ͼ���������һ��Ĳ���
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && textFinished && gameObject.activeSelf)
        {
            StartCoroutine(SetTextUI());//���������������ͬʱһ�仰�Ѿ������ˣ��ͼ���������һ��Ĳ���
            Image_Next.SetActive(false);
        }
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear(); //������ǵ�һ�ε��öԻ��򣬾���Ҫ��֮ǰһ�����жԻ����б�����
        index = 0; //���Ұ���ʾ�ڼ��仰��index����
        var lineData = file.text.Split('\n'); //���ı��ļ��Իس��ָ�һ���̨�ʺͽ�ɫ����
        foreach (var line in lineData)
        {
            textList.Add(line); //��һ���̨��¼��line�б���
        }
    }

    IEnumerator SetTextUI() //Э�̺����ı�׼��ʽ
    {
        textFinished = false; //���ڲ��ţ�����boolֵΪfalse
        textLabel.text = ""; //������һ������ʹ�ý�������text�ϣ�����Ҫ���
        for (int i = 0; i < textList[index].Length; i++)
        //����һ�仰��һ���������������û�е�һ��̨�����һ���ֵĻ���һֱ���
        {
            textLabel.text += textList[index][i]; //��֮ǰ�Ѿ������̨���мӽ��µ�����
            yield return new WaitForSeconds(textSpeed);//�ȴ�textSpeed�����ѭ��
        }
        textFinished = true; //�������ѭ��˵�������Ѿ������ˣ�����boolֵ��true
        index++; //��仰�Ѿ������ˣ�index++������һ�仰
    }
    public void EndDialogue()
    {//��114514���Ի������ȫ�����أ�����Ի��Ѿ�������
        gameObject.SetActive(false);
        panel_CardSlot.SetActive(true);
        panel_Sun.SetActive(true);
        button_Menu.SetActive(true);
        Panel_ProgressBar.SetActive(true);
        panel_SelectCard.SetActive(true);
        StopCoroutine(SetTextUI());
        //QingShan.SetActive(false);
        //Log.SetActive(false);
        //SkipButton.SetActive(false);
        //AutoButton.SetActive(false);
        index = 0; //��Ŀ¼�������ʼ��������һ�ο�ʼ���Ǵӵ�һ�䲥��
        return;
    }
}
