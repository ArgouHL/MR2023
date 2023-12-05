using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance;
   internal PlayerInpur input;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            input = new PlayerInpur();
        }
    }

    private void Start()
    {
        input.UI.Enable();
        input.Player.Enable();
    }




}
