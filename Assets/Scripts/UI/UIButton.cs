using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class UIButton : MonoBehaviour {
   //The UI Button we want to programmatically click.
   [SerializeField] private Button button;
   [SerializeField] private string KeyInput;
 
   void Update() {
      //Check if the Enter key has been pressed.
      if(Input.GetKeyDown(KeyCode.Return)) {
     
         //Invoke the button's onClick event.
         button.onClick.Invoke();
      }
   }
}