using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public static SkinManager instance;
    [SerializeField] private Image shopActiveSkin;
    [SerializeField] private Sprite[] skins;
    [SerializeField] private TextMeshProUGUI textspikes;
    [SerializeField] private TextMeshProUGUI textblock;
    [SerializeField] private TextMeshProUGUI textrainbow;
    private Animator animation1;
    [SerializeField] private GameObject[] locks;

    void Start()
    {
        instance = this;
        if(gameObject.GetComponent<Animator>() != null)
        {
            animation1 = GetComponent<Animator>();
        }
        if (!PlayerPrefs.HasKey("Activeskin"))
        {
            PlayerPrefs.SetInt("Activeskin", 1);
        }
        SelectSkin();
        if (locks != null && locks.Length > 0)
        {
            Locks();
        }
    }

    void SelectSkin()
    {
        if (animation1 != null)
        {
            animation1.enabled = PlayerPrefs.GetInt("Activeskin") == 15;
        }
        Color colorx = PlayerPrefs.GetInt("Activeskin") == 1 ? new Color32(0x74, 0x8B, 0xFB, 0xFF) : Color.white;
        colorx = PlayerPrefs.GetInt("Activeskin") == 2 ? Color.red : colorx;
        colorx = PlayerPrefs.GetInt("Activeskin") == 3 ? Color.yellow : colorx;
        colorx = PlayerPrefs.GetInt("Activeskin") == 4 ? Color.green : colorx;
        colorx = PlayerPrefs.GetInt("Activeskin") == 5 ? Color.magenta : colorx;
        colorx = PlayerPrefs.GetInt("Activeskin") == 6 ? Color.cyan : colorx;



        if (textspikes != null)
        {
            //text1.text = PlayerPrefs.GetInt("LevelsCompleted").ToString() + "/25";
            textspikes.text = "25";

        }
        if (textblock != null)
        {
            //text2.text = PlayerPrefs.GetInt("LevelsCompleted").ToString() + "/35";
            textspikes.text = "35";
        }
        if (textrainbow != null)
        {
            textrainbow.text = "15";
        }
        if (!PlayerPrefs.HasKey("Activeskin"))
        {
            PlayerPrefs.SetInt("Activeskin", 1);
        }
        if (shopActiveSkin != null)
        {
            shopActiveSkin.sprite = skins[PlayerPrefs.GetInt("Activeskin") - 1];
            shopActiveSkin.color = colorx;
            if(shopActiveSkin.GetComponentInParent<Animator>() != null)
            {
                //Debug.Log("Component exists");
                Animator animatorshopactiveskin = shopActiveSkin.GetComponentInParent<Animator>();
                animatorshopactiveskin.enabled = PlayerPrefs.GetInt("Activeskin") == 15;
            }
            
        }
        if (GetComponent<SpriteRenderer>() != null && PlayerPrefs.HasKey("Activeskin"))
        {
            SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer>();
            sp.sprite = skins[PlayerPrefs.GetInt("Activeskin") - 1];
            sp.color = colorx;
        }
        if(locks != null && locks.Length > 0)
        {
            Locks();
        }
        Debug.Log(PlayerPrefs.GetInt("Activeskin"));
    }

    public void Skin1()
    {
        Debug.Log("1");
        PlayerPrefs.SetInt("Activeskin", 1);
        SelectSkin();
    }

    public void Skin2()
    {
        Debug.Log("2");
        PlayerPrefs.SetInt("Activeskin", 2);
        SelectSkin();

    }

    public void Skin3()
    {
        PlayerPrefs.SetInt("Activeskin", 3);
        SelectSkin();

    }

    public void Skin4()
    {
        PlayerPrefs.SetInt("Activeskin", 4);
        SelectSkin();
    }

    public void Skin5()
    {
        PlayerPrefs.SetInt("Activeskin", 5);
        SelectSkin();
    }

    public void Skin6()
    {
        PlayerPrefs.SetInt("Activeskin", 6);
        SelectSkin();
    }

    public void Skin7() // mc pig
    {
        if(PlayerPrefs.HasKey("SkinMcpig"))
        {
            PlayerPrefs.SetInt("Activeskin", 7);
            SelectSkin();
        }
        
    }

    public void Skin8() // cheese
    {
        if(PlayerPrefs.HasKey("SkinCheese"))
        {
            PlayerPrefs.SetInt("Activeskin", 8);
            SelectSkin();
        }
        
    }

    public void Skin9() // sudoku
    {
        if (PlayerPrefs.HasKey("SkinSudoku"))
        {
            PlayerPrefs.SetInt("Activeskin", 9);
            SelectSkin();
        }
    }

    public void Skin10() // rubikscube
    {
        if (PlayerPrefs.HasKey("SkinRubikscube"))
        {
            PlayerPrefs.SetInt("Activeskin", 10);
            SelectSkin();
        }
    }

    public void Skin11() // brick
    {
        if (PlayerPrefs.HasKey("SkinBrick"))
        {
            PlayerPrefs.SetInt("Activeskin", 11);
            SelectSkin();
        }
    }

    public void Skin12() // flag
    {
        if (PlayerPrefs.HasKey("SkinFlag"))
        {
            PlayerPrefs.SetInt("Activeskin", 12);
            SelectSkin();
        }
    }

    public void Skin13() // emoji
    {
        if (PlayerPrefs.HasKey("SkinEmoji"))
        {
            PlayerPrefs.SetInt("Activeskin", 13);
            SelectSkin();
        }
    }

    public void Skin14() // slime
    {
        if (PlayerPrefs.HasKey("SkinSlime"))
        {
            PlayerPrefs.SetInt("Activeskin", 14);
            SelectSkin();
        }
    }

    public void Skin15() // changing colors
    {
        if(PlayerPrefs.HasKey("SkinRainbow") && PlayerPrefs.GetInt("LevelsCompleted") > 14)
        {
            PlayerPrefs.SetInt("Activeskin", 15);
            SelectSkin();
        }
    }

    public void Skin16() // robot
    {
        if (PlayerPrefs.HasKey("SkinRobot"))
        {
            PlayerPrefs.SetInt("Activeskin", 16);
            SelectSkin();
        }
    }

    public void Skin17() // monster2
    {
        if (PlayerPrefs.HasKey("SkinMonster2"))
        {
            PlayerPrefs.SetInt("Activeskin", 17);
            SelectSkin();
        }
    }

    public void Skin18() // Skin Spikes
    {
        if (PlayerPrefs.HasKey("SkinSpikes"))
        {
            PlayerPrefs.SetInt("Activeskin", 18);
            SelectSkin();
        }
    }

    public void Skin19() // monster
    {
        if (PlayerPrefs.HasKey("SkinMonster"))
        {
            PlayerPrefs.SetInt("Activeskin", 19);
            SelectSkin();
        }
    }

    public void Skin20() // Skin Block
    {
        if (PlayerPrefs.HasKey("SkinBlock"))
        {
            PlayerPrefs.SetInt("Activeskin", 20);
            SelectSkin();
        }
    }

    private void Locks()
    {
        locks[0].SetActive(!PlayerPrefs.HasKey("SkinRubikscube"));
        locks[1].SetActive(!PlayerPrefs.HasKey("SkinBrick"));
        locks[2].SetActive(!PlayerPrefs.HasKey("SkinFlag"));
        locks[3].SetActive(!PlayerPrefs.HasKey("SkinEmoji"));
        locks[4].SetActive(!PlayerPrefs.HasKey("SkinSlime"));
        locks[5].SetActive(!PlayerPrefs.HasKey("SkinMcpig"));
        locks[6].SetActive(!PlayerPrefs.HasKey("SkinRobot"));
        locks[7].SetActive(!PlayerPrefs.HasKey("SkinMonster2"));
        locks[8].SetActive(!PlayerPrefs.HasKey("SkinSudoku"));
        locks[9].SetActive(!PlayerPrefs.HasKey("SkinMonster"));
        locks[10].SetActive(!PlayerPrefs.HasKey("SkinCheese"));
    }
}
