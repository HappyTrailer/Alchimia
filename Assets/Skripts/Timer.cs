using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public static float timer;
    public static float gradeValuePotion;
    public static bool flag;
    public static GameObject obj;
    public static int countIngridientsForOneStep = 0;
    public static int countWrongIngridients = 0;

    string gradeName;
    public Slider slider;
    public static Slider globalSlider;

    void Start()
    {
        globalSlider = slider;
        obj = gameObject;
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
        {
            gradeValuePotion += buff / 2 * countWrongIngridients;
            countIngridientsForOneStep -= countWrongIngridients;
            gradeValuePotion += buff * countIngridientsForOneStep;
        }
        else
            gradeValuePotion -= buff * countIngridientsForOneStep;
        slider.value = gradeValuePotion;
        if(StartCooki.LastIngridients())
        {
            Money.money += ListRecipePotion.masRecPotion[StartCooki.globalReceptId].Price * GetGrade();
            ListAchivments.moneyGetCount += ListRecipePotion.masRecPotion[StartCooki.globalReceptId].Price * GetGrade();
            ListAchivments.potionCookiCount++;
            ListAchivments.ChekAchiv();

            Messager.AddMess("Sprite/GameFiled/Research/flask_icon-icons.com_60843", "Создано: " + ListRecipePotion.masRecPotion[StartCooki.globalReceptId].NameRec, "Качество: " + gradeName);
            Messager.AddMess("Sprite/GameFiled/Shop/dollar-round-icon--18", "Получены деньги", ListRecipePotion.masRecPotion[StartCooki.globalReceptId].Price * GetGrade() + " монет");

            StartCooki.CancelCooki();
        }
        countWrongIngridients = 0;
        countIngridientsForOneStep = 0;
        flag = false;
        gameObject.SetActive(false);
    }

    public static void TimerStart()
    {
        countIngridientsForOneStep++;
        flag = true;
        timer = 10;
        obj.SetActive(true);
    }

    public static void TimerStop()
    {
        countWrongIngridients = 0;
        countIngridientsForOneStep = 0;
        flag = false;
        obj.SetActive(false);
    }

    public float GetGrade()
    {
        float grade = 0;
        if (gradeValuePotion <= 0.2f)
        {
            grade = 0.2f;
            gradeName = "Ужасное";
        }
        else if (gradeValuePotion > 0.2f && gradeValuePotion <= 0.4f)
        {
            grade = 0.5f;
            gradeName = "Плохое";
        }
        else if (gradeValuePotion > 0.4f && gradeValuePotion <= 0.6f)
        {
            grade = 1f;
            gradeName = "Обычное";
        }
        else if (gradeValuePotion > 0.6f && gradeValuePotion <= 0.8f)
        {
            grade = 1.5f;
            gradeName = "Хорошее";
        }
        else if (gradeValuePotion > 0.8f)
        {
            grade = 2f;
            gradeName = "Превосходное";
        }
        return grade;
    }

    public static void SliderActivate()
    {
        gradeValuePotion = 0.01f;
        globalSlider.value = gradeValuePotion;
    }

    public static void SliderDeActivate()
    {
        gradeValuePotion = 0.01f;
        globalSlider.value = gradeValuePotion;
    }
}
