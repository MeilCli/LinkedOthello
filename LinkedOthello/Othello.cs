using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedOthello {
    public class Othello8 : Othello {
        public Othello8()
            : base(8) {
            Square[3,3].Color = SquareColor.White;
            Square[3,4].Color = SquareColor.Black;
            Square[4,3].Color = SquareColor.Black;
            Square[4,4].Color = SquareColor.White;
        }
    }

    public class Othello {

        public Othello(int size) {
            this.Size = size;
            this.Square = MakeSquare(size);
        }

        public int Size { get; private set; }
        public Square[,] Square { get; set; }

        private Square[,] MakeSquare(int size) {
            Square[,] square = new Square[size,size];
            for(int y = 0;y < size;y++) {
                for(int x = 0;x < size;x++) {
                    Square s = new Square(x,y);
                    square[x,y] = s;
                    if(y > 0) {
                        Square over = square[x,y - 1];
                        over.UnderSquare = s;
                        s.OverSquare = over;
                        if(over.LeftSquare != null) {
                            over.LeftSquare.RightUnderSquare = s;
                            s.LeftOverSquare = over.LeftSquare;
                        }
                        if(over.RightSquare != null) {
                            over.RightSquare.LeftUnderSquare = s;
                            s.RightOverSquare = over.RightSquare;
                        }
                    }
                    if(x > 0) {
                        Square left = square[x - 1,y];
                        left.RightSquare = s;
                        s.LeftSquare = left;
                    }
                }
            }
            return square;
        }

        public List<Square> GetColorableSquare(SquareColor putColor) {
            var list = new List<Square>();
            foreach(Square s in Square) {
                if(s.Color != SquareColor.Null) {
                    continue;
                }
                if(s.GetLeftOverColorableSquare(putColor).Count > 0) {
                    list.Add(s);
                    continue;
                }
                if(s.GetOverColorableSquare(putColor).Count > 0) {
                    list.Add(s);
                    continue;
                }
                if(s.GetRightOverColorableSquare(putColor).Count > 0) {
                    list.Add(s);
                    continue;
                }
                if(s.GetRightColorableSquare(putColor).Count > 0) {
                    list.Add(s);
                    continue;
                }
                if(s.GetRightUnderColorableSquare(putColor).Count > 0) {
                    list.Add(s);
                    continue;
                }
                if(s.GetUnderColorableSquare(putColor).Count > 0) {
                    list.Add(s);
                    continue;
                }
                if(s.GetLeftUnderColorableSquare(putColor).Count > 0) {
                    list.Add(s);
                    continue;
                }
                if(s.GetLeftColorableSquare(putColor).Count > 0) {
                    list.Add(s);
                    continue;
                }
            }
            return list;
        }

        public List<Square> GetTurnableSquare(int x,int y,SquareColor putColor) {
            var list = new List<Square>();
            Square s = Square[x,y];
            list.AddRange(s.GetLeftOverColorableSquare(putColor));
            list.AddRange(s.GetOverColorableSquare(putColor));
            list.AddRange(s.GetRightOverColorableSquare(putColor));
            list.AddRange(s.GetRightColorableSquare(putColor));
            list.AddRange(s.GetRightUnderColorableSquare(putColor));
            list.AddRange(s.GetUnderColorableSquare(putColor));
            list.AddRange(s.GetLeftUnderColorableSquare(putColor));
            list.AddRange(s.GetLeftColorableSquare(putColor));
            return list;
        }

        public void PutColor(int x,int y,SquareColor putColor) {
            var list = GetTurnableSquare(x,y,putColor);
            Square s = Square[x,y];
            foreach(var v in list) {
                v.Color = putColor;
            }
            s.Color = putColor;
        }

        public int PutedCount() {
            int count = 0;
            foreach(Square s in Square) {
                if(s.Color != SquareColor.Null) {
                    count++;
                }
            }
            return count;
        }

        public int PutableCount() {
            return Size * Size - PutedCount();
        }

        public int BlackCount() {
            int count = 0;
            foreach(Square s in Square) {
                if(s.Color == SquareColor.Black) {
                    count++;
                }
            }
            return count;
        }

        public int WhiteCount() {
            int count = 0;
            foreach(Square s in Square) {
                if(s.Color == SquareColor.White) {
                    count++;
                }
            }
            return count;
        }
    }
}
