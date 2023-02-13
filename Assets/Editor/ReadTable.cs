using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using OfficeOpenXml;
using System.IO;
using System;
using System.Reflection;
using log4net.Core;

[InitializeOnLoad]
public class Startup
{
    
    //这个方法会在运行前执行
    static Startup()
    {
        int firstLine = 3;
        int lastLine = 4;
        int totalNum = 0;
        bool isSign=false;
        string path = Application.dataPath + "/Editor/关卡波次.xlsx";
        FileInfo fileInfo = new FileInfo(path);
        LevelData.Levels.Clear();
        for (int m=0;m<3;m++)///////关卡总数
        {
            
            LevelData.Levels.Add(new List<LevelItem>());
            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                //表格内的具体表单
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["敌人"];
                //遍历每一行
                for (int i = firstLine; i<= lastLine; i++)
                {
                    //Debug.Log("worksheet.Dimension.End.Row="+ worksheet.Dimension.End.Row);
                    LevelItem levelItem = new LevelItem();
                    //获取LevelItem的Type
                    Type type = typeof(LevelItem);
                    //遍历每一列
                    for (int j = worksheet.Dimension.Start.Column; j <= 12/*worksheet.Dimension.End.Column*/; j++)
                    {
                        //Debug.Log("读取第" + i + "行" + "第" + j + "列");
                        //Debug.Log("worksheet.Dimension.End.Column = "+worksheet.Dimension.End.Column); 
                        //读取i行j列的内容，打印调试
                        //Debug.Log("数据内容:" + worksheet.GetValue(i, j).ToString());
                        //用反射的方式对Levelitem进行赋值
                        FieldInfo variable = type.GetField(worksheet.GetValue(2, j).ToString());
                        string tableValue = worksheet.GetValue(i, j).ToString();
                        variable.SetValue(levelItem, Convert.ChangeType(tableValue, variable.FieldType));
                        if(j==1&&levelItem.ProgressID_max<0)
                        {
                            isSign= true;
                        }
                        if(j==2&&isSign)
                        {
                            totalNum = (int)levelItem.ProgressID;
                            LevelData.totalNums.Add(totalNum);
                            j = worksheet.Dimension.End.Column + 1;
                            //Debug.Log("totalnum=" + totalNum);
                            lastLine = firstLine + totalNum;
                            isSign= false;
                        }
                    }
                    //当前行赋值结束，添加到列表中
                    //levelData.LevelDataList.Add(levelItem);
                    if(levelItem.ProgressID_max >= 0)
                    {
                        LevelData.Levels[m].Add(levelItem);
                    }
                    
                }
                //Debug.Log(LevelData.Levels[0][5].CreateTime);
            }
            firstLine= lastLine+1;
            lastLine=firstLine;
        }
        
        
        //string assetName = "Level";
       
        //创建序列化类
        //LevelData levelData = (LevelData)ScriptableObject.CreateInstance(typeof(LevelData));
        //打开Excel文件，using会在使用完毕后自动关闭读取的文件
        
        //Debug.Log("退出读取");
        //保存ScriptableObject为.asset文件
        //AssetDatabase.CreateAsset(levels, "Assets/Resources/" + assetName + ".asset");
        //AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh();
    }
}
