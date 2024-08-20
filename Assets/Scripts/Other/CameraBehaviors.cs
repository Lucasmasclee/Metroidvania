using Cinemachine;
using UnityEngine;

public class CameraBehaviors : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    //private void Start()
    //{
    //    //virtualCamera.m_Lens.OrthographicSize = PlayerPrefs.GetFloat("FocusOnPlayer");
    //    //virtualCamera.m_Lens.OrthographicSize = PlayerPrefs.GetFloat("FocusOnPlayer");
    //}

    public void FollowChar(Transform player)
    {
        virtualCamera.Follow = player;
    }
}
