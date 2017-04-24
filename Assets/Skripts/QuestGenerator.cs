using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour {

    int count = 0; //временная переменная для вызова генерации квестов пределенное количество раз

    int timeChance = 10;       // шанс появления тамерв в заданиях в процентах

    List<Quest> randQuestList; // лист для хранения рандомно генерируемых заданий
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

        RandFirstTypeQuest(RandCountQuest(80, 4)); // генерация заданий первого типа

        //RandSecondTypeQuest(RandCountQuest(50, 3)); // генерация заданий второго типа 

        //RandThirdTypeQuest(RandCountQuest(15, 2)); // генерация заданий третьего типа
        Debug.Log(randQuestList.Count);
            for(int i = 0; i < randQuestList.Count; i++ )
            {       
                Debug.Log(randQuestList[i].nameQuest + " name");
            }
        Debug.Log("---------------------------");

    }

    
    void RandFirstTypeQuest(int countQuest)//Метод для создания заданий первого типа(с одним зельем) и добавление их в общий список
    {
        for (int i = 0; i < countQuest; i++)
        {
            /*
                тут сделать проверку на доступные рецепты в каждом из доступных уровней и сделать выборку для 
                записи в квест айди
             */

            Quest q = new Quest("first type №"+i.ToString(), 1 * i, RandTimeLimit(), new int[,] { { 1,1} });//создание отдельного квеста
            randQuestList.Add(q); //Добавление квеста в список доступных
            timeChance += 10; //увеличение шанса на появление временного ограничения           
        }
        timeChance = 10;
    }


    void RandSecondTypeQuest(int countQuest)//Метод для создания заданий второго типа(с несколькими зельями) и добавление их в общий список
    { }


    void RandThirdTypeQuest(int countQuest)//Метод для создания заданий третьего типа(с рандомным рецептом) и добавление их в общий список
    { }


    int RandCountQuest(int x /*Шанс появления задания*/,int count /*количество заданий */) //метод для определения сколько заданий будет создано
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
