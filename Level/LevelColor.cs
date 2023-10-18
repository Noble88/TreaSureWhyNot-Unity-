using UnityEngine;
using System;
using System.Collections.Generic;
using Quaternion = System.Numerics.Quaternion;

public class LevelColor {
  public static IDictionary<string, char> tilesName = new Dictionary<string, char>();
  public static IDictionary<char, string> tilesChar = new Dictionary<char, string>();
  public static IDictionary<string, Color> txrColors = new Dictionary<string, Color>();
  public static IDictionary<char, Quaternion> charTilt = new Dictionary<char, Quaternion>();


  public static Color getColor(char e,bool inFg) {
    String colorLayer;
    if (inFg) { colorLayer = "00"; } else { colorLayer = "01";}

    if (tilesChar.ContainsKey(e) && txrColors.ContainsKey(tilesChar[e] + colorLayer)) {
      return txrColors[tilesChar[e]+colorLayer];
    }
    return txrColors["error"+colorLayer];
  }
  
  
  //TODO: swap all colors stuff for vecotor3 because highly inefficenet to store a color object
  public static void reasignColorsAndModifyers(){ //should add all the colors that any level will use
    // NOTE: 00 = foreground / 01 = background / 02-49 = Layers / 50-99 Blends (the seem between 2 tiles)
    #region ->basic tiles<-
    tilesName.Add("player",'@'); tilesChar.Add('@',"player");
    txrColors.Add("player00",new Color32(255, 0, 0,225));
    charTilt.Add('@',new Quaternion(30,0f,00f,180f));
    
      #region ---Borders & Intangibles---
    tilesName.Add("vertBrder",'|'); tilesChar.Add('|',"vertBrder");
    tilesName.Add("horzBrder",'-'); tilesChar.Add('-',"horzBrder");
    tilesName.Add("intrsctBrder",'+'); tilesChar.Add('+',"intrsctBrder");
    tilesName.Add("lowHorzBrder",'_'); tilesChar.Add('_',"lowHorzBrder");
      #region border & intangible colors
    txrColors.Add("vertBrder00",new Color32(255, 255, 255,225));    txrColors.Add("vertBrder01",new Color32(0, 0, 0,225));
    txrColors.Add("horzBrder00",new Color32(255, 255, 255,225));    txrColors.Add("horzBrder01",new Color32(0, 0, 0,225));
    txrColors.Add("intrsctBrder00",new Color32(255, 255, 255,225)); txrColors.Add("intrsctBrder01",new Color32(0, 0, 0,225));
    txrColors.Add("lowHorzBrder00",new Color32(255, 255, 255,225)); txrColors.Add("lowHorzBrder01",new Color32(0, 0, 0,225));
    #endregion
      #endregion
      #region ---Nature---
    tilesName.Add("grass",','); tilesChar.Add(',',"grass");
      #region Grass Colors
    txrColors.Add("grass00",new Color32(7, 165, 7,225));
    txrColors.Add("grass01",new Color32(49, 94, 32 ,225));
      #endregion
    tilesName.Add("tree",'⚲'); tilesChar.Add('⚲',"tree");
      #region Tree Colors
    txrColors.Add("tree00",new Color32(24, 48, 22 ,225));
    txrColors.Add("tree01",new Color32(35, 66, 32 ,225));
    txrColors.Add("tree02",new Color32(16, 74, 31,225));
      #endregion
    tilesName.Add("bush",'ʋ'); tilesChar.Add('ʋ',"bush");
      #region Bush Colors
    txrColors.Add("bush00",new Color32(25, 133, 54,225));
    txrColors.Add("bush01",new Color32(42, 191, 82,225));
    txrColors.Add("bush02",new Color32(38, 150, 68,225));
      #endregion
    tilesName.Add("deadTree",'Ɏ'); tilesChar.Add('Ɏ',"deadTree");
      #region DeadTree Colors
    txrColors.Add("deadTree00",new Color32(171, 129, 2,225));
    txrColors.Add("deadTree01",new Color32(191, 144, 0,225));
      #endregion
    tilesName.Add("cattail",'ľ'); tilesChar.Add('ľ',"cattail");
      #region Cattail Colors
    //TODO CHANGE COLORS!
    txrColors.Add("cattail00",new Color32(54, 120, 65,225));
    txrColors.Add("cattail01",new Color32(191, 144, 0,225));
      #endregion
      #endregion
      #region ---Rocky Stuff---
    tilesName.Add("dirtVert",'░'); tilesChar.Add('░',"dirtVert");
    tilesName.Add("dirtHorz",'∷'); tilesChar.Add('∷',"dirtHorz");
      #region dirt Color
    txrColors.Add("dirtVert00",new Color32(150, 75, 1 ,225));  txrColors.Add("dirtHorz00",new Color32(150, 75, 1 ,225));
    txrColors.Add("dirtVert01",new Color32(156, 125, 54,225)); txrColors.Add("dirtHorz01",new Color32(156, 125, 54,225));
    txrColors.Add("dirtVert50",new Color32(55, 94, 46,225));   txrColors.Add("dirtHorz50",new Color32(55, 94, 46,225));//Blend w/Grass
    txrColors.Add("dirtVert51",new Color32(47, 49, 27,225));   txrColors.Add("dirtHorz51",new Color32(47, 49, 27,225));//Blend w/Tree
      #endregion
    tilesName.Add("sand",':'); tilesChar.Add(':',"sand");
      #region sand Color
    txrColors.Add("sand00",new Color32(242,209,107,225));
    txrColors.Add("sand01",new Color32(185, 194, 53,225));
      #endregion
    tilesName.Add("mud",'∴'); tilesChar.Add('∴',"mud");
      #region mud Colors
    txrColors.Add("mud00",new Color32(61, 45, 34,225));
    txrColors.Add("mud01",new Color32(72, 57, 33,225));
      #endregion
    tilesName.Add("seaRocks",'ᵔ'); tilesChar.Add('ᵔ',"seaRocks");
      #region seaRocks Colors
    txrColors.Add("seaRocks00",new Color32(184, 191, 190,225));
    txrColors.Add("seaRocks01",new Color32(104, 130, 126,225));
      #endregion
    tilesName.Add("sharpDirt",'\''); tilesChar.Add('\'',"sharpDirt");
      #region sharpDirt Colors
    txrColors.Add("sharpDirt00",new Color32(224, 142, 27,225));
    txrColors.Add("sharpDirt01", new Color32(138, 87, 45,225));
        #endregion
    tilesName.Add("gravel",'▓'); tilesChar.Add('▓',"gravel");
      #region gravel Colors
    txrColors.Add("gravel00",new Color32(116, 109, 100,225));
    txrColors.Add("gravel01", new Color32(80, 77, 75,225));
      #endregion

    tilesName.Add("mntn",'^'); tilesChar.Add('^',"mntn");
      #region mntn Colors
        txrColors.Add("mntn00",new Color32(186, 123, 35 ,225));
        txrColors.Add("mntn01",new Color32(179, 72, 11,225));
        #endregion
      #endregion
      #region ---Water---
    //TODO: get still water character
    tilesName.Add("water",'~'); tilesChar.Add('~',"water");
    tilesName.Add("wavyWaterVert",'⧛'); tilesChar.Add('⧛',"wavyWaterVert");
      #region water Color
    txrColors.Add("water00",new Color32(62, 68, 246,225));
    txrColors.Add("water01",new Color32(78, 141, 186,225));
      #endregion
      #endregion
      #region---Snow---
    tilesName.Add("spruce ",'↟'); tilesChar.Add('↟',"spruce");
      #region water Color
    txrColors.Add("spruce00",new Color32(75, 66, 53,225));
    txrColors.Add("spruce01",new Color32(131, 122, 115,225));
      #endregion

    //TODO add: snow
      #endregion
    #endregion
    #region ->Building/Human Made Tiles<-
      #region ---structure related---
    tilesName.Add("woodFlr",'#'); tilesChar.Add('#',"woodFlr");
      #region woodFlr Colors
    txrColors.Add("woodFlr00",new Color32(145, 108, 1,225));
    txrColors.Add("woodFlr01",new Color32(84, 65, 12,225));
    //Not sure what this is for bth
    //txrColors.Add("woodFlr", new Color32(107, 82, 11,225));
      #endregion
    tilesName.Add("fence",'ỻ'); tilesChar.Add('ỻ',"fence");
      #region fence Colors
    //TODO ADD: make fence color
    //txrColors.Add("fence", COLOR);
      #endregion
    tilesName.Add("divot" ,'˽'); tilesChar.Add('˽',"divot" );
      #region divot Colors
    //TODO ADD: make divot color
    //txrColors.Add("divot", COLOR);
      #endregion
    tilesName.Add("cropDirt",'ʭ'); tilesChar.Add('ʭ',"cropDirt");
      #region cropDirt Colors
    //TODO ADD: make cropDirt color
    //txrColors.Add("cropDirt", COLOR);
      #endregion
      #endregion
      #region---Human Made---
        #region -Out In Nature-
    tilesName.Add("rope",'ʇ'); tilesChar.Add('ʇ',"rope");
      #region rope Colors
    txrColors.Add("rope00",txrColors["mntn00"]);
    txrColors.Add("rope01",txrColors["mntn01"]);
      #endregion
    tilesName.Add("signPostL",'⍇'); tilesChar.Add('⍇',"signPostL");
      #region rope Colors
    txrColors.Add("signPostL00",new Color32(115, 89, 32,225));
    txrColors.Add("signPostL01",txrColors["woodFlr01"]);
      #endregion

        #endregion
      #endregion
    #endregion
    #region ->UI elements<-
    tilesName.Add("warning",'!'); tilesChar.Add('!',"warning");
      #region warning Colors
    //TODO ADD: make warning color
    //txrColors.Add("warning", COLOR);
      #endregion
    #endregion
    #region ->multiuse/Misc<-
    tilesName.Add("empty",' '); tilesChar.Add(' ',"empty");
    tilesName.Add("error",'☹'); tilesChar.Add('☹',"error");
      #region error Colors
    txrColors.Add("error00",new Color32(140, 31, 243,225));
    txrColors.Add("error01",new Color32(81, 11, 84,225));
      #endregion
    #endregion
  }
}

