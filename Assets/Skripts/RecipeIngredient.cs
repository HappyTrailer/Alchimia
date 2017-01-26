﻿using UnityEngine;
using System.Collections;

public class RecipeIngredint  {
    //Класс содержит описание рецепта ингредиента
    int id; // уникальный индентификатор
    int idFirstIngredient; // первый ингредиент необходимый для созданий
    int idSecondInredient; // второй ингредиент необходимый для созданий
    int idResultIngredient; // созданый ингредиент

    //параметризированый конструктор для инициализации полей
    public RecipeIngredint(
                           int id,
                           int idFirstIngredient,
                           int idSecondInredient,
                           int idResultIngredient
                           )
    {
        this.id = id;
        this.idFirstIngredient = idFirstIngredient;
        this.idSecondInredient = idSecondInredient;
        this.idResultIngredient = idResultIngredient;
    }
}
