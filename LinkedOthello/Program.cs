using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedOthello {
    public class Program {

        public static void Main(string[] args) {
            Program p = new Program();
            p.Start();
        }

        private Othello8 othello = new Othello8();
        private List<Square> putableList;
        private SquareColor putColor = SquareColor.Black;

        public void Start() {
            while(othello.PutableCount() > 0) {
                if(othello.BlackCount() == 0 || othello.WhiteCount() == 0) {
                    break;
                }
                putableList = othello.GetColorableSquare(putColor);
                if(putableList.Count == 0) {
                    if(othello.GetColorableSquare(TurnColor(putColor)).Count == 0) {
                        break;
                    }
                    Pass();
                    continue;
                }
                Write();
                Put();
            }
            putableList.Clear();
            Write();
            Write("\n● : " + othello.BlackCount() + " ○ : " + othello.WhiteCount() + "\n");
        }

        private void Write(string s) {
            Console.Out.Write(s);
        }

        private void Write() {
            for(int y = 0;y <= othello.Size;y++) {
                for(int x = 0;x <= othello.Size;x++) {
                    if(y == 0) {
                        if(x == 0) {
                            Write(" |");
                            continue;
                        } else if(x < othello.Size) {
                            Write(" " + x + "|");
                            continue;
                        } else {
                            Write(" " + x + "\n");
                            continue;
                        }
                    }
                    if(x == 0) {
                        Write(y + "|");
                        continue;
                    }
                    Square s = othello.Square[x - 1,y - 1];
                    if(s.Color == SquareColor.White) {
                        Write("○");
                    } else if(s.Color == SquareColor.Black) {
                        Write("●");
                    } else {
                        if(putableList.IndexOf(s) != -1) {
                            Write("☆");
                        } else {
                            Write("  ");
                        }
                    }
                    if(x < othello.Size) {
                        Write("|");
                    } else {
                        Write("\n");
                    }
                }
            }
        }

        private void Pass() {
            if(putColor == SquareColor.Black) {
                Write("\n●のパス。\n\n");
                putColor = SquareColor.White;
            } else {
                Write("\n○のパス。\n\n");
                putColor = SquareColor.Black;
            }
        }

        private void Put() {
            string r;
            int x = 0,y = 0;
            bool b = false;
            do {
                if(putColor == SquareColor.Black) {
                    Write("\n●の番です。置くマス(横,縦)を\",\"区切りで入力してください。\n");
                } else {
                    Write("\n○の番です。置くマス(横,縦)を\",\"区切りで入力してください。\n");
                }
                r = Console.In.ReadLine();
                string[] ar = r.Split(',');
                if(ar.Length < 2) {
                    continue;
                }
                try {
                    x = int.Parse(ar[0]);
                    y = int.Parse(ar[1]);
                } catch {
                    continue;
                }
                if(x > othello.Size || x < 1 || y > othello.Size || y < 1) {
                    continue;
                }
                Square s = othello.Square[x - 1,y - 1];
                if(putableList.IndexOf(s) == -1) {
                    continue;
                }
                b = true;
            } while(b == false);
            othello.PutColor(x - 1,y - 1,putColor);
            putColor = TurnColor(putColor);
        }

        private SquareColor TurnColor(SquareColor color) {
            if(color == SquareColor.Black) {
                return SquareColor.White;
            } else {
                return SquareColor.Black;
            }
        }

    }
}
