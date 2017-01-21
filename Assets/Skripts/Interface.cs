using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

    public GameObject menuItems;
    public GameObject twoMenuItems;
    public GameObject invPanel;
    public GameObject achPanel;
    public GameObject settPanel;

    Animator animMenu;
    Animator twoAnimMenu;
    Animator animInv;
    Animator animAch;
    Animator animSett;

    void Start()
    {
        animMenu = menuItems.GetComponent<Animator>();
        twoAnimMenu = twoMenuItems.GetComponent<Animator>();
        animInv = invPanel.GetComponent<Animator>();
        animAch = achPanel.GetComponent<Animator>();
        animSett = settPanel.GetComponent<Animator>();
    }

    public void ShowMenu()
    {
        animMenu.SetBool("Opened", !animMenu.GetBool("Opened"));
    }

    public void ShowTwoMenu()
    {
        twoAnimMenu.SetBool("Opened", true);
        animInv.SetBool("Opened", true);
    }

    public void ShowInventory()
    {
        animInv.SetBool("Opened", true);
        animAch.SetBool("Opened", false);
        animSett.SetBool("Opened", false);
    }

    public void ShowAchivements()
    {
        animAch.SetBool("Opened", true);
        animInv.SetBool("Opened", false);
        animSett.SetBool("Opened", false);
    }

    public void ShowSettings()
    {
        animSett.SetBool("Opened", true);
        animAch.SetBool("Opened", false);
        animInv.SetBool("Opened", false);
    }

    public void ShowGame()
    {
        twoAnimMenu.SetBool("Opened", false);
        animSett.SetBool("Opened", false);
        animAch.SetBool("Opened", false);
        animInv.SetBool("Opened", false);
    }
}
