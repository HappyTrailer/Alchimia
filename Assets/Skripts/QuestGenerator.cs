using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour
{

    int count = 0; //временная переменная для вызова генерации квестов пределенное количество раз

    int timeChance = 10;       // шанс появления тамерв в заданиях в процентах

    List<Quest> randQuestList; // лист для хранения рандомно генерируемых заданий

    int currentGarade = 4; // сделать получение текущего грейда с фала информации об игроке!!!!!!!!1

    void Start()
    {
        randQuestList = new List<Quest>();
    }
    void Update()
    {
        if (count < 1)
        {
            GenQuests();
            count++;
        }
    }
    void GenQuests()
    {
        //Ограничение на рандомный рецепт от количества открытых ингредиентов
        for (int j = 1; j < currentGarade; j++)
            RandFirstTypeQuest(RandCountQuest(80, 4), j); // генерация заданий первого типа

        //RandSecondTypeQuest(RandCountQuest(50, 3)); // генерация заданий второго типа 

        //RandThirdTypeQuest(RandCountQuest(15, 2)); // генерация заданий третьего типа
        Debug.Log(randQuestList.Count);

        for (int i = 0; i < randQuestList.Count; i++)
        {
            Debug.Log(randQuestList[i].nameQuest + " id = " + randQuestList[i].masPotion[0, 0]);
        }
        Debug.Log("---------------------------");

    }


    void RandFirstTypeQuest(int countQuest, int grade)//Метод для создания заданий первого типа(с одним зельем) и добавление их в общий список
    {

        //сделать рсчет дополнительной прибыли за задание
        //прибыль высчитывается у процентах от всей суммы зелий в зависимости от сложности задания(времени и количества)


        List<int> list = TakeFreeReceptPotion(grade); //получение всех открытых рецептов
        for (int i = 0; i < countQuest; i++)
        {
            int r = Random.Range(0, list.Count); //получение рандомного рецепта из списка доступных
            int countRepit = Random.Range(1, 3); //количество повторений
            if (randQuestList.Count == 0 || list[r] != randQuestList[randQuestList.Count - 1].masPotion[0, 0])
            {
                Quest q = new Quest("garde " + ListRecipePotion.masRecPotion[list[r]] + " first type №" + i.ToString(), 1 * i, RandTimeLimit(), new int[1, 3] { { list[r], countRepit, 0 } });//создание отдельного квеста

                randQuestList.Add(q); //Добавление квеста в список доступных
                timeChance += 10; //увеличение шанса на появление временного ограничения     
            }
        }

        timeChance = 10;
    }


    void RandSecondTypeQuest(int countQuest)//Метод для создания заданий второго типа(с несколькими зельями) и добавление их в общий список
    { }


    void RandThirdTypeQuest(int countQuest)//Метод для создания заданий третьего типа(с рандомным рецептом) и добавление их в общий список
    { }

    List<int> TakeFreeReceptPotion(int grade) //получение выборки доступных рецептов определенного уровня
    {
        List<int> l = new List<int>();
        foreach (RecipePotion r in ListRecipePotion.masRecPotion)
        {
            if (r.Grade == grade)
            {
                l.Add(r.Id);
            }
        }
        return l;
    }
    int RandCountQuest(int x /*Шанс появления задания*/, int count /*количество заданий */) //метод для определения сколько заданий будет создано
    {
        int c = 0; // для подсчета количества итераций прошедших шансовый отбор
        timeChance = 10;

        for (int i = 0; i < count; i++)
            if (Random.Range(1, 100) < x)
                c++;

        return c; //сколько заданий будет создано 
    }

    bool RandTimeLimit() // метод для шансового создания временного лимита к заданиям
    {
        if (Random.Range(1, 100) > timeChance)
            return false;
        else
            return true;
    }
}
