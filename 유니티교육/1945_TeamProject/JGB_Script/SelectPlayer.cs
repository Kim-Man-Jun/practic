using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour
{
    public GameObject main; //메인화면 이미지
    public GameObject SPanel; //1번 캐릭 이미지
    public GameObject s1; //1번 캐릭 이미지
    public GameObject s2; // 이하 동문
    public GameObject s3;
    public GameObject s4;
    public GameObject clear1;
    public GameObject clear2;
    public GameObject clear3;
    public GameObject clear4;
    public int SelectNum = 0; //캐릭 선택 번호 0 > 1번 따라서 3 > 4번
    bool isSound = true;
    bool isSel;


    void Start()
    {
        Time.timeScale = 1f;
    
    }
    private void Awake()
    {
        SPanel.SetActive(false);
        Screen.SetResolution(1920, 1080, true);
        isSel = false;
    }
    // Update is called once per frame
    void Update()
    {


        if (TotalGm.instance.isMain == true)
        { //한번만 실행되게하기위함
            if (isSound == true)
            {
                adm.instance.PlaySound2();
                isSound = false;
            }
            if (Input.anyKeyDown) //아무키나 누르면
            {
                SPanel.SetActive(true);
                main.SetActive(false);
                TotalGm.instance.isMain = false;
                adm.instance.StopPlay();
            }
        }
        if (TotalGm.instance.isMain == false)
        {

            SPanel.SetActive(true);
        }


        if (SelectNum == 0)  //0이면 1번 캐릭실행
        {
            if (TotalGm.instance.isMain == false)  //
            {

                s1p();

            }

        }
        if (SelectNum == 1)
        {
            s2p();
        }
        if (SelectNum == 2)
        {
            s3p();
        }
        if (SelectNum == 3)
        {
            s4p();
        }
        Select();
        Init();


        if (TotalGm.instance.isClear1 == true)
        {

            clear1.SetActive(true);
        }
        if (TotalGm.instance.isClear2 == true)
        {

            clear2.SetActive(true);
        }

        if (TotalGm.instance.isClear3 == true)
        {

            clear3.SetActive(true);
        }
        if (TotalGm.instance.isClear4 == true)
        {

            clear4.SetActive(true);
        }



    }
    void Init()
    {
        if (SelectNum > 3)
        {
            SelectNum = 0;
        }
        if (SelectNum < 0)
        {
            SelectNum = 3;
        }
    }
    void s1p()
    {
        s1.SetActive(true);
        s4.SetActive(false);
        s2.SetActive(false);
    }
    void s2p()
    {
        s2.SetActive(true);
        s3.SetActive(false);
        s1.SetActive(false);
    }
    void s3p()
    {
        s3.SetActive(true);
        s4.SetActive(false);
        s2.SetActive(false);
    }
    void s4p()
    {
        s4.SetActive(true);
        s1.SetActive(false);
        s3.SetActive(false);
    }
     void SceneChange() //SelectNum에따른 씬전환 
    {



        if (SelectNum == 0)
        {

            TotalGm.instance.playingPlayer = "player1";
            SceneManager.LoadScene("Wonjae");
        }
        if (SelectNum == 1)
        {


            TotalGm.instance.playingPlayer = "player2";
            SceneManager.LoadScene("KMJ_Stage");

            if (TotalGm.instance.isClear2 == false)
            {
                TotalGm.instance.playingPlayer = "player2";
                SceneManager.LoadScene("KMJ_Stage");
            }

        }
        if (SelectNum == 2)
        {
            if (TotalGm.instance.isClear3 == false)
            {
                TotalGm.instance.playingPlayer = "player3";
                SceneManager.LoadScene("LHS_Scene");
            }
        }
        if (SelectNum == 3)
        {
            if (TotalGm.instance.isClear4 == false)
            {

                TotalGm.instance.playingPlayer = "player4";
                SceneManager.LoadScene("102_Scene");
            }
        }
    }
    void Select()
    {
        if (TotalGm.instance.isMain == false)
        {
            if (isSel == false)
            {

                if (Input.GetKeyDown(KeyCode.DownArrow)) //아래키 누르면 내려감

                {
                    SelectNum += 1;
                    adm.instance.PlaySound3();
                }
                if (Input.GetKeyDown(KeyCode.UpArrow)) //위키 누르면 올라감
                {
                    SelectNum -= 1;

                    adm.instance.PlaySound3();
                }

            }
            if (SelectNum == 0 && TotalGm.instance.isClear1 == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    adm.instance.PlaySound();
                    Invoke("SceneChange", 1f);
                    isSel = true;
                }
            }
            if (SelectNum == 1 && TotalGm.instance.isClear2 == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    adm.instance.PlaySound();
                    
                    Invoke("SceneChange", 1f);
                    isSel = true;
                }
            }
            if (SelectNum == 2 && TotalGm.instance.isClear3 == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    adm.instance.PlaySound();
                    Invoke("SceneChange", 1f);
                    isSel = true;
                }
            }
            if (SelectNum == 3 && TotalGm.instance.isClear4 == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    adm.instance.PlaySound();
                    Invoke("SceneChange", 1f);
                    isSel = true;
                }
            }
        }


        
    }
 }

