using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

    public GameObject recepts;
    public GameObject study;
    public GameObject menuItems;
    public GameObject twoMenuItems;
    public GameObject invPanel;
    public GameObject achPanel;
    public GameObject settPanel;

    Animator animRecepts;
    Animator animStudy;
    Animator animMenu;
    Animator twoAnimMenu;
    Animator animInv;
    Animator animAch;
    Animator animSett;

    void Start()
    {
        animRecepts = recepts.GetComponent<Animator>();
        animStudy = study.GetComponent<Animator>();
        animMenu = menuItems.GetComponent<Animator>();
        twoAnimMenu = twoMenuItems.GetComponent<Animator>();
        animInv = invPanel.GetComponent<Animator>();
        animAch = achPanel.GetComponent<Animator>();
        animSett = settPanel.GetComponent<Animator>();
    }

    public void ShowRecept()
    {
        if (animMenu.GetBool("Recept"))
            animMenu.SetTrigger("ReceptClose");
        else
            animMenu.SetTrigger("ReceptOpen");
        animMenu.SetBool("Recept", !animMenu.GetBool("Recept"));
    }

    public void ShowMenu()
    {
        if (animMenu.GetBool("Opened"))
            animMenu.SetTrigger("MenuClose");
        else
            animMenu.SetTrigger("MenuOpen");
        animMenu.SetBool("Opened", !animMenu.GetBool("Opened"));
    }

    public void ShowTwoMenu()
    {
        twoAnimMenu.SetTrigger("TwoMenuOpen");
        animInv.SetTrigger("Open");
        animInv.SetBool("Opened", true);
    }

    public void ShowInventory()
    {
        if (!animInv.GetBool("Opened"))
        {
            animInv.SetTrigger("Open");
            animInv.SetBool("Opened", true);
        }
        if (animAch.GetBool("Opened"))
        {
            animAch.SetTrigger("Close");
            animAch.SetBool("Opened", false);
        }
        if (animSett.GetBool("Opened"))
        {
            animSett.SetTrigger("Close");
            animSett.SetBool("Opened", false);
        }
    }

    public void ShowAchivements()
    {
        if (!animAch.GetBool("Opened"))
        {
            animAch.SetTrigger("Open");
            animAch.SetBool("Opened", true);
        }
        if (animSett.GetBool("Opened"))
        {
            animSett.SetTrigger("Close");
            animSett.SetBool("Opened", false);
        }
    }

    public void ShowSettings()
    {
        if (!animSett.GetBool("Opened"))
        {
            animSett.SetTrigger("Open");
            animSett.SetBool("Opened", true);
        }
    }

    public void ShowGame()
    {
        if (animInv.GetBool("Opened"))
        {
            animInv.SetTrigger("Close");
            animInv.SetBool("Opened", false);
        }
        if (animAch.GetBool("Opened"))
        {
            animAch.SetTrigger("Close");
            animAch.SetBool("Opened", false);
        }
        if (animSett.GetBool("Opened"))
        {
            animSett.SetTrigger("Close");
            animSett.SetBool("Opened", false);
        }
        twoAnimMenu.SetTrigger("TwoMenuClose");
    }

    public void ShowStudy()
    {
        if (!animStudy.GetBool("Opened"))
            animStudy.SetTrigger("StudyOpen");
        else
            animStudy.SetTrigger("StudyClose");
        animStudy.SetBool("Opened", !animStudy.GetBool("Opened"));
    }

    public void FirstOpen()
    {
        animStudy.SetTrigger("First");
    }

    public void TwoOpen()
    {
        animStudy.SetTrigger("Two");
    }

    public void ThreeOpen()
    {
        animStudy.SetTrigger("Three");
    }

    public void ShowRecepts()
    {
        if (!animRecepts.GetBool("Opened"))
            animRecepts.SetTrigger("StudyOpen");
        else
            animRecepts.SetTrigger("StudyClose");
        animRecepts.SetBool("Opened", !animRecepts.GetBool("Opened"));
    }
}
