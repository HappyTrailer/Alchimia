using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interface : MonoBehaviour {

    public GameObject receptPotion;
    public GameObject receptOnePotion;
    public GameObject receptOnePotionCooking;
    public GameObject inventaryForStudy;
    public GameObject scrollerIngridientCount;

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
            {
                if (StartCooki.globalReceptId == -1)
                    receptPotion.SetActive(true);
                else
                    receptOnePotionCooking.SetActive(true);
            }
        }
    }

    public void StartCooking()
    {
        ShowOneRecept();
        ShowRecept();
    }

    public void CancelRecept()
    {
        StartCooki.CancelCooki();
        receptOnePotionCooking.SetActive(false);
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

    public void ShowReceptCooking()
    {
        if (animMenu.GetBool("Recept"))
        {
            receptOnePotionCooking.SetActive(false);
            animMenu.SetTrigger("ReceptClose");
        }
        animMenu.transform.FindChild("Recept").GetComponentInChildren<Button>().enabled = true;
        animMenu.SetBool("Recept", false);
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
        {
            animStudy.SetTrigger("StudyOpen");
            FirstOpen();
        }
        else
            animStudy.SetTrigger("StudyClose");
        animStudy.SetBool("Opened", !animStudy.GetBool("Opened"));
    }

    public void FirstOpen()
    {
        animStudy.SetTrigger("First");
        ResearchTools.tool = "Mortar";
        study.transform.GetChild(0).GetComponent<Text>().text = "";
        study.transform.FindChild("Items").gameObject.SetActive(true);
        study.transform.FindChild("Start").gameObject.SetActive(false);
        study.transform.FindChild("Cancel").gameObject.SetActive(false);
        animStudy.transform.FindChild("RGBState").FindChild("Red").GetComponentInChildren<Button>().enabled = false;
        animStudy.transform.FindChild("RGBState").FindChild("Green").GetComponentInChildren<Button>().enabled = true;
        animStudy.transform.FindChild("RGBState").FindChild("Blue").GetComponentInChildren<Button>().enabled = true;
        ResearchTools.currentIngridient = null;
        ResearchTools.currentIngridientSecond = null;
    }

    public void TwoOpen()
    {
        animStudy.SetTrigger("Two");
        ResearchTools.tool = "Distiller";
        study.transform.GetChild(0).GetComponent<Text>().text = "";
        study.transform.FindChild("Items").gameObject.SetActive(true);
        study.transform.FindChild("Start").gameObject.SetActive(false);
        study.transform.FindChild("Cancel").gameObject.SetActive(false);
        animStudy.transform.FindChild("RGBState").FindChild("Green").GetComponentInChildren<Button>().enabled = false;
        animStudy.transform.FindChild("RGBState").FindChild("Red").GetComponentInChildren<Button>().enabled = true;
        animStudy.transform.FindChild("RGBState").FindChild("Blue").GetComponentInChildren<Button>().enabled = true;
        ResearchTools.currentIngridient = null;
        ResearchTools.currentIngridientSecond = null;
    }

    public void ThreeOpen()
    {
        animStudy.SetTrigger("Three");
        ResearchTools.tool = "Blender";
        study.transform.GetChild(0).GetComponent<Text>().text = "";
        study.transform.FindChild("Items").gameObject.SetActive(true);
        study.transform.FindChild("Start").gameObject.SetActive(false);
        study.transform.FindChild("Cancel").gameObject.SetActive(false);
        animStudy.transform.FindChild("RGBState").FindChild("Blue").GetComponentInChildren<Button>().enabled = false;
        animStudy.transform.FindChild("RGBState").FindChild("Green").GetComponentInChildren<Button>().enabled = true;
        animStudy.transform.FindChild("RGBState").FindChild("Red").GetComponentInChildren<Button>().enabled = true;
        ResearchTools.currentIngridient = null;
        ResearchTools.currentIngridientSecond = null;
    }

    public void ShowRecepts()
    {
        if (!animRecepts.GetBool("Opened"))
            animRecepts.SetTrigger("StudyOpen");
        else
            animRecepts.SetTrigger("StudyClose");
        animRecepts.SetBool("Opened", !animRecepts.GetBool("Opened"));
        animRecepts.GetComponent<ReceptIngridientPanel>().FillRecepts();
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

    public void ShowRecepteByGrade(int grade)
    {
        this.GetComponent<ListRecipePotion>().FillRecepts(grade);
    }

    public void ShowIngridientsByGrade(int grade)
    {
        inventaryForStudy.GetComponent<InventoryForStudy>().ShowIngridient(grade);
    }

    public void ShowInventaryForStudy()
    {
        inventaryForStudy.SetActive(!inventaryForStudy.activeSelf);
        inventaryForStudy.GetComponent<InventoryForStudy>().ShowIngridient(1);
    }

    public void ShowScrollerIngridientCount(int param)
    {
        if(param == 1)
            scrollerIngridientCount.SetActive(!scrollerIngridientCount.activeSelf);
        else if (param == 2)
        {
            scrollerIngridientCount.SetActive(!scrollerIngridientCount.activeSelf);
            study.transform.FindChild("Items").gameObject.SetActive(false);
            study.transform.FindChild("Start").gameObject.SetActive(true);
            study.transform.FindChild("Cancel").gameObject.SetActive(true);
            ShowInventaryForStudy();
        }
        else if (param == 3)
        {
            study.transform.FindChild("Items").gameObject.SetActive(true);
            study.transform.FindChild("Start").gameObject.SetActive(false);
            study.transform.FindChild("Cancel").gameObject.SetActive(false);
        }
    }
}
