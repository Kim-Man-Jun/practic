using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Buffer;
using System.Threading;

namespace Sokoban
{
    public class Sokoban
    {
        int moveCount = 0;
        int stageNumber = 0;
        int goalCount = 0;

        enum Direction { Right, Left, Up, Down };
        Player2 player = new Player2('▽', 0, 0);
        Field2 field = new Field2();
        ConsoleBuffer gameBoard = new ConsoleBuffer(60, 40);    //게임 화면 크기
        SokobanUI UI = new SokobanUI();

        void SetGame(char[,] inBuf)
        {
            switch (stageNumber)
            {
                case 0:
                    player.SetLocation(4, 3);
                    break;
                case 1:
                    player.SetLocation(2, 3);
                    break;
            }
            gameBoard.ClearBuffer();
            field.SetMap(field.stages[stageNumber], inBuf);
            goalCount = field.GetGoalCount(field.stages[stageNumber]);
        }

        private int SetVertical(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return -1;
                case Direction.Down:
                    return 1;
                default:
                    return 0;
            }
        }
        private int SetHorizontal(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    return 1;
                case Direction.Left:
                    return -1;
                default:
                    return 0;
            }
        }

        //박스를 밀기 위한 메서드
        //플레이어 다음 위치에 박스가 있을 경우 박스 다음 위치에 벽, 박스, 골박스가 없으면 아래가 실행.
        //박스 앞에 골이 있을 경우 박스가 있던 자리는 길로 채우고 다음 자리에는 골박스로 채움
        //아니면 박스가 있던 자리는 길로 채우고 다음 자리에는 박스로 채움

        void PushBox(int inX, int inY, Direction direction)
        {
            int tempX = SetHorizontal(direction);
            int tempY = SetVertical(direction);

            if (field.IsBox(gameBoard.Buffer, inX + tempX, inY + tempY))
            {
                if (!field.IsWall(gameBoard.Buffer, inX + tempX * 2, inY + tempY * 2)
                    && !field.IsBox(gameBoard.Buffer, inX + tempX * 2, inY + tempY * 2) &&
                    !field.IsGoalBox(gameBoard.Buffer, inX + tempX * 2, inY + tempY * 2))
                {
                    if (field.IsGoal(gameBoard.Buffer, inX + tempX * 2, inY + tempY * 2))
                    {
                        gameBoard.Draw(field.Road, inX + tempX, inY + tempY);
                        gameBoard.Draw(field.Goalbox, inX + tempX * 2, inY + tempY * 2);
                    }
                    else
                    {
                        gameBoard.Draw(field.Road, inX + tempX, inY + tempY);
                        gameBoard.Draw(field.Box, inX + tempX * 2, inY + tempY * 2);

                    }
                }
            }
        }

        void PushiGoalBox(int inX, int inY, Direction direction)
        {
            int tempX = SetHorizontal(direction);
            int tempY = SetVertical(direction);

            if (field.IsGoalBox(gameBoard.Buffer, inX + tempX, inY + tempY))
            {
                if (!field.IsWall(gameBoard.Buffer, inX + tempX * 2, inY + tempY * 2)
                    && !field.IsBox(gameBoard.Buffer, inX + tempX * 2, inY + tempY * 2) &&
                    !field.IsGoalBox(gameBoard.Buffer, inX + tempX * 2, inY + tempY * 2))
                {
                    if (field.IsGoal(gameBoard.Buffer, inX + tempX * 2, inY + tempY * 2))
                    {
                        gameBoard.Draw(field.Road, inX + tempX, inY + tempY);
                        gameBoard.Draw(field.Goalbox, inX + tempX * 2, inY + tempY * 2);
                    }
                    else
                    {
                        gameBoard.Draw(field.Road, inX + tempX, inY + tempY);
                        gameBoard.Draw(field.Box, inX + tempX * 2, inY + tempY * 2);

                    }
                }
            }
        }

        void Movement(ConsoleKeyInfo inKey, int inX, int inY, Direction direction)
        {
            int tempX = SetHorizontal(direction);
            int tempY = SetVertical(direction);

            if (!field.IsWall(gameBoard.Buffer, inX + tempX, inY + tempY))
            {
                if (field.IsBox(gameBoard.Buffer, inX + tempX, inY + tempY) ||
                    field.IsGoalBox(gameBoard.Buffer, inX + tempX, inY + tempY))
                {
                    if (field.IsWall(gameBoard.Buffer, inX + tempX * 2, inY + tempY * 2) ||
                        field.IsBox(gameBoard.Buffer, inX + tempX * 2, inY + tempY * 2) ||
                        field.IsGoalBox(gameBoard.Buffer, inX + tempX * 2, inY + tempY * 2))
                    {
                        return;
                    }
                }

                moveCount++;
                gameBoard.Draw(field.Road, inX, inY);
                player.Move(inKey);
                OnGoal(inX, inY);
            }
        }

        private void OnGoal(int inX, int inY)
        {
            if (field.stages[stageNumber][inY, inX] == 3)
            {
                gameBoard.Draw(field.Goal, inX, inY);
            }
        }

        void Interaction(ConsoleKeyInfo inKey, int inX, int inY, Direction direction)
        {
            PushBox(player.X, player.Y, direction);
            PushiGoalBox(player.X, player.Y, direction);
            Movement(inKey, player.X, player.Y, direction);
        }

        void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        {
                            Interaction(key, player.X, player.Y, Direction.Right);
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            Interaction(key, player.X, player.Y, Direction.Left);
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            Interaction(key, player.X, player.Y, Direction.Up);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            Interaction(key, player.X, player.Y, Direction.Down);
                            break;
                        }
                    case ConsoleKey.R:
                        {
                            SetGame(gameBoard.Buffer);
                            moveCount = 0;
                            Console.Clear();
                            break;
                        }

                    case ConsoleKey.Q:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }

            }
        }

        void PlayerUpdate()
        {
            gameBoard.Draw(player.Images, player.X, player.Y);
        }

        bool IsClear(char[,] inStage, int inStageNum, int inCount)
        {
            int temp = 0;

            for (int y = 0; y < field.stages[inStageNum].GetLength(0); y++)
            {
                for (int x = 0; x < field.stages[inStageNum].GetLength(1); x++)
                {
                    if (inStage[y, x] == field.Goalbox)
                    {
                        temp++;
                    }
                }
            }
            return inCount == temp ? true : false;
        }

        void NextStage()
        {
            if (IsClear(gameBoard.Buffer, stageNumber, goalCount) == true)
            {
                stageNumber++;
                moveCount = 0;
                Console.ForegroundColor = ConsoleColor.Cyan;
                UI.DrawText(gameBoard.Buffer, "Clear!!", 21, 12);
                gameBoard.Show();
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.Clear();
                if (field.stages.Count == stageNumber)
                {
                    Environment.Exit(0);
                }
                SetGame(gameBoard.Buffer);
            }
        }

        void GameUI()
        {
            //추가예정
            UI.WriteUI(gameBoard.Buffer);
            UI.DrawText(gameBoard.Buffer, (stageNumber + 1).ToString() + " / " +
                field.stages.Count.ToString(), 11, 12);
            UI.DrawText(gameBoard.Buffer, moveCount.ToString(), 11, 13);
            UI.DrawText(gameBoard.Buffer, player.Images, 11, 15);
            UI.DrawText(gameBoard.Buffer, field.Wall, 11, 16);
            UI.DrawText(gameBoard.Buffer, field.Box, 11, 17);
            UI.DrawText(gameBoard.Buffer, field.Goal, 11, 18);
            UI.DrawText(gameBoard.Buffer, field.Goalbox, 11, 19);
            UI.DrawText(gameBoard.Buffer, 'R', 28, 15);
            UI.DrawText(gameBoard.Buffer, 'Q', 28, 16);
        }

        public void Run()
        {
            SetGame(gameBoard.Buffer);

            while (true)
            {
                NextStage();
                GameUI();
                Input();
                PlayerUpdate();
                gameBoard.Show();
            }
        }
    }
}
