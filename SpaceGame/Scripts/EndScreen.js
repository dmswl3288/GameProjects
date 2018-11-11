#pragma strict

var labelStyle1 : GUIStyle;
var labelStyle : GUIStyle;

function Start () {

}

function Update () {
   
   if(Input.GetButtonDown("Jump"))
   {
       Application.LoadLevel("SpaceGame");
       }

}
function OnGUI(){

      var sw : int = Screen.width;
      var sh : int = Screen.height;
      GUI.Label(Rect(0, sh/4, sw, sh/4), "★ G A M E  C L E A R ★", labelStyle1);
      GUI.Label(Rect(0, sh/2, sw, sh/4), "Replay : Space Key", labelStyle);
 }