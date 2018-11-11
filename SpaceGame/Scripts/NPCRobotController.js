#pragma strict

var gravity : float = 20.0;
private var velocity : Vector3;

function Start () 
{
           
}

function Update () {

    //var NPCcontroller : CharacterController = GetComponent(CharacterController);
     
    velocity.y -= gravity * Time.deltaTime;
    //NPCcontroller.Move(velocity * Time.deltaTime);
   
       

}