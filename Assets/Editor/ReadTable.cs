using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using OfficeOpenXml;
using System.IO;
using System;
using System.Reflection;

[InitializeOnLoad]
public class Startup
{
    //这个方法会在运行前执行
    static Startup()
  {
    string path = Application.dataPath + "/Editor/关卡波次.xlsx";
    string assetName = "Level";
    FileInfo fileInfo = new FileInfo(path);
    //创建序列化类
    LevelData levelData = (LevelData)ScriptableObject.CreateInstance(typeof(LevelData));
    //打开Excel文件，using会在使用完毕后自动关闭读取的文件
    using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
    {
      //表格内的具体表单
      ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["敌人"];
      //遍历每一行
      for (int i = worksheet.Dimension.Start.Row + 2; i <= worksheet.Dimension.End.Row; i++) 
      {
        LevelItem levelItem = new LevelItem();
        //获取LevelItem的Type
        Type type = typeof(LevelItem);
        //遍历每一列
        for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++) 
        {
          //读取i行j列的内容，打印调试
          Debug.Log("数据内容:" + worksheet.GetValue(i, j).ToString());
          //用反射的方式对Levelitem进行赋值
          FieldInfo variable = type.GetField(worksheet.GetValue(2, j).ToString());
          string tableValue = worksheet.GetValue(i, j).ToString();
          variable.SetValue(levelItem, Convert.ChangeType(tableValue, variable.FieldType));
        }
        //当前行赋值结束，添加到列表中
        levelData.LevelDataList.Add(levelItem);
      }
    }

    //保存ScriptableObject为.asset文件
    AssetDatabase.CreateAsset(levelData,"Assets/Resources/"+assetName+".asset");
    AssetDatabase.SaveAssets();
    AssetDatabase.Refresh();
  }
}
