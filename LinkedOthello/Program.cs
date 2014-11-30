using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedOthello;

namespace LinkedOthello {
    public class Program {

        public static void Main(string[] args) {
            Program p = new Program();
            p.Start();
        }

        private Othello8 othello = new Othello8();
        private List<Square> putableList;
        private Dictionary<int,Square> putableMap = new Dictionary<int,Square>();
        private SquareColor putColor;
        private SquareColor botColor;
        private BaseOthelloBot bot;

        public void Start() {
            putColor = ReadPutColor();
            botColor = putColor.TurnColor();
            bot = new BaseOthelloBot(othello,botColor);
            SquareColor turnColor = SquareColor.Black;
            while(othello.PutableCount() > 0) {
                if(othello.BlackCount() == 0 || othello.WhiteCount() == 0) {
                    break;
                }
                putableList = othello.GetColorableSquare(turnColor);
                if(putableList.Count == 0) {
                    putableList = othello.GetColorableSquare(turnColor.TurnColor());
                    if(putableList.Count == 0) {
                        break;
                    }
                    Pass(turnColor);
                    turnColor = turnColor.TurnColor();
                }
                if(turnColor == botColor) {
                    putableList.Clear();
                    Write();
                    Write("\n");
                    Square s = bot.PutNextSquare();
                    othello.PutColor(s.X,s.Y,botColor);
                    Write();
                } else {
                    Write();
                    Put();
                }
                turnColor = turnColor.TurnColor();
                Write("\n");
            }
            putableList.Clear();
            Write();
            Write("\n● : " + othello.BlackCount() + " ○ : " + othello.WhiteCount() + "\n");
        }

        private SquareColor ReadPutColor() {
            Write("○か●を入力してください\n");
            SquareColor putColor;
            while(true) {
                string r = Console.In.ReadLine();
                if(r == "○" || r == "0") {
                    putColor = SquareColor.White;
                    break;
                } else if(r == "●" || r == "1") {
                    putColor = SquareColor.Black;
                    break;
                }
            }
            return putColor;
        }

        private void Write(string s) {
            Console.Out.Write(s);
        }

        private void Write(SquareColor color) {
            if(color == SquareColor.Black) {
                Write("●");
            } else if(color == SquareColor.White) {
                Write("○");
            }
        }

        private void Write() {
            putableMap.Clear();
            for(int y = 0;y < othello.Size;y++) {
                for(int x = 0;x < othello.Size;x++) {
                    Square s = othello.Square[x,y];
                    if(s.Color != SquareColor.Null) {
                        Write(s.Color);
                    } else {
                        int index = putableList.IndexOf(s);
                        if(index != -1) {
                            if(index > 9) {
                                Write(index.ToString());
                            } else {
                                Write(" " + index);
                            }
                            putableMap.Add(index,putableList[index]);
                        } else {
                            Write("  ");
                        }
                    }
                    if(x < othello.Size - 1) {
                        Write("|");
                    } else {
                        Write("\n");
                    }
                }
            }
        }

        private void Pass(SquareColor turnColor) {
            Write("\n");
            Write(turnColor);
            Write("のパス。\n\n");
        }

        private void Put() {
            string r;
            int index = -1;
            int x = 0,y = 0;
            bool b = false;
            do {
                Write("\n");
                Write(putColor);
                Write("の番です。置くマスの数字を入力してください。\n");

                r = Console.In.ReadLine();
                try {
                    index = int.Parse(r);
                } catch {
                    continue;
                }
                if(index < 0 || putableMap.ContainsKey(index) == false) {
                    continue;
                }
                Square s = putableMap[index];
                x = s.X;
                y = s.Y;
                b = true;
            } while(b == false);
            othello.PutColor(x,y,putColor);
        }

    }
}
