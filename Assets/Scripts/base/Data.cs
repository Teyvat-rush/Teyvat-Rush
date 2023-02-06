using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data",menuName ="DATA",order =1)]
public class Data : ScriptableObject
{
    public List<Data> AllData = new List<Data>();
  public int Moranum;
}
[System.Serializable]
public class Coin
{
  public int num;
}
[System.Serializable]
public class Likability
{
  public string name;
  public bool locked;
  public int num;
  public int level;
}
[System.Serializable]
public class Characters_Likability
{
  public List<Likability> Likabilities = new List<Likability>();
}
[System.Serializable]
class GameManagerr
{
  bool isFirst;//第一次进游戏的初始化,控制各个面板,用来初始化各种数据
  int curLevelID;//当前关卡序号，从0开始
  int mora;
}
[System.Serializable]
class Shop
{
  int itemsTotalCount;//物品种类数
  List<int> unlockedPerLevel;//随关卡解锁进度
  List<Item> items;//物品列表
  [System.Serializable]
  class Item
  {
    string name;//物品名
    int index;//序号
    int price;//价格
    int maxNum;//最大数量
    int remainingNum;//剩余数量
    bool purchasedState;//购买状态
  }
}
[System.Serializable]
class Achievement
{
  int ALLCount;//成就总个数
  int achievedNum;//已完成并领取个数
  bool isRemainingReward;//是否有成就未领取
  List<Achievementt> l;//成就列表
  [System.Serializable]
  class Achievementt
  {
    int index1;//成就序号
    int index2;//未完成成就在列表中的位置，(暂留
    int index3;//成就种类，(暂留
    int progress;//进度
    int target;//任务目标
    bool achievedState;//是否领取
  }
}
[System.Serializable]
class Character
{
  int ALLCount;//角色总个数
  List<Characterr> c;//角色列表
  List<int> unlockedPerLevel;//随关卡解锁进度
  [System.Serializable]
  class Characterr
  {
    string name;//角色名
    int index;//序号
    int EXP;//当前等级好感度的累计经验
    int level;//当前好感度等级
  }
}
[System.Serializable]
public class Enemyy
{
  public int ALLCount;//敌人总个数
  public List<int> unlockedPerLevel;//随关卡解锁进度
}
