using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjData
{
    public int levelIndex;
    public int backgroundNum;
    public float timerCount;
    public int playerLifePoint;
    public Vector3 playerStartPos;
    public int mapScaleNum;

    public List<CreateObjectInfo> createObjectInfoList;

    [Serializable]
    public class CreateObjectInfo
    {
        public string objectName;
        public Vector3 createPos;
        public int dirInfo; //(위 : 0, 오른 : 1, 왼 : 2, 아래 : 3)
        public Vector3 pipeLinkPos;
        public List<int> brickListInfo;

        public CreateObjectInfo(string _objectName, Vector3 _createPos,
            Vector3 _pipeLinkPos, int _dirInfo = 0, List<int> _brickListInfo = null)
        {
            objectName = _objectName;
            createPos = _createPos;
            pipeLinkPos = _pipeLinkPos;
            dirInfo = _dirInfo;
            brickListInfo = _brickListInfo;
        }
    }
}
