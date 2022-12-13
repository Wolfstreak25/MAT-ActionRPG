using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Example : MonoBehaviour {
   //The UI Button we want to programmatically click.
   public Button button;
 
   void Update() {
      //Check if the Enter key has been pressed.
      if(Input.GetKeyDown(KeyCode.Return)) {
     
         //Invoke the button's onClick event.
         button.onClick.Invoke();
      }
   }
}