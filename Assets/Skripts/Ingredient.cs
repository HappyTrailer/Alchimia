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
    float percent; //процент удачного исследования

    string nameIngr;   //Название
    string spritePath; //Путь к спрайту

    bool opened; // Флаг открытости закрытости

    //Параметризированый конструктор
    public Ingredient(int id,
        int R, int G, int B,
        int price,
        int grade,
        float percent,
        string nameIngr,
        string spritePath,
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
        this.opened = opened;
    }

    public string Sprite
    {
        get { return spritePath; }
    }

    public string Name
    {
        get { return nameIngr; }
    }
    public int Id
    {
        get { return id; }
    }
    public int Red
    {
        get { return R; }
    }
    public int Green
    {
        get { return G; }
    }
    public int Blue
    {
        get { return B; }
    }
    public int Price
    {
        get { return price; }
    }
    public int Grade
    {
        get { return grade; }
    }

    public bool Opened
    {
        get { return opened; }
        set { opened = value; }
    }

    public float Percent
    {
        get { return percent; }
        set { percent = value; }
    }
}
