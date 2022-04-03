using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text txtScore = null;
    [SerializeField] int increaseScore = 10;
    int currentScore = 0;

    [SerializeField] float[] weight = null;

    Animator myAnim;
    string animScoreUp = "ScoreUp";

    void Start()
    {
        myAnim = GetComponent<Animator>();
        currentScore = 0;
        txtScore.text = "0";        
    }

    public void IncreaseScore(int p_JudgementState)
    {
        int t_increaesScore = increaseScore;

        //����ġ ���
        t_increaesScore = (int)(t_increaesScore * weight[p_JudgementState]);

        currentScore += t_increaesScore;
        txtScore.text = string.Format("{0:#,##0}", currentScore);

        myAnim.SetTrigger(animScoreUp);
    }
}
