using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

}
