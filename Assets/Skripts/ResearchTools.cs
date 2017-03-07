using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResearchTools : MonoBehaviour {
    //в классе информация о исследовательских инструментах
    // и методы для просчета вероятностей открытия рецептов


    //Ступка-Дистилятор.
    // реализовать покупку ступки нового грейда
    // по завершении процесса исследавния выдать результат в виде всплывающего сообщения на игровом екране
    
    int mortar1 = 1;
    int distiller = 1;
    public static int maxCountIngridientInMortar = 10;
    public static ItemsInInventary currentIngridient;
    public static ItemsInInventary currentIngridientSecond;
    public static string tool;

    void Start() 
    {
        currentIngridient = null;
        currentIngridientSecond = null;
    }

    public void StartResearch()
    {
        if (tool == "Mortar" || tool == "Distiller")
        {
            RecipeIngredint[] buff = new RecipeIngredint[ListRecipeIngredint.masRecIngr.Length];
            int k = 0;
            for (int i = 0; i < buff.Length; i++)
            {
                if (currentIngridient.Id == ListRecipeIngredint.masRecIngr[i].IdFirstIngredient ||
                    currentIngridient.Id == ListRecipeIngredint.masRecIngr[i].IdSecondInredient)
                {
                    if (ListIngredients.masIngredient[ListRecipeIngredint.masRecIngr[i].IdFirstIngredient].Opened &&
                        ListIngredients.masIngredient[ListRecipeIngredint.masRecIngr[i].IdSecondInredient].Opened)
                    {
                        buff[k] = ListRecipeIngredint.masRecIngr[i];
                        k++;
                    }
                }
            }
            float chance = currentIngridient.Count * ListIngredients.masIngredient[currentIngridient.Id].Percent;
            float rand = Random.Range(0, 1001);
            float number = 1000 * chance;
            if (rand <= number)
            {
                if (tool == "Mortar")
                    OpenHelpMoratr(buff, k);
                else if (tool == "Distiller")
                    OpenHelpDistiller(buff, k);
            }
        }
        else if (tool == "Blender")
        {
            if (ReceptIngridientPanel.listHRI == null)
                ReceptIngridientPanel.listHRI = new List<HelpReceptIngridient>();
            foreach(RecipeIngredint recept in ListRecipeIngredint.masRecIngr)
            {
                if (!ListIngredients.masIngredient[recept.IdResultIngredient].Opened)
                {
                    if ((recept.IdFirstIngredient == currentIngridient.Id || recept.IdFirstIngredient == currentIngridientSecond.Id)
                        && (recept.IdSecondInredient == currentIngridient.Id || recept.IdSecondInredient == currentIngridient.Id))
                    {
                        ListIngredients.masIngredient[recept.IdResultIngredient].Opened = true;
                        ListAchivments.ingridientOpenCount++;
                        ListAchivments.ChekAchiv();
                        for (int i = 0; i < ReceptIngridientPanel.listHRI.Count; i++)
                        {
                            if (ListRecipeIngredint.masRecIngr[ReceptIngridientPanel.listHRI[i].Recept].IdResultIngredient == recept.IdResultIngredient)
                                ReceptIngridientPanel.listHRI.RemoveAt(i);
                        }
                        bool flag = false;
                        for (int i = 0; i < Inventory.listItem.Count; i++)
                        {
                            if (Inventory.listItem[i].Id == recept.IdResultIngredient)
                            {
                                Inventory.listItem[i].Count++;
                                break;
                            }
                        }
                        if (!flag)
                            Inventory.listItem.Add(new ItemsInInventary(recept.IdResultIngredient, 1));
                        break;
                    }
                }
            }
        }
        currentIngridient = null;
        currentIngridientSecond = null;
    }

    void OpenHelpDistiller(RecipeIngredint[] mass, int k)
    {
        int index = 0;
        bool flag = true;
        if (ReceptIngridientPanel.listHRI == null)
            ReceptIngridientPanel.listHRI = new List<HelpReceptIngridient>();
        if (ReceptIngridientPanel.listHRI.Count != 0)
        {
            for (int i = 0; i < k; i++)
            {
                foreach (HelpReceptIngridient h in ReceptIngridientPanel.listHRI)
                {

                    if (mass[i].Id == h.Recept && (h.B1 || h.G1))
                    {
                        if (h.B1)
                        {
                            h.B1 = false;
                            flag = false;
                        }
                        else if (h.G1)
                        {
                            h.G1 = false;
                            flag = false;
                        }
                        break;
                    }
                    else if (mass[i].Id == h.Recept && !h.B1 && !h.G1)
                    {
                        index++;
                        break;
                    }
                }
            }
            if (flag && mass[index] != null)
                ReceptIngridientPanel.listHRI.Add(new HelpReceptIngridient(mass[index].Id, currentIngridient.Id, true, true, false));
        }
        else if (mass[0] != null)
            ReceptIngridientPanel.listHRI.Add(new HelpReceptIngridient(mass[0].Id, currentIngridient.Id, true, true, false));
    }

    void OpenHelpMoratr(RecipeIngredint[] mass, int k)
    {
        int index = 0;
        bool flag = true;
        if (ReceptIngridientPanel.listHRI == null)
            ReceptIngridientPanel.listHRI = new List<HelpReceptIngridient>();
        if (ReceptIngridientPanel.listHRI.Count != 0)
        {
            for (int i = 0; i < k; i++)
            {
                foreach (HelpReceptIngridient h in ReceptIngridientPanel.listHRI)
                {

                    if (mass[i].Id == h.Recept && (h.R1 || h.G1))
                    {
                        if (h.R1)
                        {
                            h.R1 = false;
                            flag = false;
                        }
                        else if (h.G1)
                        {
                            h.G1 = false;
                            flag = false;
                        }
                        break;
                    }
                    else if (mass[i].Id == h.Recept && !h.R1 && !h.G1)
                    {
                        index++;
                        break;
                    }
                }
            }
            if (flag && mass[index] != null)
                ReceptIngridientPanel.listHRI.Add(new HelpReceptIngridient(mass[index].Id, currentIngridient.Id, false, true, true));
        }
        else if (mass[0] != null)
            ReceptIngridientPanel.listHRI.Add(new HelpReceptIngridient(mass[0].Id, currentIngridient.Id, false, true, true));
    }

    public void CancelResearch()
    {
        bool exist = false;
        foreach (ItemsInInventary item in Inventory.listItem)
        {
            if (item.Id == currentIngridient.Id)
            {
                exist = true;
                item.Count += currentIngridient.Count;
            }
        }
        if(!exist)
        {
            Inventory.listItem.Add(new ItemsInInventary(currentIngridient.Id, currentIngridient.Count));
        }
        currentIngridient = null;
        currentIngridientSecond = null;
    }
    //Смеситель
    /*
     * 1. Добавление ингредиентов для исследования
     *      с отменой отображения в инвентаре уже выбраного или закраской его в серый цвет
     *      и отключением у него кликабельности
     * 2. Проверка наличия рецепта 
     * 3. Успешное смешивание открывает рецепт ингредиента 
     *      проверка нет ли подсказок на этот ингредиент и удаление подсказки
     * 4. При применении уже исследованого рецепта выскакивает сообщение уже ислледовано и ингредиенты не тратятся
     */


    //=============================================================================



    //Ступка 
    /*
     * 1. Лимит по количеству вложенных ингредиентов.
     *      Выбор из инвентаря скрол для передачи количества лимитированый лимитом ступки и количеством игредиента
     * 2. Проценты успешности исследования суммируются по количеству ингредиентов
     *      количество * процент 
     * 3. В случае исследования ингредиента большего грейда процент успешного исследования будет не больше 15%
     * 4. Ступка открыват один из показателей G или В 
     * 5. Исследование проводится раз в 1-2 минуты
     *      реализовать либо как откат либо как прогресс бар проведения исследования
     * 6. Ингредиенты используются и удаляются с инвентаря
     * 7. Заменить список доступных ингредиентов на список подсказок.????????? или вообше убрать
     *      отображать подсказку в виде "Ингреиент     и показатели RGB возможного результата"
     * 
     * Методы 
     * 
     * 1. Добавление ингредиента
     * 2. Отмена
     * 3. Начало исследования и запись результата в список
     * 
     */
    //=============================================================================

    //Дистилятор 
    /*
     * 1. Лимит по количеству вложенных ингредиентов.
     *      Выбор из инвентаря скрол для передачи количества лимитированый лимитом дистилятора и количеством игредиента
     * 2. Проценты успешности исследования суммируются по количеству ингредиентов
     *      количество * процент 
     * 3. В случае исследования ингредиента большего грейда процент успешного исследования будет не больше 15%
     * 4. Дистилятор открыват один из показателей R или В 
     * 5. Исследование проводится раз в 1-2 минуты
     *      реализовать либо как откат либо как прогресс бар проведения исследования
     * 6. Ингредиенты используются и удаляются с инвентаря
     * 7. Заменить список доступных ингредиентов на список подсказок.????????? или вообше убрать
     *      отображать подсказку в виде "Ингреиент     и показатели RGB возможного результата"
     * 
     * Методы 
     * 
     * 1. Добавление ингредиента
     * 2. Отмена
     * 3. Начало исследования и запись результата в список
     * 
     */
    //=============================================================================
}
