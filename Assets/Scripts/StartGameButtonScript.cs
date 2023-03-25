using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButtonScript : MonoBehaviour
{
   public void movetoinstructions(){
    SceneManager.LoadScene("InstructionScene");
   }
}
