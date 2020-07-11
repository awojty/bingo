using System;
using System.IO;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
//using System.Windows.Media;
public class Scripting : MonoBehaviour
{
public Button restartButton;
public Button addText;
  public Button button1;
  public Button button2;
  public  Button button3;
  public Button button4;
  public Button button5;
public Button button6;
  public Button button7;
  public Button button8;
  public Button button9;
  public Button button10;
  public Button button12;
  public Button button11;
  public Button button13;
  public Button button14;
  public Button button15;
  public Button button16;
  public List<List<int>> row_column;
  public Dictionary<int, List<int>> rowClicked;
  public Dictionary<int, List<int>> columnClicked;
  public List<string> texts;
  public List<string> buttonnames;
  public List<Button> buttons;

  public GameObject winPanel;

    public static Scripting instance = null;
public ColorBlock theColor;
//to each button assigne two values row and clumne
//when we click on the button we read its row and cloumn
//we keep a dicitonayries one fro column and one fro rows and assign clicke buttons, if lenth of the array value if equa to four after we add the elemtn then we win
    // Start is called before the first frame update
    void Start()
    {  //Dictionary<string, StorybookTinkerText> tinkerTextDic= new Dictionary<string, StorybookTinkerText>();
      if (this.winPanel!=null){

      this.winPanel.SetActive(false);

      }

      buttons= new List<Button>(){this.button1,this.button2,
        this.button3,this.button4,this.button5,this.button6,this.button7,this.button8,
        this.button9,this.button10,this.button11,this.button12,this.button13,
        this.button14,this.button15,this.button16};


      row_column= new List<List<int>>();
      buttonnames = new  List<string>(){"button1","button2","button3","button4",
      "button5","button6","button7","button8","button9","button10","button11","button12","button13","button14","button15","button16"};
      texts = new List<string>(){"Hello?","You are muted","Hang on","My camera doesnt work","My internet is so bad","Guy jumping on a bouncy ball","We can see you emails!","My camera is not working","I cant hear you","Can you hear me?","Writting in private chat instead of listening","Everyone unmute themselves and say that for 5 min at the end of the meeting","Funny background","Crying baby in the background",
      "Too close to the camera","BYYYYYYYYYYeeee"};
       rowClicked= new Dictionary<int, List<int>>();
       columnClicked=new Dictionary<int, List<int>>();
      for( int i=0;i<4;i++){
        for( int j=0;j<4;j++){

        List<int> rowcolumn =  new List<int>();

        rowcolumn.Add(i);
        rowcolumn.Add(j);
        this.row_column.Add(rowcolumn);

      }}

      for (int i=0;i<16;i++){
        GameObject.Find(buttonnames[i]).GetComponentInChildren<Text>().text = texts[i];
      }

      for( int i=0;i<4;i++){

        List<int> rowcolumn =  new List<int>();
        List<int> rowcolumn2 =  new List<int>();
        rowClicked[i]=rowcolumn;
        columnClicked[i]=rowcolumn2;


      }
    //  Debug.Log("Game start");
this.addText.onClick.AddListener(this.openURL);
    this.restartButton.onClick.AddListener(this.onrestart);
      this.button1.onClick.AddListener(this.onClick1);
      this.button1.interactable = true;
      this.button2.onClick.AddListener(this.onClick2);
      this.button2.interactable = true;
      this.button3.onClick.AddListener(this.onClick3);
      this.button3.interactable = true;
      this.button5.onClick.AddListener(this.onClick5);
      this.button5.interactable = true;
      this.button4.onClick.AddListener(this.onClick4);
      this.button4.interactable = true;
      this.button6.onClick.AddListener(this.onClick6);
      this.button6.interactable = true;

      this.button7.onClick.AddListener(this.onClick7);
      this.button7.interactable = true;
      this.button8.onClick.AddListener(this.onClick8);
      this.button8.interactable = true;
      this.button9.onClick.AddListener(this.onClick9);
      this.button9.interactable = true;
      this.button10.onClick.AddListener(this.onClick10);
      this.button10.interactable = true;
      this.button11.onClick.AddListener(this.onClick11);
      this.button11.interactable = true;
      this.button12.onClick.AddListener(this.onClick12);
      this.button12.interactable = true;

      this.button13.onClick.AddListener(this.onClick13);
      this.button13.interactable = true;
      this.button14.onClick.AddListener(this.onClick14);
      this.button14.interactable = true;
      this.button15.onClick.AddListener(this.onClick15);
      this.button15.interactable = true;
      this.button16.onClick.AddListener(this.onClick16);
      this.button16.interactable = true;

    }
private void openURL(){
   Application.OpenURL("http://www.google.com");
}
    // Update is called once per frame
    void Update()
    {   handleTaskQueue();

     }
private void onrestart(){
  Debug.Log("onrestr");
  for( int i=0;i<4;i++){

    List<int> rowcolumn =  new List<int>();
    List<int> rowcolumn2 =  new List<int>();
    rowClicked[i]=rowcolumn;
    columnClicked[i]=rowcolumn2;


  }
  if (winPanel!=null){
    Debug.Log("niotnull");
this.winPanel.SetActive(false);
  }
  this.neww=0;
  for(int i=0;i<16;i++){
    Button element = buttons[i];
    var colors = element.GetComponent<Button> ().colors;
            colors.normalColor = Color.white;
            element.GetComponent<Button> ().colors = colors;


  }

  // var colors = this.button1.GetComponent<Button> ().colors;
  //         colors.normalColor = Color.white;
  //         this.button1.GetComponent<Button> ().colors = colors;
  //
  //         var colors1 = this.button2.GetComponent<Button> ().colors;
  //                 colors1.normalColor = Color.white;
  //                 this.button2.GetComponent<Button> ().colors = colors1;



}

    private void handleTaskQueue() {
        // Pop tasks from the task queue and perform them.
        // Tasks are added from other threads, usually in response to ROS msgs.
          if(isWin()){
             Debug.Log("Hello: " );
             if (winPanel!=null){
               bool isActive = this.winPanel.activeSelf;
             this.winPanel.SetActive(!isActive);

             }
        }
    }

public int neww=0;
public bool win = false;
public bool isWin(){
  //Debug.Log("onclick");
    if(this.win==true){
      Debug.Log("WOOOOOOON");
      this.win=false;
Debug.Log("On Entering libary button clicked");
  this.neww=0;
  return true;
  //this.winPanel.SetActive(true);

  }
  return false;
}

    private void onClick1(){
      List<int> currentlist = this.row_column[0];

      string result11 = "bList row contents: ";
      foreach (var item in this.rowClicked[currentlist[0]])
      {
          result11 += item.ToString() + ", ";
      }
      Debug.Log(result11);

      string result21 = "bList  column contents: ";
      foreach (var item in this.columnClicked[currentlist[1]])
      {
          result21 += item.ToString() + ", ";
      }
      Debug.Log(result21);


      Debug.Log("Hello: click1 " );

      var colors = this.button1.GetComponent<Button> ().colors;
              colors.normalColor = Color.red;
              this.button1.GetComponent<Button> ().colors = colors;


      this.rowClicked[currentlist[0]].Add(1);
      this.columnClicked[currentlist[1]].Add(1);

      string result = "List row contents: ";
      foreach (var item in this.rowClicked[currentlist[0]])
      {
          result += item.ToString() + ", ";
      }
      Debug.Log(result);

      string result1 = "List  column contents: ";
      foreach (var item in this.columnClicked[currentlist[1]])
      {
          result1 += item.ToString() + ", ";
      }
      Debug.Log(result1);

      Debug.Log(this.rowClicked);
      Debug.Log(this.rowClicked[currentlist[0]].ToString());
      Debug.Log(this.rowClicked[currentlist[1]]);
      if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
      this.win=true;
      }
    }

    private void onClick2(){
      var colors = this.button2.GetComponent<Button> ().colors;
              colors.normalColor = Color.red;
              this.button2.GetComponent<Button> ().colors = colors;
      Debug.Log("Hello: " );

    //  Debug.Log("onclick");
      List<int> currentlist = this.row_column[1];
      this.rowClicked[currentlist[0]].Add(2);
      this.columnClicked[currentlist[1]].Add(2);
      Debug.Log(this.rowClicked[currentlist[0]].Count);
      Debug.Log(this.columnClicked[currentlist[1]].Count);

      string result = "List row contents: ";
      foreach (var item in this.rowClicked[currentlist[0]])
      {
          result += item.ToString() + ", ";
      }
      Debug.Log(result);

      string result1 = "List  column contents: ";
      foreach (var item in this.columnClicked[currentlist[1]])
      {
          result1 += item.ToString() + ", ";
      }
      Debug.Log(result1);

      if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
      this.win=true;
      }

    }


    private void onClick3(){
      Debug.Log("onclick");
      var colors = this.button3.GetComponent<Button> ().colors;
              colors.normalColor = Color.red;
              this.button3.GetComponent<Button> ().colors = colors;
      List<int> currentlist = this.row_column[2];
      this.rowClicked[currentlist[0]].Add(3);
      this.columnClicked[currentlist[1]].Add(3);
      Debug.Log(this.rowClicked[currentlist[0]]);

      if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
      this.win=true;
      }


    }

    private void onClick4(){
      Debug.Log("onclick");
      var colors = this.button4.GetComponent<Button> ().colors;
      colors.normalColor = Color.red;
      this.button4.GetComponent<Button> ().colors = colors;
      List<int> currentlist = this.row_column[3];
      this.rowClicked[currentlist[0]].Add(4);
      this.columnClicked[currentlist[1]].Add(4);
      Debug.Log(this.rowClicked[currentlist[0]]);
      Debug.Log(this.rowClicked[currentlist[0]]);
      if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
      this.win=true;
      }


    }

    private void onClick5(){
      Debug.Log("onclick");
      var colors = this.button5.GetComponent<Button> ().colors;
              colors.normalColor = Color.red;
              this.button5.GetComponent<Button> ().colors = colors;
      List<int> currentlist = this.row_column[4];
      this.rowClicked[currentlist[0]].Add(3);
      this.columnClicked[currentlist[1]].Add(3);
      Debug.Log(this.rowClicked[currentlist[0]]);

      if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
      this.win=true;
      }


    }


    private void onClick6(){
      Debug.Log("onclick");
      var colors = this.button6.GetComponent<Button> ().colors;
              colors.normalColor = Color.red;
              this.button6.GetComponent<Button> ().colors = colors;
      List<int> currentlist = this.row_column[5];
      this.rowClicked[currentlist[0]].Add(3);
      this.columnClicked[currentlist[1]].Add(3);
      Debug.Log(this.rowClicked[currentlist[0]]);

      if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
      this.win=true;
      }


    }




    private void onClick7(){
      Debug.Log("onclick");
      var colors = this.button7.GetComponent<Button> ().colors;
      colors.normalColor = Color.red;
      this.button7.GetComponent<Button> ().colors = colors;
      List<int> currentlist = this.row_column[6];
      this.rowClicked[currentlist[0]].Add(7);
      this.columnClicked[currentlist[1]].Add(7);
      Debug.Log(this.rowClicked[currentlist[0]]);
      if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
      this.win=true;
      }

    }


    private void onClick8(){
      Debug.Log("onclick");
      var colors = this.button8.GetComponent<Button> ().colors;
              colors.normalColor = Color.red;
              this.button8.GetComponent<Button> ().colors = colors;
      List<int> currentlist = this.row_column[7];
      this.rowClicked[currentlist[0]].Add(3);
      this.columnClicked[currentlist[1]].Add(3);
      Debug.Log(this.rowClicked[currentlist[0]]);

      if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
      this.win=true;
      }


    }


    public void onClick9(){
      Debug.Log("onclick");
      var colors = this.button9.GetComponent<Button> ().colors;
              colors.normalColor = Color.red;
              this.button9.GetComponent<Button> ().colors = colors;
      List<int> currentlist = this.row_column[8];
      this.rowClicked[currentlist[0]].Add(9);
      this.columnClicked[currentlist[1]].Add(9);
      Debug.Log(this.rowClicked[currentlist[0]]);

      if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
      this.win=true;
      }


    }


    public void onClick10(){
      Debug.Log("onclick");
      var colors = this.button10.GetComponent<Button> ().colors;
              colors.normalColor = Color.red;
              this.button10.GetComponent<Button> ().colors = colors;
      List<int> currentlist = this.row_column[9];
      this.rowClicked[currentlist[0]].Add(10);
      this.columnClicked[currentlist[1]].Add(10);
      Debug.Log(this.rowClicked[currentlist[0]]);

      if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
      this.win=true;
      }

    }


    public void onClick(){
      Debug.Log("onclick");
      var colors = this.button3.GetComponent<Button> ().colors;
              colors.normalColor = Color.red;
              this.button3.GetComponent<Button> ().colors = colors;
      List<int> currentlist = this.row_column[2];
      this.rowClicked[currentlist[0]].Add(3);
      this.columnClicked[currentlist[1]].Add(3);
      Debug.Log(this.rowClicked[currentlist[0]]);

      if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
      this.win=true;
      }


    }


    public void onClick11(){
      Debug.Log("onclick");
      var colors = this.button11.GetComponent<Button> ().colors;
              colors.normalColor = Color.red;
              this.button11.GetComponent<Button> ().colors = colors;
      List<int> currentlist = this.row_column[10];
      this.rowClicked[currentlist[0]].Add(3);
      this.columnClicked[currentlist[1]].Add(3);
      Debug.Log(this.rowClicked[currentlist[0]]);

      if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
      this.win=true;
      }}

      public void onClick12(){
        Debug.Log("onclick");
        var colors = this.button12.GetComponent<Button> ().colors;
                colors.normalColor = Color.red;
                this.button12.GetComponent<Button> ().colors = colors;
        List<int> currentlist = this.row_column[11];
        this.rowClicked[currentlist[0]].Add(3);
        this.columnClicked[currentlist[1]].Add(3);
        Debug.Log(this.rowClicked[currentlist[0]]);

        if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
        this.win=true;
        }}

        public void onClick13(){
          Debug.Log("onclick");
          var colors = this.button13.GetComponent<Button> ().colors;
                  colors.normalColor = Color.red;
                  this.button13.GetComponent<Button> ().colors = colors;
          List<int> currentlist = this.row_column[12];
          this.rowClicked[currentlist[0]].Add(3);
          this.columnClicked[currentlist[1]].Add(3);
          Debug.Log(this.rowClicked[currentlist[0]]);

          if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
          this.win=true;
          }}

          public void onClick14(){
            Debug.Log("onclick");
            var colors = this.button14.GetComponent<Button> ().colors;
            colors.normalColor = Color.red;
            this.button14.GetComponent<Button> ().colors = colors;
            List<int> currentlist = this.row_column[13];
            this.rowClicked[currentlist[0]].Add(14);
            this.columnClicked[currentlist[1]].Add(14);
            Debug.Log(this.rowClicked[currentlist[0]]);

            if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
            this.win=true;
            }}

            public void onClick15(){
              Debug.Log("onclick");
              var colors = this.button15.GetComponent<Button> ().colors;
                      colors.normalColor = Color.red;
                      this.button15.GetComponent<Button> ().colors = colors;
              List<int> currentlist = this.row_column[14];
              this.rowClicked[currentlist[0]].Add(15);
              this.columnClicked[currentlist[1]].Add(15);
              Debug.Log(this.rowClicked[currentlist[0]]);

              if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
              this.win=true;
              }}

              public void onClick16(){
                Debug.Log("onclick");
                var colors = this.button16.GetComponent<Button> ().colors;
                        colors.normalColor = Color.red;
                        this.button16.GetComponent<Button> ().colors = colors;
                List<int> currentlist = this.row_column[15];
                this.rowClicked[currentlist[0]].Add(3);
                this.columnClicked[currentlist[1]].Add(3);
                Debug.Log(this.rowClicked[currentlist[0]]);

                if(this.rowClicked[currentlist[0]].Count==4 || this.columnClicked[currentlist[1]].Count==4){
                this.win=true;
                }}




}
