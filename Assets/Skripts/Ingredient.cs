using UnityEngine;
using System.Collections;

public class Ingredient {
    //Класс содержит описание ингредиента 
    //в дальнейшем используется в списке всех
    //ингредиентов в классе ListIngredients

    int id; //уникальный иендентификатор

    //---------значения RGB (цвет)-------
    int R; 
    int G;
    int B;
    //-----------------------------------
    int price;   // цена 
    int grade;   // градация уровня ингреиента(1-4)
    int percent; //процент удачного исследования

    string nameIngr;   //Название
    string spritePath; //Путь к спрайту

    float time; // время на обработку RGB

    bool opened; // Флаг открытости закрытости

    //Параметризированый конструктор
    public Ingredient(int id,
        int R, int G, int B,
        int price,
        int grade,
        int percent,
        string nameIngr,
        string spritePath,
        float time,
        bool opened)
    {
        this.id = id;
        this.R = R;
        this.G = G;
        this.B = B;
        this.price = price;
        this.grade = grade;
        this.percent = percent;
        this.nameIngr = nameIngr;
        this.spritePath = spritePath;
        this.time = time;
        this.opened = opened;
    }

    public string Sprite
    {
        get { return spritePath; }
    }
}
