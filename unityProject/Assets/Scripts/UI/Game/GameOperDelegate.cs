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

    public delegate void PianoBegin();
    public static event PianoBegin pianoBegin;

    public delegate void CardBegin();
    public static event CardBegin cardBegin;

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

    public static void PlayPiano()
    {
        pianoBegin?.Invoke();
    }

    public static void PlayCard()
    {
        cardBegin?.Invoke();
    }
}

