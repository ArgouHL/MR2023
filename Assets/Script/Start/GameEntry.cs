using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntry : MonoBehaviour
{
   public void EnterGame()
    {
        SceneFade.instance.FadeOutAndLoad(3);
    }
}
