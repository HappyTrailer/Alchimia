using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListAchivments : MonoBehaviour {

    public static Achivment[] masAchivments;

    public static float moneyGetCount;
    public static float moneySetCount;
    public static float potionCookiCount;
    public static float ingridientOpenCount;
    public static float ingridientUseCount;
    public static float ingridientBuyCount;

    public static void ChekAchiv()
    {
        float count = 0;
        for (int i = 0; i < ListAchivments.masAchivments.Length; i++)
        {
            switch (ListAchivments.masAchivments[i].Type)
            {
                case "moneyGet":
                    count = ListAchivments.moneyGetCount;
                    break;
                case "moneySet":
                    count = ListAchivments.moneySetCount;
                    break;
                case "potionCooki":
                    count = ListAchivments.potionCookiCount;
                    break;
                case "ingridientOpen":
                    count = ListAchivments.ingridientOpenCount;
                    break;
                case "ingridientUse":
                    count = ListAchivments.ingridientUseCount;
                    break;
                case "ingridientBuy":
                    count = ListAchivments.ingridientBuyCount;
                    break;
            }
            if (ListAchivments.masAchivments[i].Count <= count && !ListAchivments.masAchivments[i].Done)
            {
                Money.money += ListAchivments.masAchivments[i].Money;
                ListAchivments.masAchivments[i].Done = true;
                Messager.AddMess("Sprite/GameFiled/Inventory/Achievement_obtained_icon_TF2", "Получено достижение", ListAchivments.masAchivments[i].Name);
                Messager.AddMess("Sprite/GameFiled/Shop/dollar-round-icon--18", "Получены деньги", ListAchivments.masAchivments[i].Money + " монет");
            }
        }
    }

    public static void AchivmentsMasStart()
    {
        masAchivments = new Achivment[]
        {
            new Achivment("moneyGet", "Заработать 100 золота", 100, 10, false, "Sprite/GameFiled/Achiv/m1"),
            new Achivment("moneyGet", "Заработать 500 золота", 500, 50, false, "Sprite/GameFiled/Achiv/m2"),
            new Achivment("moneyGet", "Заработать 1000 золота", 1000, 100, false, "Sprite/GameFiled/Achiv/m3"),
            new Achivment("moneyGet", "Заработать 1500 золота", 1500, 150, false, "Sprite/GameFiled/Achiv/m3"),
            new Achivment("moneyGet", "Заработать 2000 золота", 2000, 200, false, "Sprite/GameFiled/Achiv/m3"),
            new Achivment("moneySet", "Потратить 100 золота", 100, 10, false, ""),
            new Achivment("moneySet", "Потратить 500 золота", 500, 50, false, ""),
            new Achivment("moneySet", "Потратить 1000 золота", 1000, 100, false, ""),
            new Achivment("moneySet", "Потратить 1500 золота", 1500, 150, false, ""),
            new Achivment("moneySet", "Потратить 2000 золота", 2000, 200, false, ""),
            new Achivment("potionCooki", "Приготовить 10 зелий", 10, 10, false, "Sprite/GameFiled/Achiv/p1"),
            new Achivment("potionCooki", "Приготовить 25 зелий", 25, 50, false, "Sprite/GameFiled/Achiv/p2"),
            new Achivment("potionCooki", "Приготовить 75 зелий", 75, 100, false, "Sprite/GameFiled/Achiv/p3"),
            new Achivment("potionCooki", "Приготовить 150 зелий", 150, 150, false, "Sprite/GameFiled/Achiv/p3"),
            new Achivment("potionCooki", "Приготовить 300 зелий", 300, 200, false, "Sprite/GameFiled/Achiv/p3"),
            new Achivment("ingridientOpen", "Окрыть 5 ингридиентов", 5, 10, false, ""),
            new Achivment("ingridientOpen", "Окрыть 15 ингридиентов", 15, 30, false, ""),
            new Achivment("ingridientOpen", "Окрыть 30 ингридиентов", 30, 50, false, ""),
            new Achivment("ingridientOpen", "Окрыть 50 ингридиентов", 50, 100, false, ""),
            new Achivment("ingridientUse", "Использовать 10 ингридиентов", 10, 10, false, "Sprite/GameFiled/Achiv/i1"),
            new Achivment("ingridientUse", "Использовать 100 ингридиентов", 100, 50, false, "Sprite/GameFiled/Achiv/i2"),
            new Achivment("ingridientUse", "Использовать 500 ингридиентов", 500, 100, false, "Sprite/GameFiled/Achiv/i3"),
            new Achivment("ingridientUse", "Использовать 1000 ингридиентов", 1000, 200, false, "Sprite/GameFiled/Achiv/i3"),
            new Achivment("ingridientBuy", "Купить 10 ингридиентов", 10, 10, false, ""),
            new Achivment("ingridientBuy", "Купить 100 ингридиентов", 100, 50, false, ""),
            new Achivment("ingridientBuy", "Купить 500 ингридиентов", 500, 100, false, ""),
            new Achivment("ingridientBuy", "Купить 1000 ингридиентов", 1000, 200, false, "")
        };
    }
}
