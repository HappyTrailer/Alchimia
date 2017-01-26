using UnityEngine;
using System.Collections;

public class Potion  {

    int id;  //Индентификатор 
    int price; //Цена

    string namePotion; //Название зелья
    string spritePath; //Путь к спрайту
    //Параметризированый конструктор для инициализации полей класа
    public Potion(
                  int id,
                  int price,
                  string namePotion,
                  string spritePath
                  )
    {
        this.id = id;
        this.price = price;
        this.namePotion = namePotion;
        this.spritePath = spritePath;
    }
}
