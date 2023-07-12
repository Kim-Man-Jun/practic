using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame5
{
    public class Block
    {
        BlockData[] tBlock = new BlockData[50];     //블록이 여러개라는 뜻

        public Block()
        {
            for (int i = 0; i < tBlock.Length; i++)
            {
                tBlock[i] = new BlockData();
                tBlock[i].nLife = 0;
                tBlock[i].nX = 0;
                tBlock[i].nY = 0;
            }
        }

        //Search 함수 : 주어진 좌표가 현재 설정된 블록 배열 중에 중복된 것이 있는지를 체크
        //현재 최대 블록 50개까지 설정 가능
        //매번 50개의 블럭을 전부 검색할 필요없이 스테이지마다 할당된 블록 안에서만 검색
        //search함수는 첫번째 인자의 nEnd 변수는 블록의 범위가 된다.

        public int Search(int nEnd, int nX, int nY)
        {
            for (int i = 0; i < nEnd; i++)
            {
                if (tBlock[i].nY == nY)         //y좌표가 같고
                {
                    if (tBlock[i].nX == nX || (tBlock[i].nX + 1) == nX)
                    {
                        return 1;               //x좌표까지 같으면 1을 반환
                    }
                }
            }
            return 0;                           //아닐 경우 0을 반환
        }

        public void SetBlock(int nBlockCount)
        {
            int nX, nY;

            Random r = new Random();

            for (int i = 0; i < nBlockCount; i++)
            {
                tBlock[i].nLife = 1;

                while (true)
                {
                    nX = r.Next(2, 66);
                    nY = r.Next(2, 16);

                    if (Search(i, nX, nY) == 0)
                    {
                        //중복이 아님
                        tBlock[i].nX = nX;
                        tBlock[i].nY = nY;
                        break;              //블럭 한개 만들고 for문 탈출
                    }
                }
            }
        }

        public void Initialize()
        {
            SetBlock(20);
        }
        public void Progress()
        {

        }

        public void Render()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(tBlock[i].nX, tBlock[i].nY);
                Console.Write("■");
            }
        }
        public void Release()
        {

        }
    }
}
