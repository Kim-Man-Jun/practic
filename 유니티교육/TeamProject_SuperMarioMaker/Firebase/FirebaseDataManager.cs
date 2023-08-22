using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Storage;
using UnityEngine.UI;
using System.IO;
using Firebase.Extensions;
using System.Threading.Tasks;
using UnityEditor.VersionControl;

public class FirebaseDataManager : MonoBehaviour
{
    FirebaseStorage storage;
    StorageReference storageReference;

    public Text QuitQutNum;

    //버튼 액션 생성
    public void CallStorage()
    {
        //파일 경로
        string path = Application.dataPath + "/Resources/Levels/Level 1.asset";
        //storage 디폴트 인스턴스 설정
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReferenceFromUrl("gs://json-practice-fb002.appspot.com");
        byte[] bytes = File.ReadAllBytes(path);
        StorageReference uploadRef = storageReference.Child("uploads/Level 1.asset");
        QuitQutNum.text = "저장중";
        uploadRef.PutBytesAsync(bytes).ContinueWithOnMainThread((task) =>
        {
            if(task.IsFaulted || task.IsCanceled)
            {
                Debug.Log(task.Exception.ToString());
                QuitQutNum.text = "실패";
            }
            else
            {
                Debug.Log("성공");
                QuitQutNum.text = "성공";
            }
        });

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
