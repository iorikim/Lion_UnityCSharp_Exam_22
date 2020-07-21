using UnityEngine;
using System.Linq;                  
using System.Collections;           
using System.Collections.Generic;   


[ExecuteInEditMode]
public class CardSystem : MonoBehaviour
{

    public List<GameObject> cards = new List<GameObject>();

   
    private string[] type = { "Spades", "Diamond", "Heart", "Club" };
    private void Start()
    {
        GetAllCard();
    }

    
    private void GetAllCard()
    {
        if (cards.Count == 52) return;                  
        
        for (int i = 0; i < type.Length; i++)
        {
            
            for (int j = 1; j < 14; j++)
            {
                string number = j.ToString();           

                switch (j)
                {
                    case 1:
                        number = "A";                   
                        break;
                    case 11:
                        number = "J";                   
                        break;
                    case 12:
                        number = "Q";                   
                        break;
                    case 13:
                        number = "K";                   
                        break;
                }
                
                GameObject card = Resources.Load<GameObject>("PlayingCards_" + number + type[i]);
                
                cards.Add(card);
            }
        }
    }

   
    public void ChooseCardByType(string type)
    {
        DeleteAllChild();               

        
        var temp = cards.Where((x) => x.name.Contains(type));

        
        foreach (var item in temp) Instantiate(item, transform);

        StartCoroutine(SetChildPosition());         
    }

    public void Shuffle()
    {
        DeleteAllChild();
        
        List<GameObject> shuffle = cards.ToArray().ToList();        

        List<GameObject> newCards = new List<GameObject>();         

        for (int i = 0; i < 52; i++)
        {
            int r = Random.Range(0, shuffle.Count);                     

            GameObject temp = shuffle[r];                               
            newCards.Add(temp);                                         
            shuffle.RemoveAt(r);                                        
        }

        foreach (var item in newCards) Instantiate(item, transform);

        StartCoroutine(SetChildPosition());
    }

   
    public void Sort()
    {
        DeleteAllChild();

      
        var sort = from card in cards
                   where card.name.Contains(type[3]) || card.name.Contains(type[2]) || card.name.Contains(type[1]) || card.name.Contains(type[0])
                   select card;

        foreach (var item in sort) Instantiate(item, transform);

        StartCoroutine(SetChildPosition());
    }

    private void DeleteAllChild()
    {
        for (int i = 0; i < transform.childCount; i++) Destroy(transform.GetChild(i).gameObject);
    }

  
    private IEnumerator SetChildPosition()
    {
        yield return new WaitForSeconds(0.1f);              

        for (int i = 0; i < transform.childCount; i++)          
        {
            Transform child = transform.GetChild(i);        
            child.eulerAngles = new Vector3(180, 0, 0);     
            child.localScale = Vector3.one * 20;            

            
            float x = i % 13;
           
            int y = i / 13;
            child.position = new Vector3((x - 6) * 1.3f, 4 - y * 2, 0);

            yield return null;
        }
    }
}
