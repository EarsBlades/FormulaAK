using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
    public LevelController levelController;


    public void OnTriggerEnter()
    {
        LevelController.instance.isEndGame();
    }
}
