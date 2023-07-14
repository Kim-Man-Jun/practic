using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject;

namespace _07._14_TeamProject
{
    public class Money
    { //싱글톤 돈 인스턴스화 어디서든 불러서 사용가능 // 점수도 이걸로?

        private static Money staticmoney;
        
        public static Money Instance() 
        { 
            if(staticmoney == null) 
            {
               staticmoney = new Money();
            }
            return staticmoney;
        }
        public int pMoney;
        public void SetMoney(int newMoney) { pMoney = newMoney; }  //돈 저장 
        public void AddMoney(int newMoney) { pMoney += newMoney; SetMoney(pMoney); } //돈 +
        public void SubMoney(int newMoney) { pMoney -= newMoney; SetMoney(pMoney); } // 돈 - 
        public int GetMoney() // 돈 객체 가져오기 
        {
            return pMoney;
        }
    }
}
