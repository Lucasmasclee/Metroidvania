using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance { get; private set; }
    public InputManager InputManager { get; private set; }

    private void Awake()
    {
        instance = this;
        Instance = this;
        InputManager = new();
    }
}
