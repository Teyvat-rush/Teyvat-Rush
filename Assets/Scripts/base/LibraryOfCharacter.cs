using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryOfCharacter : MonoBehaviour
{
    public string characterName;
    public string description;
    public Sprite image;
    public string HPLevel;
    public string ATKLevel;
    public string ATKorSkillInterval;
    public string reloadTimeLevel;
    public int friendshipEXP;
    public int friendshipEXPMAX;
    public int friendshipLevelNum;
    public string friendshipLevelRewardTitle;
    public string friendshipLevelReward;
    public List<Sprite> ALLImages = new List<Sprite>();
    public static List<LibraryOfCharacter> ALLCharacters = new List<LibraryOfCharacter>();
    
    public static List<int> friendshipEXPMAXs = new List<int>(){ 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,0};
    public static bool isFirst=true;
    public LibraryOfCharacter(string characterName, string description, Sprite image, string hPLevel, string aTKLevel, string aTKorSkillInterval, string reloadTimeLevel, int friendshipEXP, int friendshipEXPMAX, int friendshipLevelNum, string friendshipLevelRewardTitle, string text_FriendshipLevelReward)
    {
        this.characterName = characterName;
        this.description = description;
        this.image = image;
        HPLevel = hPLevel;
        ATKLevel = aTKLevel;
        ATKorSkillInterval = aTKorSkillInterval;
        this.reloadTimeLevel = reloadTimeLevel;
        this.friendshipEXP = friendshipEXP;
        this.friendshipEXPMAX = friendshipEXPMAX;
        this.friendshipLevelNum = friendshipLevelNum;
        this.friendshipLevelRewardTitle = friendshipLevelRewardTitle;
        this.friendshipLevelReward = text_FriendshipLevelReward;
    }



    // Start is called before the first frame update
    void Awake()
    {   
        if(isFirst)
        {
            ALLCharacters.Clear();
            ALLCharacters.Add(new LibraryOfCharacter("�� ��", "��·����������\nʫ�ˡ���ʱ��һ\nЩ�ϵ����ľ�ʫ��\n��ʱ�ֻᳪ��˭\nҲû�������¸裬\n���һ��׽����\n͸��\n\n����һ�з��������������ˡ�", ALLImages[0], "C", "C", "A", "A", 0, 10, 1, "�øжȵȼ��ӳɣ�\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 ����ֵ+\r\n     3 ������+\r\n     5 ����ֵ++\r\n     8 ������ȴʱ��-\r\n     10 ������++"));
            ALLCharacters.Add(new LibraryOfCharacter("Ī ��", "������ҫ������\r\n����������ע����\r\nĪ����һλ����\r\n��ռ����ʿ����\r\n��������ռ����\r\nʿΪ����Ǯ����\r\n�ſڴƻƲ�ͬ��\r\nĪ������ռ���������Ƿ��Ĳ�ȡ����Ҳ�����ռ���Ľ���������Ρ������ǻ����˲��õĽ������Ҳ��ֱ���˵��ظ��߶Է���\r\n\r\n�����ǻ��Թ����ý�ɫ��", ALLImages[1], "C", "D", "D+", "A", 0, 10, 1, "�øжȵȼ��ӳɣ�\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 ����ֵ+\r\n     3 �ٲ���ʱ��-\r\n     5 ������ȴʱ��-\r\n     8 ����-\r\n     10 �ٲ���ʱ��--"));
            ALLCharacters.Add(new LibraryOfCharacter("ŵ �� ��", "��ʿ�ŵĲͻᣬ\r\n��ҵ��ҵ������\r\n������ͨͨ��һ\r\n�ٿ��⡭������\r\n����������⣬\r\nŵ�����������\r\n��һ����֣���\r\n��ؽ�����⡣\r\n������ˣ�Ҳ���˽�����Ϊ������Ů�͡���\r\n\r\n����ֵ�ܸߣ�����ʱ�赲ס���ˡ�", ALLImages[2], "S", "D", "D", "C", 0, 10, 1, "�øжȵȼ��ӳɣ�\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 ��\r\n     3 ����-\r\n     5 �ٲ���ʱ��-\r\n     8 ��\r\n     10 �ٲ���ʱ��--"));
            ALLCharacters.Add(new LibraryOfCharacter("�� �� ��", "������ʿ����ϯ\r\n������ʿ�����࣬\r\n��������һλ��\r\n�����ꡣ\r\n�Ƹ�����������\r\n����Ŀ�ꡣ����\r\n����Ԧ�ģ��Ǵ�\r\n�ŵ������������ͷ���е�����֪ʶ��\r\n\r\n�ٻ�������׼����ɺ�����ϵĵ�����ɸ߶��Ԫ���˺���", ALLImages[3], "C+", "S", "D", "C", 0, 10, 1, "�øжȵȼ��ӳɣ�\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 ��\r\n     3 ��\r\n     5 ����ֵ+\r\n     8 �ٲ���ʱ��-\r\n     10 �ٲ���ʱ��--"));
            ALLCharacters.Add(new LibraryOfCharacter("�� ��", "�������ʿ���أ�\r\n׼����������\r\n\r\n�������ò�����\r\n��������ʱ���\r\n��3*3��Χ�ڵ�\r\n����ɸ߶��Ԫ\r\n���˺���", ALLImages[4], "S+", "S", "S", "C", 0, 10, 1, "�øжȵȼ��ӳɣ�\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 ��\r\n     3 ����-\r\n     5 �ٲ���ʱ��-\r\n     8 ��\r\n     10 �ٲ���ʱ��--"));
            isFirst = false;
        }

        //Debug.Log("6");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void UpdateFreindship(int index)
    {
        if (ALLCharacters[index].friendshipEXP >= friendshipEXPMAXs[ALLCharacters[index].friendshipLevelNum] && ALLCharacters[index].friendshipLevelNum < 10)
        {
            Debug.Log("ֲ��"+index+"�øжȵȼ�=" +(ALLCharacters[index].friendshipLevelNum+1));
            ALLCharacters[index].friendshipEXP -= friendshipEXPMAXs[ALLCharacters[index].friendshipLevelNum];
            ALLCharacters[index].friendshipLevelNum++; 

        }
    }
}