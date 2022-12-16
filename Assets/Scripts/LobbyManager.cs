using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LobbyManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        SoundManager.Instance.Play(Sounds.Start);
    }
}
