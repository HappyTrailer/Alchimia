using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public static float timer;
    public static float gradeValuePotion;
    public static bool flag;
    public static Slider globalSlider;
    public static GameObject globalSliderPanel;
    public static GameObject obj;
    public Slider slider;
    public GameObject sliderPabel;

    void Start()
    {
        globalSlider = slider;
        globalSliderPanel = sliderPabel;
        obj = gameObject;
        slider.gameObject.SetActive(false);
        sliderPabel.SetActive(false);
        gameObject.SetActive(false);
    }
	
	void Update () 
    {
        if (flag)
        {
            if (timer >= 0)
            {
                if (CookyTool.R2 == 0 && CookyTool.G2 == 0 && CookyTool.B2 == 0)
                {
                    ChangeGradeValuePotion(true);
                }
                else
                    timer -= Time.deltaTime;
            }
            else
            {
                ChangeGradeValuePotion(false);
            }
            GetComponent<Text>().text = timer.ToString("F1");
        }
	}

    void ChangeGradeValuePotion(bool managed)
    {
        float buff = 1.0f / (float)ListRecipePotion.masRecPotion[StartCooki.globalReceptId].Mass.Length;
        if (managed)
            gradeValuePotion += buff;
        else
            gradeValuePotion -= buff;
        slider.value = gradeValuePotion;
        if(StartCooki.LastIngridients())
        {
            Debug.Log("money " + Money.money);
            Debug.Log("Grade " + GetGrade());
            Debug.Log("GradeValue " + gradeValuePotion);
            Money.money += ListRecipePotion.masRecPotion[StartCooki.globalReceptId].Price * GetGrade();
            StartCooki.CancelCooki();
            Debug.Log("money " + Money.money);
        }
        flag = false;
        gameObject.SetActive(false);
    }

    public float GetGrade()
    {
        float grade = 0;
        if (gradeValuePotion <= 0.2f)
            grade = 0.2f;
        else if (gradeValuePotion > 0.2f && gradeValuePotion <= 0.4f)
            grade = 0.5f;
        else if (gradeValuePotion > 0.4f && gradeValuePotion <= 0.6f)
            grade = 1f;
        else if (gradeValuePotion > 0.6f && gradeValuePotion <= 0.8f)
            grade = 1.5f;
        else if (gradeValuePotion > 0.8f)
            grade = 2f;
        return grade;
    }

    public static void Activate()
    {
        gradeValuePotion = 0.01f;
        globalSlider.gameObject.SetActive(true);
        globalSliderPanel.SetActive(true);
        globalSlider.value = gradeValuePotion;
    }

    public static void DeActivate()
    {
        gradeValuePotion = 0.01f;
        globalSlider.gameObject.SetActive(false);
        globalSliderPanel.SetActive(false);
        globalSlider.value = gradeValuePotion;
    }
}
