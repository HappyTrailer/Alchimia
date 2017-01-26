using UnityEngine;
using System.Collections;

public class ListIngredients : MonoBehaviour {
    //В этом классе содержится масив 
    //всех ингредиентов в игре

    // для добавления ингредиента в игру
    //добавить его в метод IngredientMasStart

    Ingredient[] masIngredient; //масив всех ингредиентов

    //в методе Start происходит инициализация масива
    //скрипт должен загружатся  при старте игры
    void Start () {
        IngredientMasStart();
    }



    //Инициализация масива
    void IngredientMasStart()
    {
        masIngredient = new Ingredient[]
            {
                new Ingredient(0,10,10,10,5,1,2,"Соль","solt",5.0f,true)
            };
    }

}
