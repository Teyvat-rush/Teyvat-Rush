using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryOfEnemy : MonoBehaviour
{
    public string characterName;
    public string description;
    public Sprite image;
    public string HPLevel;
    public string ATKLevel;
    public string ATKIntervalLevel;
    public string MoveVelocityLevel;
    public static List<LibraryOfEnemy> ALLEnemies = new List<LibraryOfEnemy>();
    public List<Sprite> ALLImages;

    public LibraryOfEnemy(string characterName, string description, Sprite image, string hPLevel, string aTKLevel, string aTKIntervalLevel, string moveVelocityLevel)
    {
        this.characterName = characterName;
        this.description = description;
        this.image = image;
        HPLevel = hPLevel;
        ATKLevel = aTKLevel;
        ATKIntervalLevel = aTKIntervalLevel;
        MoveVelocityLevel = moveVelocityLevel;
    }

    // Start is called before the first frame update
    void Awake()
    {
        ALLEnemies.Add(new LibraryOfEnemy("�� ʷ �� ķ", "��ɢ����Ȼ֮��\r\n�ķ�Ԫ��������\r\n�ɵ�ССħ�", ALLImages[0],"D","C+","B","B"));
        ALLEnemies.Add(new LibraryOfEnemy("�� �� �� ʷ �� ķ", "��ɢ����Ȼ֮��\r\n�ķ�Ԫ��������\r\n�ɵ�ССħ�\r\n\r\n����ڷ�ʷ��ķ\r\n������в��", ALLImages[1], "C", "B", "B", "B+"));
        ALLEnemies.Add(new LibraryOfEnemy("�� �� ��", "�����ػ�Ұ����\r\n����ԭʼס��\r\n\r\n��������������\r\n��ȴʧȥ������\r\n�����ԡ��ݼ���\r\n���ڴ���ϳ�û\r\n����ǧ�꣬ȴû����ʷ��������", ALLImages[2], "D+", "B", "A", "C"));
        ALLEnemies.Add(new LibraryOfEnemy("�� �� �� �� ��", "�����ػ�Ұ����\r\n����ԭʼס��\r\n�������������\r\n��̬������ħ�\r\n��Ƣ���Ĳ���ս\r\nʿ����ʵ���ŷ�\r\n�ż����������\r\n\r\n����һ��ħ���棬����������˸�����в��", ALLImages[3], "C", "B", "A+", "B"));
        ALLEnemies.Add(new LibraryOfEnemy("ľ �� �� �� ��", "�����ػ�Ұ����\r\n����ԭʼס��\r\n\r\nľ���ֿܵ�һ��\r\n�˺����������\r\n���˸�����в��", ALLImages[4], "B+", "B", "A", "C"));
        ALLEnemies.Add(new LibraryOfEnemy("ľ �� �� �� �� �� ��", "�����ػ�Ұ����\r\n����ԭʼס��\r\n\r\nľ���ֿܵ�һ��\r\n�˺�������ڴ�\r\n�������˸�����\r\nв��", ALLImages[5], "B+", "B", "A+", "B"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
