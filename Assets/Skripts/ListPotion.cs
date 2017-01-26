using UnityEngine;
using System.Collections;

public class ListPotion : MonoBehaviour {
    //Клас содержит масив всех зелий
    Potion[] masPotion;

	// Use this for initialization
	void Start () {
        InitMasPotion();
    }
    //инициализация массива зелий
    void InitMasPotion()
    {
        masPotion = new Potion[] {
            new Potion(1,10,"Вода", "path")
        };
    }


}
