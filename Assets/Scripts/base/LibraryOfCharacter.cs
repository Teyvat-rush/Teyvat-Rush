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
            ALLCharacters.Add(new LibraryOfCharacter("温 迪", "来路不明的吟游\n诗人。有时唱一\n些老掉牙的旧诗，\n有时又会唱出谁\n也没听过的新歌，\n像风一般捉摸不\n透。\n\n向右一行发射音符攻击敌人。", ALLImages[0], "C", "C", "A", "A", 0, 10, 1, "好感度等级加成：\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 生命值+\r\n     3 攻击力+\r\n     5 生命值++\r\n     8 攻击冷却时间-\r\n     10 攻击力++"));
            ALLCharacters.Add(new LibraryOfCharacter("莫 娜", "繁星闪耀，世人\r\n的命运早已注定。\r\n莫娜是一位奇特\r\n的占星术士——\r\n与其他的占星术\r\n士为了赏钱可以\r\n信口雌黄不同，\r\n莫娜替人占卜向来都是分文不取，但也不会对占卜的结果加以修饰。即便是会让人不悦的结果，她也会直截了当地告诉对方。\r\n\r\n生产星辉以供放置角色。", ALLImages[1], "C", "D", "D+", "A", 0, 10, 1, "好感度等级加成：\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 生命值+\r\n     3 再部署时间-\r\n     5 技能冷却时间-\r\n     8 费用-\r\n     10 再部署时间--"));
            ALLCharacters.Add(new LibraryOfCharacter("诺 艾 尔", "骑士团的餐会，\r\n酒业行业的商宴\r\n，普普通通的一\r\n顿烤肉…无论是\r\n哪里出了问题，\r\n诺艾尔都会如狂\r\n风一般出现，利\r\n落地解决问题。\r\n正因如此，也有人将她称为「万能女仆」。\r\n\r\n生命值很高，能暂时阻挡住敌人。", ALLImages[2], "S", "D", "D", "C", 0, 10, 1, "好感度等级加成：\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 无\r\n     3 费用-\r\n     5 再部署时间-\r\n     8 无\r\n     10 再部署时间--"));
            ALLCharacters.Add(new LibraryOfCharacter("阿 贝 多", "西风骑士团首席\r\n炼金术士阿贝多，\r\n正是这样一位神\r\n奇少年。\r\n财富和人脉不是\r\n他的目标。他渴\r\n望驾驭的，是从\r\n古到今深藏于人类头脑中的无上知识。\r\n\r\n召唤阳华，准备完成后给踩上的敌人造成高额火元素伤害。", ALLImages[3], "C+", "S", "D", "C", 0, 10, 1, "好感度等级加成：\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 无\r\n     3 无\r\n     5 生命值+\r\n     8 再部署时间-\r\n     10 再部署时间--"));
            ALLCharacters.Add(new LibraryOfCharacter("安 柏", "「侦察骑士安柏，\r\n准备就绪！」\r\n\r\n生成兔兔伯爵，\r\n经过短暂时间后\r\n对3*3范围内敌\r\n人造成高额火元\r\n素伤害。", ALLImages[4], "S+", "S", "S", "C", 0, 10, 1, "好感度等级加成：\r\nLv.\r\nLv.\r\nLv.\r\nLv.\r\nLv.", "\r\n     2 无\r\n     3 费用-\r\n     5 再部署时间-\r\n     8 无\r\n     10 再部署时间--"));
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
            Debug.Log("植物"+index+"好感度等级=" +(ALLCharacters[index].friendshipLevelNum+1));
            ALLCharacters[index].friendshipEXP -= friendshipEXPMAXs[ALLCharacters[index].friendshipLevelNum];
            ALLCharacters[index].friendshipLevelNum++; 

        }
    }
}