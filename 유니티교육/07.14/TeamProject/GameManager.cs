using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject;

namespace _07._14_TeamProject
{
    //현숙.추가
    //플레이어, 적의 정보를 담아서 사용하고 싶다.
    internal class GameManager
    {
        private static GameManager staticGM;

        public static GameManager Instance()
        {
            if (staticGM == null)
            {
                staticGM = new GameManager();
            }
            return staticGM;
        }

        //Player
        PlayerInfo m_player;
        public void SetPlayer(PlayerInfo setInfo) { m_player = setInfo; } //플레이어 정보 저장
        public PlayerInfo GetInfoPlayer() { return m_player; }

        //Enemy
        EnemyInfo m_enemy;
        public void SetEnmey(EnemyInfo setInfo) { m_enemy = setInfo; }
        public EnemyInfo GetInfoEnemy() { return m_enemy; }

        Item m_item;
        public void SetItem(Item setItem) { m_item = setItem; }
        public Item GetItem() { return m_item; }
    }
}
