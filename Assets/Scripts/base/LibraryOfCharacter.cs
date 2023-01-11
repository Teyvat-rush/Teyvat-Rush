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
        ALLCharacters.Add(new LibraryOfCharacter("温 迪", "来路不明的吟游\n诗人。有时唱一\n些老掉牙的旧诗，\n有时又会唱出谁\n也没听过的新歌，\n像风一般捉摸不\n透。\n\n向右一行发射音符攻击魔物。", ALLImages[0], "C", "C", "A", "A", 0, 10, 1, "好感度等级加成：\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 生命值+\r\n     3 攻击力+\r\n     5 生命值++\r\n     8 攻击冷却时间-\r\n     10 攻击力++")); 
        ALLCharacters.Add(new LibraryOfCharacter("莫 娜", "繁星闪耀，世人\r\n的命运早已注定。\r\n莫娜是一位奇特\r\n的占星术士——\r\n与其他的占星术\r\n士为了赏钱可以\r\n信口雌黄不同，\r\n莫娜替人占卜向来都是分文不取，但也不会对占卜的结果加以修饰。即便是会让人不悦的结果，她也会直截了当地告诉对方。\r\n\r\n生产星辉以供放置角色。", ALLImages[1], "C", "D", "D+", "A", 0, 10, 1, "好感度等级加成：\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 生命值+\r\n     3 再部署时间-\r\n     5 技能冷却时间-\r\n     8 费用-\r\n     10 再部署时间--"));
        ALLCharacters.Add(new LibraryOfCharacter("安 柏", "玛卡巴卡巴拉巴\n拉", ALLImages[1], "？", "？", "？", "？", 0, 10, 1, "好感度等级加成：\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 ...\r\n     3 ...\r\n     5 ...\r\n     8 ...\r\n     10 ..."));

    }

    // Update is called once per frame
    void Update()
    {
    }
}