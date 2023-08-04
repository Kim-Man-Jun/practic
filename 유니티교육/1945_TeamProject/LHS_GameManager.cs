using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LHS_GameManager : MonoBehaviour
{
    public static LHS_GameManager instance;
    [SerializeField] GameObject score;
    Text scoreText;

    int startNumber = 0;
    int maxNumber = 99999999;
    int currentNumber;

    public int level = 1;
    public int itemNum;

    public int stageCheck = 0;

    public GameObject stageClear;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Start()
    {
        Screen.SetResolution(600, 1920, true);

        scoreText = score.gameObject.GetComponent<Text>();
        currentNumber = startNumber;
        UpdateNumberText();
    }


    void Update()
    {
        if (itemNum == 3)
        {
            level = 2;
        }
    }

    //점수추가용
    public void ScoreAdd(int add)
    {
        //startNumber += add;
        //scoreText.text = startNumber.ToString();
        currentNumber += add;
        UpdateNumberText();
    }

    void UpdateNumberText()
    {
        string formattedNumber = currentNumber.ToString("D8"); //8자리
        scoreText.text = formattedNumber;
    }

    void IncreaseNumber()
    {
        if (currentNumber > maxNumber)
        {
            //최대값을 넘으면
            currentNumber = startNumber;
        }
    }

    public void ScnenChage()
    {
        //캐릭터 선택창 뜨도록 해야함
        SceneManager.LoadScene("StartScene");
        TotalGm.instance.isClear3 = true;
    }

    public void ClearUI()
    {

        Debug.Log("켜져야하는 UI");
        stageClear.gameObject.SetActive(true);
    }
}
