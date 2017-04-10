using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Класс опичывает задание
public class Quest : MonoBehaviour {

    public string nameQuest; //название

    public int money;   //награда
    public bool timeLimit; //ограничение по времени

    public int[,] masPotion; //масив для записи - id зелья | количество повторов | выполнено повторов
    
    public Quest(string name,
                int money, 
                bool timeLimit, 
                int[,] masPotion)
    {
        this.nameQuest = name;

        this.money = money;
        this.timeLimit = timeLimit;

        this.masPotion = masPotion;
    }

}
