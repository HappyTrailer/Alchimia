using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interface : MonoBehaviour {

    public GameObject receptPotion;
    public GameObject receptOnePotion;

    public GameObject tradeCooki;
    public GameObject tradeStudy;
    public GameObject tradeIngr;
    public GameObject tradeMenuItems;
    public GameObject recepts;
    public GameObject study;
    public GameObject menuItems;
    public GameObject twoMenuItems;
    public GameObject invPanel;
    public GameObject achPanel;
    public GameObject settPanel;

    Animator animTradeCooki;
    Animator animTradeStudy;
    Animator animTradeIngr;
    Animator tradeAnimMenu;
    Animator animRecepts;
    Animator animStudy;
    Animator animMenu;
    Animator twoAnimMenu;
    Animator animInv;
    Animator animAch;
    Animator animSett;

    void Start()
    {
        animTradeCooki = tradeCooki.GetComponent<Animator>();
        animTradeStudy = tradeStudy.GetComponent<Animator>();
        animTradeIngr = tradeIngr.GetComponent<Animator>();
        tradeAnimMenu = tradeMenuItems.GetComponent<Animator>();
        animRecepts = recepts.GetComponent<Animator>();
        animStudy = study.GetComponent<Animator>();
        animMenu = menuItems.GetComponent<Animator>();
        twoAnimMenu = twoMenuItems.GetComponent<Animator>();
        animInv = invPanel.GetComponent<Animator>();
        animAch = achPanel.GetComponent<Animator>();
        animSett = settPanel.GetComponent<Animator>();
    }

    void Update()
    {
        if (animMenu.GetCurrentAnimatorStateInfo(0).IsName("ReceptOpen") && animMenu.GetBool("Recept") && !receptOnePotion.activeSelf)
        {
            if (animMenu.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                receptPotion.SetActive(true);
        }
    }

    public void ShowOneRecept()
    {
        if (!receptOnePotion.activeSelf)
        {
            receptPotion.SetActive(false);
            receptOnePotion.SetActive(true);
        }
        else
            receptOnePotion.SetActive(false);
    }

    public void ShowRecept()
    {
        if (animMenu.GetBool("Recept"))
        {
            receptPotion.SetActive(false);
            animMenu.SetTrigger("ReceptClose");
        }
        else
            animMenu.SetTrigger("ReceptOpen");

        animMenu.transform.FindChild("Recept").GetComponentInChildren<Button>().enabled = animMenu.GetBool("Recept");
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
        invPanel.GetComponent<Inventory>().FillInventory();
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
        invPanel.GetComponent<Inventory>().FillInventory();
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

        study.transform.GetChild(0).GetComponent<Text>().text = "Выберите инструмент для исследования";
        study.transform.FindChild("Items").gameObject.SetActive(false);
        animStudy.transform.FindChild("RGBState").FindChild("Red").GetComponentInChildren<Button>().enabled = true;
        animStudy.transform.FindChild("RGBState").FindChild("Green").GetComponentInChildren<Button>().enabled = true;
        animStudy.transform.FindChild("RGBState").FindChild("Blue").GetComponentInChildren<Button>().enabled = true;
    }

    public void FirstOpen()
    {
        animStudy.SetTrigger("First");

        study.transform.GetChild(0).GetComponent<Text>().text = "";
        study.transform.FindChild("Items").gameObject.SetActive(true);
        study.transform.FindChild("Items").GetChild(0).GetComponent<Text>().text = "Выберите ингридиент";
        animStudy.transform.FindChild("RGBState").FindChild("Red").GetComponentInChildren<Button>().enabled = false;
        animStudy.transform.FindChild("RGBState").FindChild("Green").GetComponentInChildren<Button>().enabled = true;
        animStudy.transform.FindChild("RGBState").FindChild("Blue").GetComponentInChildren<Button>().enabled = true;
    }

    public void TwoOpen()
    {
        animStudy.SetTrigger("Two");

        study.transform.GetChild(0).GetComponent<Text>().text = "";
        study.transform.FindChild("Items").gameObject.SetActive(true);
        study.transform.FindChild("Items").GetChild(0).GetComponent<Text>().text = "Выберите ингридиент";
        animStudy.transform.FindChild("RGBState").FindChild("Green").GetComponentInChildren<Button>().enabled = false;
        animStudy.transform.FindChild("RGBState").FindChild("Red").GetComponentInChildren<Button>().enabled = true;
        animStudy.transform.FindChild("RGBState").FindChild("Blue").GetComponentInChildren<Button>().enabled = true;
    }

    public void ThreeOpen()
    {
        animStudy.SetTrigger("Three");

        study.transform.GetChild(0).GetComponent<Text>().text = "";
        study.transform.FindChild("Items").gameObject.SetActive(true);
        study.transform.FindChild("Items").GetChild(0).GetComponent<Text>().text = "Выберите первый ингридиент";
        animStudy.transform.FindChild("RGBState").FindChild("Blue").GetComponentInChildren<Button>().enabled = false;
        animStudy.transform.FindChild("RGBState").FindChild("Green").GetComponentInChildren<Button>().enabled = true;
        animStudy.transform.FindChild("RGBState").FindChild("Red").GetComponentInChildren<Button>().enabled = true;
    }

    public void ShowRecepts()
    {
        if (!animRecepts.GetBool("Opened"))
            animRecepts.SetTrigger("StudyOpen");
        else
            animRecepts.SetTrigger("StudyClose");
        animRecepts.SetBool("Opened", !animRecepts.GetBool("Opened"));
    }

    public void ShowTradeMenu()
    {
        tradeAnimMenu.SetTrigger("TradeMenuOpen");
        animTradeIngr.SetTrigger("TradeOpen");
        animTradeIngr.SetBool("Opened", true);
    }

    public void ShowTradeIngr()
    {
        if (!animTradeIngr.GetBool("Opened"))
        {
            animTradeIngr.SetTrigger("TradeOpen");
            animTradeIngr.SetBool("Opened", true);
        }
        if (animTradeStudy.GetBool("Opened"))
        {
            animTradeStudy.SetTrigger("TradeClose");
            animTradeStudy.SetBool("Opened", false);
        }
        if (animTradeCooki.GetBool("Opened"))
        {
            animTradeCooki.SetTrigger("TradeClose");
            animTradeCooki.SetBool("Opened", false);
        }
    }

    public void ShowTradeStudy()
    {
        if (!animTradeStudy.GetBool("Opened"))
        {
            animTradeStudy.SetTrigger("TradeOpen");
            animTradeStudy.SetBool("Opened", true);
        }
        if (animTradeCooki.GetBool("Opened"))
        {
            animTradeCooki.SetTrigger("TradeClose");
            animTradeCooki.SetBool("Opened", false);
        }
    }

    public void ShowTradeCooki()
    {
        if (!animTradeCooki.GetBool("Opened"))
        {
            animTradeCooki.SetTrigger("TradeOpen");
            animTradeCooki.SetBool("Opened", true);
        }
    }

    public void ShowTradeGame()
    {
        if (animTradeIngr.GetBool("Opened"))
        {
            animTradeIngr.SetTrigger("TradeClose");
            animTradeIngr.SetBool("Opened", false);
        }
        if (animTradeStudy.GetBool("Opened"))
        {
            animTradeStudy.SetTrigger("TradeClose");
            animTradeStudy.SetBool("Opened", false);
        }
        if (animTradeCooki.GetBool("Opened"))
        {
            animTradeCooki.SetTrigger("TradeClose");
            animTradeCooki.SetBool("Opened", false);
        }
        tradeAnimMenu.SetTrigger("TradeMenuClose");
    }

    public void NextPage()
    {
        invPanel.GetComponent<Inventory>().NextPage();
    }

    public void PrevPage()
    {
        invPanel.GetComponent<Inventory>().PrevPage();
    }
}
