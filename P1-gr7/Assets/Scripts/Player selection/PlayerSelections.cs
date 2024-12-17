using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelections : MonoBehaviour
{
    public int character {get; set;}
    public int car {get; set;}

    public static PlayerSelections instance;


    void Awake(){
         if(instance != null && instance != this){
            Destroy(this);
         }
                 instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
