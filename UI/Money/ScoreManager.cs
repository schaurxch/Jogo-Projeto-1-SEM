using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text moneyScore;

    public static int moneyCount;





    // Start is called before the first frame update
    void Start()
    {
        moneyScore.text = "Dinheiro: $ 0";
    }

    // Update is called once per frame
    void Update()
    {
        moneyScore.text = "Dinheiro: $" + Mathf.Round(moneyCount); 
    }
}
