using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEditor;

//TODO: NEED TO ADD FLYWEIGTHS 

public class Tile  { //Tile is made from [1 cube] & [text box above it]
  public GameObject TileCube;
  public TextMeshPro TileText;
  public GameObject TileAll = new GameObject(); //Contains both Cube & Text

  public Renderer RendBg;
  
  public Tile(Vector3 spawnPos, Vector2Int tilePos, string nameOfGrid, GameObject tileGrid) {
    //Background / Cube Section
    TileCube = GameObject.CreatePrimitive(PrimitiveType.Cube); //Create cube
    //RenameCube
    RendBg = TileCube.GetComponent<Renderer>();
    RendBg.material.color = new Color(0, 0, 0);
    
    //Foreground / TextBox Section
    TileText = new GameObject().AddComponent<TextMeshPro>(); //Create Text Box
    placeTextBox(TileText, spawnPos);
    formatTextBox(TileText);
    
    //Other Actions
    organizeGameObjects(tileGrid, tilePos);
    //TODO: MAKE A EFFICENT WAY TO ADD COLORS CHECK FOR EACH TEXT BOX
    
    //Both Objects
    TileAll.transform.position = spawnPos;
  }
  #region Methods for Class Initlization
  #region TextBox Modification
  private void placeTextBox(TextMeshPro TileText, Vector3 spawnPosition){
    Vector3 textBoxOffset = new Vector3(0,.8f,0);
    //Note: defaultCharTilt = new Quaternion(170,0f,00f,180f);
    
    TileText.transform.position = (textBoxOffset);
    TileText.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1); //Set size of text box
    TileText.GetComponent<RectTransform>().rotation = new Quaternion(170, 0f,00f,180f); //set rotation of text box
  }

  private void formatTextBox(TextMeshPro TileText){
    TileText.verticalAlignment = VerticalAlignmentOptions.Middle;
    TileText.horizontalAlignment = HorizontalAlignmentOptions.Center;
    TileText.alignment = TextAlignmentOptions.Midline;
      
    TileText.enableAutoSizing = true;
    TileText.fontSizeMin = 5;
      
    //TODO BUG: add all of the unicode characters that are missing into the font 
    TileText.font = Resources.Load<TMP_FontAsset>("Fonts/LevelFont/unifont-15");;
    //TODO Efficency: try and make it so instead of grabbing from resources grab from stock assets

    TileText.SetText("0");
  }
  #endregion

  public void organizeGameObjects(GameObject TileGrid, Vector2Int tilePos ) //Creates Hierarchy & Names for Objects
  {
    //Modify Names
    TileText.name = "CharBox";
    TileCube.name = "TileBody";
    TileAll.name  = "Tile ("+GlobalMethods.doubleDigitMaker(tilePos.x)+" , "+GlobalMethods.doubleDigitMaker(tilePos.y)+")";
    //Modify Hierarchy
    TileText.transform.SetParent(TileAll.transform); // puts TileText under TileAll
    TileCube.transform.SetParent(TileAll.transform); // puts TileCube under TileAll
    TileAll.transform.SetParent(TileGrid.transform); // puts TileAll  under Associated TileGrid
  }
  #endregion
  
  #region Background and Forground Update Methods
  public void updateBg(char[,,] CharacterGrid,GameObject TileGrid, Vector2Int localTilePosition) {
    char levelChar = getCharFromGrid(TileGrid.name, localTilePosition, false);
    
    CharacterGrid[1,localTilePosition.y,localTilePosition.x] = levelChar;
    RendBg.material.color = getColor(TileGrid.name, levelChar, false);
    //Console.WriteLine("COLOR MAKING BASED OF -> " + GlobalData.tilesChar[e] + "01");
  }
      
  public void updateFg(char[,,] CharacterGrid, GameObject TileGrid, Vector2Int localTilePosition) {
    char levelChar = getCharFromGrid(TileGrid.name, localTilePosition, true);

    CharacterGrid[0,localTilePosition.y,localTilePosition.x] = levelChar;
    TileText.SetText(levelChar.ToString()); //update character
    TileText.color = getColor(TileGrid.name, levelChar, true);
    //TileText.GetComponent<RectTransform>().rotation = getDesginatedCharTilt(e); TODO: MAKE ROTATION MODIFYABLE
  }
  #endregion

  public char getCharFromGrid(string gridName, Vector2Int localTilePosition, bool getFG) {
    if (gridName.Equals("LEVEL")) {
      return LevelMaster.LevelBackEnd.getE(localTilePosition, true);
    }
    return '0';
  }
  
  public Color getColor(string gridName,char e,bool inFg){
    if (gridName.Equals("LEVEL")) {
      return LevelColor.getColor(e,inFg);
    }
    return LevelColor.txrColors["error" + "00"];
  }
  /*
  public Quaternion getDesginatedCharTilt(char e) {
    if (GlobalData.charTilt.ContainsKey(e)) {
      return GlobalData.charTilt[e];
    }
    return defaultCharTilt; //DEFAULT TILT
  }
  */
      
}
