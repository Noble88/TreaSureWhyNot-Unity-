using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class LevelBuilder { //LevelSkeleton 
  [Serializable()] 
  public class Level{
   #region Variables
    char[,] BG = new char[,] {
          { '|' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '|' },//1
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//2
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//3
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//4
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//5
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//6
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//7
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//8
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//9
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//10
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//11
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//12
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//13
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//14
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//15
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//16
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//17
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//18
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//19
          { '|' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '|' },//20
        }; //Background
    char[,] FG = new char[,] {
          { '|' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '|' },//1
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//2
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//3
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//4
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//5
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//6
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//7
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//8
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//9
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//10
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//11
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//12
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//13
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//14
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//15
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//16
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//17
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//18
          { '|' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , ',' , '|' },//19
          { '|' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '|' },//20
        }; //Foreground
    public ArrayList pos;
    public string name; //Holds the name that is displayed in the hud & other references
    public string[]contacts = new string[4];  //This holds any directly adjacent [left, right, up, down] levels file path
    public String selfPath=""; //Hold this level's file path [Note: file path in terms of pre-made templates in saved data] 
   #endregion
    
    public Level(){}
    public Level(ArrayList pos, string name, char[,] background, char[,] foreground) {
      this.name = name;
      
      for(byte y = 0; y<20;y++){ //Assigns the forground & background
        for(byte x=0; x<20;x++){ 
          FG[y,x]=foreground[y,x];
          BG[y,x]=background[y,x];
        }
      }
      
      selfPath = Loader.getLevelPath(pos,new Vector2Int(0,0));
      contacts[0]=Loader.getLevelPath(pos,new Vector2Int(-1,0)); //LEFT LEVEL PATH
      contacts[1]=Loader.getLevelPath(pos,new Vector2Int(0,-1)); //UP LEVEL PATH
      contacts[2]=Loader.getLevelPath(pos,new Vector2Int(0,1));//DOWN LEVEL PATH
      contacts[3]=Loader.getLevelPath(pos,new Vector2Int(1,0)); //RIGHT LEVEL PATH
      
    }
    
    
    #region Behavior Methods & Variables
    public bool canBorderLevelSwitch = false;
    
    public void setLevelBehvaior(bool switchLevelOnBorderCollide) {
      canBorderLevelSwitch = switchLevelOnBorderCollide;
    }
    
    #endregion
    
    #region Level Switch Methods
    public void borderLevelSwitch(){
      if(!canBorderLevelSwitch){return;}
      Loader.loadNewLevel(true,contacts[directionTonNum(LevelMaster.Player.directionFacing)]);
    }
    private int directionTonNum(String direction){
      switch(direction){
        case "LEFT" :{return 0;}
        case "UP"   :{return 1;}
        case "DOWN" :{return 2;}
        case "RIGHT":{return 3;}
        default     :{return -1;}
      }
    }
    #endregion
    
    #region Methods for Changing Chars in FG & BG
      /*
      public Vector2 posE  (char e){ byte y,x;
        for(y=1;y<yB;y++){
          for(x=0; x<xB;x++){
            if(levFG[y][x]==e){return new byte[]{y,x};}}}
        return new byte[]{-1,-1};
      }
      */
    public char   getE  (Vector2Int pos, bool getFG){
      if(getFG){return FG[pos.y,pos.x];}
      else     {return BG[pos.y,pos.x];}
    }
    public void   setE  (Vector2Int pos, char e, bool editFG){
      if(editFG){FG[pos.y,pos.x]=e;}
      else      {BG[pos.y,pos.x]=e;}
    }
    public void   flipE (Vector2Int pos, bool flipFG){
      if(flipFG){FG[pos.y,pos.x]=BG[pos.y,pos.x];}
      else      {BG[pos.y,pos.x]=FG[pos.y,pos.x];}
    }
    #endregion


    
  } 
  
  
    
}
