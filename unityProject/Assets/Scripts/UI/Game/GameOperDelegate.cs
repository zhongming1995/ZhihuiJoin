using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOperDelegate:MonoBehaviour
{
    public delegate void GameToHome();
    public static event GameToHome gameToHome;

    public delegate void BackToEdit();
    public static event BackToEdit backToEdit;

    public delegate void GameReplay();
    public static event GameReplay gameReplay;

    public static void GoToHome()
    {
        gameToHome?.Invoke();
    }

    public static void GotoEdit()
    {
        backToEdit?.Invoke();
    }

    public static void Replay()
    {
        gameReplay?.Invoke();
    }
}

