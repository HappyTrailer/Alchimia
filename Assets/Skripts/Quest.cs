using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Класс опичывает задание
public class Quest : MonoBehaviour {

    string name; //название

    int money;   //награда
    int timeLimit; //ограничение по времени
    //int countRepeat; //количество повторений
   // int currentRepeat; // текущее повторение

    int[,] masPotion; //масив для записи - id зелья | количество повторов | выполнено повторов
    
    public Quest(string name,
                int money, 
                int timeLimit, 
                //int countRepeat,
                //int currentRepeat,
                int[,] masPotion)
    {
        this.name = name;

        this.money = money;
        this.timeLimit = timeLimit;
        //this.countRepeat = countRepeat;
        //this.currentRepeat = currentRepeat;

        this.masPotion = masPotion;
    }

}
