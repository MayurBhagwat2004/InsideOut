using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectiblesManager : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI ScoreText;
    internal static CollectiblesManager instance;
    internal int AppleCount;

    void Start()
    {
        if (instance==null) 
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    void Update()
    {
        IncreaseScore();
    }

    private void IncreaseScore() 
    {
        ScoreText.text = AppleCount.ToString();
    }
}
