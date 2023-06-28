using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text score;
    [SerializeField]
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        //게임상 score UI Text 게임오브젝트 찾아서 컴포넌트 Text 가져오기
        this.score = GameObject.Find("Score").GetComponent<Text>();
        count = 0;
    }


    public void IncScore()
    {
        count++;
        //정수를 문자열로 바꿔서 넣어주기
        score.text = count.ToString();

    }
    // Update is called once per frame
    void Update()
    {

    }
    
}
