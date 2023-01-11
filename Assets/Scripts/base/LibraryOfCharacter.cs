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
    public static List<LibraryOfCharacter> ALLCharacters = new List<LibraryOfCharacter>();
    public List<Sprite> ALLImages=new List<Sprite>();

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
        ALLCharacters.Add(new LibraryOfCharacter("�� ��", "��·����������\nʫ�ˡ���ʱ��һ\nЩ�ϵ����ľ�ʫ��\n��ʱ�ֻᳪ��˭\nҲû�������¸裬\n���һ��׽����\n͸��\n\n����һ�з�����������ħ�", ALLImages[0], "C", "C", "A", "A", 0, 10, 1, "�øжȵȼ��ӳɣ�\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 ����ֵ+\r\n     3 ������+\r\n     5 ����ֵ++\r\n     8 ������ȴʱ��-\r\n     10 ������++")); 
        ALLCharacters.Add(new LibraryOfCharacter("Ī ��", "������ҫ������\r\n����������ע����\r\nĪ����һλ����\r\n��ռ����ʿ����\r\n��������ռ����\r\nʿΪ����Ǯ����\r\n�ſڴƻƲ�ͬ��\r\nĪ������ռ���������Ƿ��Ĳ�ȡ����Ҳ�����ռ���Ľ���������Ρ������ǻ����˲��õĽ������Ҳ��ֱ���˵��ظ��߶Է���\r\n\r\n�����ǻ��Թ����ý�ɫ��", ALLImages[1], "C", "D", "D+", "A", 0, 10, 1, "�øжȵȼ��ӳɣ�\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 ����ֵ+\r\n     3 �ٲ���ʱ��-\r\n     5 ������ȴʱ��-\r\n     8 ����-\r\n     10 �ٲ���ʱ��--"));
        ALLCharacters.Add(new LibraryOfCharacter("�� ��", "�꿨�Ϳ�������\n��", ALLImages[1], "��", "��", "��", "��", 0, 10, 1, "�øжȵȼ��ӳɣ�\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 ...\r\n     3 ...\r\n     5 ...\r\n     8 ...\r\n     10 ..."));

    }

    // Update is called once per frame
    void Update()
    {
    }
}