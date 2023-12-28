using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GoSelectScene()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void GoPlayScene()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
