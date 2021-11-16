using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHighScore : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = $"{GameManager.Instance.bestUsername}:{GameManager.Instance.bestScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
