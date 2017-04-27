using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Класс опичывает задание
public class Quest : MonoBehaviour {
    public struct StrQ {
        public int id;
        public int countNow;
        public int done;
        public StrQ(int x1,int x2,int x3)
        {
            id = x1;
            countNow = x2;
            done = x3;
        }
    }
    public string nameQuest; //название

    public int money;   //награда
    public bool timeLimit; //ограничение по времени

    public StrQ[] masPotion; //масив для записи - id зелья | количество повторов | выполнено повторов
    
    public Quest(string name,
                int money, 
                bool timeLimit,
                StrQ[] masPotion
                )
    {
        this.nameQuest = name;

        this.money = money;
        this.timeLimit = timeLimit;

        this.masPotion = masPotion;
    }

}
