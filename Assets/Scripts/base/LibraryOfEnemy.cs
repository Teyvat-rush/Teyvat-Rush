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
        ALLEnemies.Add(new LibraryOfEnemy("风 史 莱 姆", "逸散在自然之中\r\n的风元素凝聚形\r\n成的小小魔物。", ALLImages[0],"D","C+","B","B"));
        ALLEnemies.Add(new LibraryOfEnemy("大 型 风 史 莱 姆", "逸散在自然之中\r\n的风元素凝聚形\r\n成的小小魔物。\r\n\r\n相比于风史莱姆\r\n更具威胁。", ALLImages[1], "C", "B", "B", "B+"));
        ALLEnemies.Add(new LibraryOfEnemy("丘 丘 人", "提瓦特荒野中游\r\n荡的原始住民。\r\n\r\n与人类轮廓相似\r\n，却失去了智能\r\n与灵性。据记载\r\n，在大地上出没\r\n超过千年，却没有历史与文明。", ALLImages[2], "D+", "B", "A", "C"));
        ALLEnemies.Add(new LibraryOfEnemy("打 手 丘 丘 人", "提瓦特荒野中游\r\n荡的原始住民，\r\n有着最基础文明\r\n形态的人形魔物。\r\n坏脾气的部落战\r\n士，朴实地信奉\r\n着肌肉的力量。\r\n\r\n引领一大波魔物冲锋，相比于丘丘人更具威胁。", ALLImages[3], "C", "B", "A+", "B"));
        ALLEnemies.Add(new LibraryOfEnemy("木 盾 丘 丘 人", "提瓦特荒野中游\r\n荡的原始住民。\r\n\r\n木盾能抵抗一定\r\n伤害，相比于丘\r\n丘人更具威胁。", ALLImages[4], "B+", "B", "A", "C"));
        ALLEnemies.Add(new LibraryOfEnemy("木 盾 打 手 丘 丘 人", "提瓦特荒野中游\r\n荡的原始住民。\r\n\r\n木盾能抵抗一定\r\n伤害，相比于打\r\n手丘丘人更具威\r\n胁。", ALLImages[5], "B+", "B", "A+", "B"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
