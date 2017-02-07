using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickOnRecept : MonoBehaviour, IPointerClickHandler
{
    public GameObject container;
    GameObject item;
    public GameObject itemPanel;
    public GameObject nameRecept;
    public GameObject sprite;

    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < itemPanel.transform.childCount; i++)
        {
            Destroy(itemPanel.transform.GetChild(i).gameObject);
            Debug.Log(i);
        }
        int idRecept = System.Convert.ToInt32(this.name);
        sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListRecipePotion.masRecPotion[idRecept].Sprite);
        nameRecept.GetComponent<Text>().text = ListRecipePotion.masRecPotion[idRecept].NameRec;
        foreach (int id in ListRecipePotion.masRecPotion[idRecept].Mass)
        {
            item = Instantiate(container);
            item.transform.parent = itemPanel.transform;
            item.transform.localScale = new Vector3(1, 1, 1);
            item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[id].Sprite);
            item.transform.GetChild(1).GetComponent<Text>().text = ListIngredients.masIngredient[id].Name;
        }
    }
}
