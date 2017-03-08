using UnityEngine;
using System.Collections;

public class ListIngredients : MonoBehaviour {
    //В этом классе содержится масив 
    //всех ингредиентов в игре

    // для добавления ингредиента в игру
    //добавить его в метод IngredientMasStart

    public static Ingredient[] masIngredient; //масив всех ингредиентов

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
            new Ingredient(0, 150, 150, 150, 1, 1, 0.08f, "Соль", "Sprite/Ing/Salt", 10.0f, true),
            new Ingredient(1, 0, 10, 10, 1, 1, 0.2f, "Лаванда", "Sprite/Ing/Lavanda", 10.0f, true),
            new Ingredient(2, 0, 10, 5, 1, 1, 0.08f, "Подорожник", "Sprite/Ing/Podorojnik", 10.0f, true),

            new Ingredient(3, 0, 10, 5, 2, 2, 0.07f, "Орех", "Sprite/Ing/Oreh", 10.0f, false),
            new Ingredient(4, 0, 10, 5, 2, 2, 0.07f, "Поганки", "Sprite/Ing/Poganki", 10.0f, false),
            new Ingredient(5, 0, 10, 5, 2, 2, 0.07f, "Ежевика", "Sprite/Ing/Ejevika", 10.0f, false),

            new Ingredient(6, 0, 10, 5, 5, 3, 0.06f, "Хмель", "Sprite/Ing/Hmel", 10.0f, false),
            new Ingredient(7, 0, 10, 5, 5, 3, 0.06f, "Кропива", "Sprite/Ing/Kropiva", 10.0f, false),
            new Ingredient(8, 0, 10, 5, 5, 3, 0.06f, "Бузина", "Sprite/Ing/Byzina", 10.0f, false),
                
            new Ingredient(9, 0, 10, 5, 10, 4, 0.05f, "Малахит", "Sprite/Ing/Malahit", 10.0f, false),
            new Ingredient(10, 0, 10, 5, 10, 4, 0.05f, "Золото", "Sprite/Ing/Gold", 10.0f, false),
        };
    }

}
