using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class ActivePlayerManager : MonoBehaviour
{
    public static ActivePlayerManager instance;
    [SerializeField] private int SplitLimitBase;
    public List<PlayerController> playerControllers;
    private int controllerIndex;
    private CameraBehaviors cameraBehaviors;
    private SceneActions sceneActions;
    private PlayerController ActivePlayerController;
    private float shrinkSpeed;
    private Vector2 inputMovement => GameManager.Instance.InputManager.Movement;
    //private Vector2 inputMovementMobile => GameManager.Instance.InputManager.MovementMobile;
    public bool powerupInvincible = false;
    public bool powerupActivated = false;
    public bool powerupSpeedActivated = false;
    public bool powerupJumpActivated = false;
    public bool powerupInvinActivated = false;

    private void Awake()
    {
        Status.SetSplitLimitBase(SplitLimitBase);
        controllerIndex = 0;
        shrinkSpeed = 0.1f;
        playerControllers = GetComponentsInChildren<PlayerController>().ToList();
        foreach (PlayerController playerController in playerControllers)
        {
            playerController.SetStatus(0);
        }
        cameraBehaviors = GetComponentInChildren<CameraBehaviors>();
        sceneActions = new SceneActions();
    }

    private void Start()
    {
        instance = this;
        GameManager.Instance.InputManager.OnResetLevel += OnResetLevel;
        GameManager.Instance.InputManager.OnJump += OnJump;
    }

    private void OnDestroy()
    {
        GameManager.Instance.InputManager.OnResetLevel -= OnResetLevel;
        GameManager.Instance.InputManager.OnJump -= OnJump;
    }

    private void FixedUpdate()
    {
        ActivePlayerController.Move();
        //ActivePlayerController.OnMovement(inputMovementMobile);
    }

    private void OnResetLevel()
    {
        sceneActions.ResetLevel();
    }

    public void OnJump()
    {
        ActivePlayerController.OnJump();
    }
}
