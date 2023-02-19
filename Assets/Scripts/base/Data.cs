using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data",menuName ="DATA",order =1)]
public class Data : ScriptableObject
{
    public List<Data> AllData = new List<Data>();
  //public int Moranum;
}
[System.Serializable]
//public class Coin
//{
//  public int num;
//}
//[System.Serializable]
//public class Likability
//{
//  public string name;
//  public bool locked;
//  public int num;
//  public int level;
//}
//[System.Serializable]
//public class Characters_Likability
//{
//  public List<Likability> Likabilities = new List<Likability>();
//}
//[System.Serializable]
public class GameManagerr
{
    public bool isFirst;//第一次进游戏的初始化,控制各个面板,用来初始化各种数据
    public int maxCardsNum;//队伍的最大卡槽数
    public int curLevelID;//当前关卡序号，从0开始
    public int mora;
}
[System.Serializable]
public class Shop
{
    public int itemsTotalCount;//物品种类数
    public List<int> unlockedPerLevel=new List<int>();//随关卡解锁进度
    public List<Item> items=new List<Item>();//物品列表
    [System.Serializable]
    public class Item
    {
        public string name;//物品名
        public string description;//描述
        public int index;//序号
        public int price;//价格
        public int maxNum;//最大数量
        public int remainingNum;//剩余数量
        public bool purchasedState;//购买状态

        public Item(string name, string description, int price, int maxNum)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.maxNum = maxNum;
        }
    }
}
[System.Serializable]
public class Achievement
{
    public int ALLCount;//成就总个数
    public int achievedNum;//已完成并领取个数
    public List<Achievementt> l=new List<Achievementt>();//成就列表
    [System.Serializable]
    public class Achievementt
    {
    public int index1;//成就序号
    public int index2;//未完成成就在列表中的位置，(暂留
    public int index3;//成就种类，(暂留
    public string name;//成就名
    public string description;//详情
    public int progress;//进度
    public int target;//任务目标
    public int rewardNum;//奖励摩拉数
    public bool achievedState;//是否领取

        public Achievementt(string name, string description, int index2, int index3, int target, int rewardNum)
        {
            this.index2 = index2;
            this.index3 = index3;
            this.name = name;
            this.description = description;
            this.target = target;
            this.rewardNum = rewardNum;
        }
    }
}
[System.Serializable]
public class Character
{
    public int ALLCount;//角色总个数
    public List<Characterr> c;//角色列表
    public List<int> unlockedPerLevel;//随关卡解锁进度
    [System.Serializable]
    public class Characterr
    {
        public string name;//角色名
        public int index;//序号
        public int EXP;//当前等级好感度的累计经验
        public int level;//当前好感度等级

        public Characterr(string name)
        {
            this.name = name;
        }
    }
}
[System.Serializable]
public class Enemyy
{
  public int ALLCount;//敌人总个数
  public List<int> unlockedPerLevel;//随关卡解锁进度
}
