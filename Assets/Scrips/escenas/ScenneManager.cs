using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenneManager : MonoBehaviour
{
    public void loadscene(String nameScene) {
        SceneManager.LoadScene(nameScene);

    }

    
}
