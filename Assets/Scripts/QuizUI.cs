using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuizUI : MonoBehaviour
{
    private int quizScore = 0;
    private int Round = 1;
    public int QuizeCount;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = transform.Find("QuizImage").gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // 만약 정답이라면 스코어 ++ 오답이라면 무시
    }

    public void PlusScore()
    {
        ++quizScore;
    }
    
}
