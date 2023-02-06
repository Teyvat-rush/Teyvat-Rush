class GameManagerr
{
    bool isFirst;//第一次进游戏的初始化,控制各个面板
    int curLevelID;//当前关卡序号，从0开始
    int mora;
}
class Shop
{
    bool isFirst;//首次进入游戏，用于初始化remainingNum,purchasedState等数据
    int itemsTotalCount;//物品种类数
    List<int> unlockedPerLevel;//随关卡解锁进度
    List<Item> items;//物品列表
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
class Achievement
{
    int ALLCount;//成就总个数
    int achievedNum;//已完成并领取个数
    bool isRemainingReward;//是否有成就未领取
    List<Achievementt> l;//成就列表

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
class Character
{
    int ALLCount;//角色总个数
    List<Characterr> c;//角色列表
    List<int> unlockedPerLevel;//随关卡解锁进度
    class Characterr
    {
        string name;//角色名
        int index;//序号
        int EXP;//当前等级好感度的累计经验
        int level;//当前好感度等级
    }
}
class Enemyy
{
    int ALLCount;//敌人总个数
    List<int> unlockedPerLevel;//随关卡解锁进度
}