using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour {

    int count = 0;

    int timeChance = 10;

    List<Quest> randQuestList;
    void Start()
    {
        randQuestList = new List<Quest>();
    }
    void Update()
    {
        if (count < 3)
        {
           // randQuestList = new List<Quest>();
            GenQuests(1);
            count++;
        }
    }
    void GenQuests(int lvl)
    {
        //проверка на наличие достаточного количества рецептов зелий в зависимости от количества заданий

        //Ограничение на рандомный рецепт от количества открытых ингредиентов

        //int countFirstTypeQuest = RandCountQuest(80,4);
        //int countSecondTypeQuest = RandCountQuest(50, 3);
        //int countThreeTypeQuest = RandCountQuest(15, 2);

        RandFirstTypeQuest(RandCountQuest(80, 4));

        //RandFirstTypeQuest(RandCountQuest(50, 3));

        //RandFirstTypeQuest(RandCountQuest(15, 2));
        Debug.Log(randQuestList.Count);
        //Debug.Log(randQuestList[0].nameQuest.ToString());
        //if (randQuestList[0] != null)
            for(int i = 0; i < randQuestList.Count; i++ )
            {
       
                Debug.Log(randQuestList[i].nameQuest + " name");
            }
        Debug.Log("---------------------------");

    }
    void RandFirstTypeQuest(int countQuest)
    {
        for (int i = 0; i < countQuest; i++)
        {
            Quest q = new Quest(i.ToString(), 1 * i, RandTimeLimit(), new int[,] { { 1,1} });
            timeChance += 10;
            randQuestList.Add(q);
        }
        timeChance = 10;
    }
    int RandCountQuest(int x,int count)
    {
        int c = 0;
        for (int i = 0; i < count; i++)
        {
            int r = Random.Range(1, 100);

            if (r < x)
            {
                c++;
            }
        }
        timeChance = 10;
        return c;
    }

    bool RandTimeLimit()
    {
        if (Random.Range(1, 100) > timeChance)
            return false;
        else return true;
    }
}
