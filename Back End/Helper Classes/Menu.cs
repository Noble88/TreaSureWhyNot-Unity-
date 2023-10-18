using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu {
  
  int maxPg=1, maxRow,maxCol; //NOTE: max page is the inclusive (starts at 1) BUT max row & col is exclusive
  int curPg=1;
  Vector2Int nav=new Vector2Int(0,0); //X,Y || col,row
  
  bool horizWrap,vertWrap;
  bool vertChngPg=false, horizChngPg=false;
  
  public Menu(int pages,int rows,int col,bool changeHorizontally, bool wrapHoriz, bool wrapVert) {
    maxPg= pages;  maxRow= rows;  maxCol= col; 
    
    if (changeHorizontally && maxPg != 1) {
      horizChngPg=changeHorizontally; vertChngPg=!changeHorizontally;
    }
    else {horizChngPg=false; vertChngPg=false;}
    horizWrap=wrapHoriz; vertWrap=wrapVert;
  }

  private bool checkIfGoToNewPage(string direction){
    switch (direction) {
      case "UP"   : return nav.y-1 == -1;
      case "DOWN" : return nav.y+1 == maxRow;
      case "RIGHT": return nav.x+1 == maxCol;
      case "LEFT": return nav.x-1 == -1;
      default: return false;
    }
  }
  
  
  
}
