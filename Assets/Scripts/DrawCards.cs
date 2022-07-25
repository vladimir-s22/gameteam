using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject Card;
    public GameObject OpponentCard;
    public GameObject PlayerArea;
    public GameObject OpponentArea;
    
    // Start is called before the first frame update
    void Start()
    {
        dealCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dealCards() 
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject playerCard = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(PlayerArea.transform, false);

            GameObject opponentCard = Instantiate(OpponentCard, new Vector3(0, 0, 0), Quaternion.identity);
            opponentCard.transform.SetParent(OpponentArea.transform, false);
        }
    }
}
