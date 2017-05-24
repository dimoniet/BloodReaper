﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour 
{

    public AudioSource buttonSound; 
    public AudioSource avraeAppears; 

    LevelLogic levelLogic;
    public GameObject menu1;
    public GameObject menu2;
    public GameObject menu3;
    public GameObject menuTesting;
    public GameObject options;

    float textCounter;
    public float startTextInterval = 1;
    int State;

    //Warning
    public GameObject warningObj;
    public GameObject warningHandle;
    public Animator warningAnim;
    int subState;
    bool isWarningPassed;

    //Title
    public GameObject titleScreen;
    public GameObject startText;
    public Animator titleAnim;

    //LevelSelector
    public int levelsPassed;

    public Button lvl1NoPassedButton;
    public GameObject lvl1NoPassed;
    public GameObject lvl1Passed;
    public Button lvl1Christal1;
    public Button lvl1Christal2;
    public Button lvl1Christal3;
    public GameObject lvl1Effect;

    public Button lvl2NoPassedButton;
    public GameObject lvl2NoPassed;
    public GameObject lvl2Passed;
    public Button lvl2Christal1;
    public Button lvl2Christal2;
    public Button lvl2Christal3;
    public GameObject lvl2Effect;


	void Start () 
    {
        levelLogic = GameObject.FindGameObjectWithTag("LevelMnanager").GetComponent<LevelLogic>();
        State = levelLogic.mainMenuState;

        if (State == 0)
        {
            warningObj.SetActive(true);
            titleScreen.SetActive(false);
            menu1.SetActive(false);
            menu2.SetActive(false);
            menu3.SetActive(false);
            menuTesting.SetActive(false);
        }
        else if (State == 1)
        {
            warningObj.SetActive(false);
            titleScreen.SetActive(true);
            menu1.SetActive(false);
            menu2.SetActive(false);
            menu3.SetActive(false);
            menuTesting.SetActive(false);
        }
        else if (State == 2)
        {
            warningObj.SetActive(false);
            titleScreen.SetActive(false);
            menu1.SetActive(false);
            menu2.SetActive(false);
            menu3.SetActive(true);
            menuTesting.SetActive(false);
        }

        Cursor.visible = true;

	}
	void Update () 
    {
        levelLogic.mainMenuState = State;

        if (State == 0)
        {
            if (Input.anyKey)
            {
                subState = 1;
                warningAnim.SetTrigger("out");
            }

            if (subState == 1)
            {
                textCounter += Time.deltaTime;

                if (textCounter >= 1.5f)
                {
                    warningHandle.SetActive(false);
                    warningAnim.SetTrigger("in");
                    subState = 2;
                }
            }
            else if (subState == 2)
            {
                textCounter += Time.deltaTime;

                if (textCounter >= 2.5f)
                {
                    avraeAppears.Play();
                    State = 1;
                    subState = 0;
                    titleScreen.SetActive(true);
                    warningObj.SetActive(false);
                    textCounter = 0;
                }
            }

        }
        if (State == 1) //Title
        {
            if (Input.anyKey)
            {
                subState = 1;
                titleAnim.SetTrigger("out");
                textCounter = 0;
            }
                
            //Text poping
            /////////////
            if (subState == 0)
            {
                textCounter += Time.deltaTime;

                if (textCounter >= startTextInterval * 2)
                {
                    startText.SetActive(true);
                    textCounter = 0;
                }
                else if (textCounter >= startTextInterval)
                {
                    startText.SetActive(false);
                }
            }
            else if (subState == 1)
            {
                textCounter += Time.deltaTime;

                if (textCounter >= 1.2f)
                {
                    SetMenu1();
                    textCounter = 0;
                }
            }
            /////////////
        }
        else if (State == 2) //Menu 1
        {
            
        }
        else if (State == 3) //Menu 2 (New Game or Select Level)
        {
            
        }        
        else if (State == 4) //Menu 3 (Select Level)
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                levelLogic.isLvl1Done = true;
                levelLogic.isLvl2Done = true;
                levelLogic.isLvl3Done = true;

                lvl1Christal1.interactable = true;
                lvl1Christal2.interactable = true;
                lvl1Christal3.interactable = true;
                lvl1Effect.SetActive(true);

                lvl2Christal1.interactable = true;
                lvl2Christal2.interactable = true;
                lvl2Christal3.interactable = true;
                lvl2Effect.SetActive(true);
            }

            if (levelLogic.isLvl1Done == true)
            {
                lvl1Passed.SetActive(true);
                lvl2NoPassedButton.interactable = true;

                if (levelLogic.lvl1Christals == 1)
                {
                    lvl1Christal1.interactable = true;
                }
                else if (levelLogic.lvl1Christals == 2)
                {
                    lvl1Christal1.interactable = true;
                    lvl1Christal2.interactable = true;
                }
                else if (levelLogic.lvl1Christals == 3)
                {
                    lvl1Christal1.interactable = true;
                    lvl1Christal2.interactable = true;
                    lvl1Christal3.interactable = true;
                    lvl1Effect.SetActive(true);
                }
            }

            if (levelLogic.isLvl2Done == true)
            {
                lvl2Passed.SetActive(true);
                //lvl2NoPassedButton.interactable = true;

                if (levelLogic.lvl2Christals == 1)
                {
                    lvl2Christal1.interactable = true;
                }
                else if (levelLogic.lvl2Christals == 2)
                {
                    lvl2Christal1.interactable = true;
                    lvl2Christal2.interactable = true;
                }
                else if (levelLogic.lvl2Christals == 3)
                {
                    lvl2Christal1.interactable = true;
                    lvl2Christal2.interactable = true;
                    lvl2Christal3.interactable = true;
                    lvl2Effect.SetActive(true);
                }
            }
        }
        else if (State == 5) //NewGame
        {

        }
        else if (State == 6) //Testing
        {

        }
	}

    public void Warning()
    {
        
    }

    public void SetMenu1 ()
    {
        State = 2;
        titleScreen.SetActive(false);
        menu1.SetActive(true);
    }
    public void BackToMenu1 ()
    {
        State = 2;
        menu1.SetActive(true);
        menu2.SetActive(false);
    } 
    public void SetMenu2 ()
    {
        State = 3;
        menu1.SetActive(false);
        menu2.SetActive(true);
    }
    public void BackToMenu2 ()
    {
        State = 3;
        menu1.SetActive(true);
        menu3.SetActive(false);
    } 
    public void SetMenu3 ()
    {
        State = 4;
        menu1.SetActive(false);
        menu3.SetActive(true);
    }
    public void SetTesting ()
    {
        State = 6;
        menu1.SetActive(false);
        menuTesting.SetActive(true);
    }
    public void BackTesting ()
    {
        State = 2;
        menu1.SetActive(true);
        menuTesting.SetActive(false);
    }

    public void GoLevel1_1 ()
    {
        SceneManager.LoadScene("Level 1.1", LoadSceneMode.Single);
    }
    public void GoLevel1_2 ()
    {
        SceneManager.LoadScene("Level 1.2", LoadSceneMode.Single);
    }
    public void GoLevel1_3 ()
    {
        SceneManager.LoadScene("Level 1.3", LoadSceneMode.Single);
    }
    public void GoLevel2_2 ()
    {
        SceneManager.LoadScene("Level 2.2", LoadSceneMode.Single);
    }
    public void GoPlayground ()
    {
        SceneManager.LoadScene("Playground", LoadSceneMode.Single);
    }    
    public void GoCombatArena ()
    {
        SceneManager.LoadScene("CombatArena", LoadSceneMode.Single);
    }
    public void LoadScene(int i)
    {
        levelLogic.LoadScene(i);
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        options.SetActive(true);
    }

    public void ForeverCrunch()
    {
        Application.OpenURL("https://forevercrunchgames.wixsite.com/bloodreaper");
    }

  public void PlayButtonSound()
    {
        buttonSound.Play();
    }
}
