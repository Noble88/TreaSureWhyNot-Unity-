using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

//TODO: Make a repair .exe file that can scan game files -> have different class of errors [item missing can just remake the items from StockAssets but if saved data like levels a full new game needs to be made]
//TODO: should make a separate runnable so that when a new game is created it saves all newly created stuff and deletes any data on memory, doesn't crowed loader

public class Loader: MonoBehaviour {
  //D:\Unreal Engine Projects\School Projects\TreaSureWhyNot vUnity\TreaSureWhyNot
  // \Assets\StockAssets\Levels\"AREA NAME"\"CORDS".txt

  public static void LoadLevels(bool newStart){//NOT SURE WUT THIS IS ABOUT MAKE SURE TO CHANGE
    if (newStart) {
      LevelFileCreation.createAllLevels();
    }//TODO DEBUGGER: make starting option to load all levels
  }
  
  #region Valid Files Methods and Variables
  //TODO: Figure out a smarter way to check for existing files -> the endless potential for sublevels is to much manual work
  ArrayList OverWorldLevelCords = new ArrayList(){
    new Vector2Int(-1,0), new Vector2Int(-1,1), new Vector2Int(-2,0), new Vector2Int(-2,1), //Chowder Lake
    new Vector2Int(0,-1), new Vector2Int(0,-2), new Vector2Int(1,-1), new Vector2Int(1,-2), //FarmenTump
    new Vector2Int(0,2) , new Vector2Int(0,3) , new Vector2Int(1,2) , new Vector2Int(1,3) , //KnotCross
    new Vector2Int(0,0) , new Vector2Int(0,1) , new Vector2Int(1,0) , new Vector2Int(1,1) , //LivelyLeafs
    new Vector2Int(2,2) , new Vector2Int(2,3) , new Vector2Int(3,2) , new Vector2Int(3,3) , //MountainSide
    new Vector2Int(2,0) , new Vector2Int(2,1) , new Vector2Int(3,0) , new Vector2Int(3,1) , //RiverSide
    new Vector2Int(-1,2), new Vector2Int(-1,3), new Vector2Int(-2,2), new Vector2Int(-2,3), //ScatteredSides
    new Vector2Int(2,-1), new Vector2Int(2,-2), new Vector2Int(3,-1), new Vector2Int(3,-2), //WetLands
  };
  
  public void validFiles(){ //Checks to see if all files are present
    for (int i = 0; i < OverWorldLevelCords.Count; i++) {
      ArrayList levPos = new ArrayList(){(Vector2Int)OverWorldLevelCords[i]};
      if (!File.Exists(GlobalData.curFilePath + "\\Assets\\SavedData\\Levels" +
                       getPackagePath(levPos, new Vector2Int(0, 0)) +
                       "\\"+ CTS(levPos, new Vector2Int(0,0))+".txt" )){
        print("WARNING!!! -> FILE [ "+GlobalData.curFilePath + "\\Assets\\SavedData\\Levels\\"+
              (getPackagePath(levPos,new Vector2Int(0, 0))+" ] DOES NOT EXIST"));
      }
    }
  }
  #endregion
  
  #region Level Loading & Saving
  
  #region Loading
  public static void loadNewLevel(bool saveBeforeSwitch, string filePath) {
    if(saveBeforeSwitch){SaveLevelToFile(LevelMaster.LevelBackEnd);}
    LevelMaster.LevelBackEnd=getLevelFromFile(filePath);
    //ADD METHODS THE LEVEL NEEDS TO DO BEFORE
  }
  
  private static LevelBuilder.Level getLevelFromFile(string filePath) { //extracts level from file
    IFormatter formatter = new BinaryFormatter();
    Stream stream = new FileStream(filePath,FileMode.Open,FileAccess.Read);
    LevelBuilder.Level LevelObj = (LevelBuilder.Level)formatter.Deserialize(stream);
    stream.Close();
    return LevelObj;
  }
  #endregion
  
  #region Saving
  protected static void SaveLevelToFile(LevelBuilder.Level LevelObj) {//writes level to file
    IFormatter formatter = new BinaryFormatter();
    Stream stream = new FileStream(LevelObj.selfPath,FileMode.Create,FileAccess.Write);
    formatter.Serialize(stream, LevelObj);
    stream.Close();
  }
  
  public static void saveCurrentLevel() { //POTENTIAL ERROR: WHEN SAVING MIGHT SAVE THE STAIN FG WITH PLAYER IF NOT REMOVED BEFORE SAVE
    SaveLevelToFile(LevelMaster.LevelBackEnd);
  }
  #endregion

  #endregion
  
  #region File Navigator Helping Methods
  
  public static string getLevelPath(ArrayList pos,Vector2Int offSet){
    return GlobalData.SavedLevelsPath+getPackagePath(pos,offSet)+"\\"+CTS(pos, offSet)+".txt";
  }
  
  public static string getPackagePath(ArrayList pos, Vector2Int offSet){
    switch( (((Vector2Int)pos[0]).x+offSet.x)+","+(((Vector2Int)pos[0]).y+offSet.y)){
      case "-1,0" or "-1,1" or "-2,0" or "-2,1":{return "\\FarmenTump";}//
      case "-1,2" or "-1,3" or "-2,2" or "-2,3":{return "\\WetLands";}//

      case "0,-1"or "0,-2"or "1,-1"or "1,-2":{return "\\ChowderLake";}
      case "0,0" or "0,1" or "1,0" or "1,1" :{return "\\LivelyLeafs";}
      case "0,2" or "0,3" or "1,2" or "1,3" :{return "\\RiverSide";}//

      case "2,-1"or "2,-2"or "3,-1" or "3,-2":{return "\\ScatteredSides";}
      case "2,0" or "2,1" or "3,0"  or "3,1" :{return "\\KnotCross";}
      case "2,2" or "2,3" or "3,2"  or "3,3" :{return "\\MountainSide";}
      default:{return "\\N/A";}
    }
  }
  
  public static string CTS(ArrayList arr, Vector2Int offSet){//coordinates to string
    //TODO: Comment and write what is going on here (it works but im not sure i can follow it)
    string temp=((Vector2Int)arr[0])[0]+","+((Vector2Int)arr[0])[1];
    if(arr.Count>1){
      for(byte i=1; i<arr.Count; i++){
        if(i%2==1){//if in the first part of sublevel notiotion y,x_y,x
          temp+="-"+((Vector2Int)arr[i])[0]+","+((Vector2Int)arr[i])[1];
        }
        else{
          if( (i+1)==arr.Count){
            temp+="_"+(((Vector2Int)arr[i])[0]+offSet[0])+","+(((Vector2Int)arr[0])[1]+offSet[1]);
          } else{temp+="_"+((Vector2Int)arr[i])[0]+","+((Vector2Int)arr[i])[1];}
        }
      }
    }
    else{return (((Vector2Int)arr[0])[0]+offSet[0])+","+(((Vector2Int)arr[0])[1]+offSet[1]);}

    return temp;
  }
  
  protected static char[,,] StockLevelAssetTranslator(string filePath) { //Will convert returned file to usable data
    char[,,] arr = new char[2,20,20];
    //BG is first half & FG is last half inside txt file
    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8)) {
      string line;
      byte row=0;
      int layer = 0;
      while ((line = streamReader.ReadLine()) != null) {
        byte offset=0;
        int i = 0;
        //print(line);
        if(row==20){layer++; row = 0; }
        
        for(i=0; i<line.Length; i++){// remove tabs in file
          //print("GETTING FROM LINE[i] = "+line[i]+"   WHEN [i] = "+i+ "  |  ROW ="+row+"  LAYER = "+layer);
          if(line[i]!='\t'){arr[layer,row,i-offset]=line[i];
          }else{offset++;}
        }
        row++;
      }
      
      streamReader.Close();
    }
    return arr;
  }

  public static string quickPosToString(Vector2Int pos) { //shortcut used to make writing coordinates easier & cleaner
    return pos.x + "," + pos.y;
  }
  
  #endregion
  


}
