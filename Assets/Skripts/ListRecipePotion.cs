using UnityEngine;
using System.Collections;

public class ListRecipePotion : MonoBehaviour {
    //Класс содержит массив всех рецептов

    RecipePotion[] masRecPotion;
	// Use this for initialization
	void Start () {
        InitMasRecPotion();

    }
    //Инициализация массива рецептов
    void InitMasRecPotion()
    {
        masRecPotion = new RecipePotion[] {
            new RecipePotion(1, 1, 10, "Рецепт ртуть", new int[] {1, 1, 1})
        };
    }
}
