using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using static ObjData;

public class JsonSaveLoadSystem : MonoBehaviour
{
    private int _backgroundNum;
    private float _timerCount;
    private int _playerLifePoint;
    private Vector3 _playerStartPos;
    private int _mapScaleNum;
    public List<int> brickListInfo;

    List<CreateObjectInfo> _createObjectInfoList;


    public void SaveToJson()
    {
        ObjData data = new ObjData();
        data.backgroundNum = _backgroundNum;
        data.timerCount = _timerCount;
        data.playerLifePoint = _playerLifePoint;
        data.playerStartPos = _playerStartPos;
        data.mapScaleNum = _mapScaleNum;

        data.createObjectInfoList = _createObjectInfoList;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/Resources/Levels/ObjInfo.json", json);
    }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/Resources/Levels/ObjInfo.json");
        ObjData data = JsonUtility.FromJson<ObjData>(json);

        _backgroundNum = data.backgroundNum;
        _timerCount = data.timerCount;
        _playerLifePoint = data.playerLifePoint;
        _playerStartPos = data.playerStartPos;
        _mapScaleNum = data.mapScaleNum;

        _createObjectInfoList = data.createObjectInfoList;
    }
}
