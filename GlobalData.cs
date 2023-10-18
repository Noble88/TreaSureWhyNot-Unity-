using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData {
  public static string curFilePath = System.IO.Directory.GetCurrentDirectory();
  public static string stockLevelsPath = curFilePath + "\\Assets\\StockAssets\\Levels";
  public static string SavedLevelsPath = curFilePath + "\\Assets\\SavedData\\Levels";
  
  public static View View;
}
