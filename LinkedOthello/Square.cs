using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedOthello {

    public enum SquareColor { White, Black, Null}

    public static class SquareColorExtensions {
        public static SquareColor TurnColor(this SquareColor color) {
            if(color == SquareColor.Black) {
                return SquareColor.White;
            } else if(color == SquareColor.White) {
                return SquareColor.Black;
            }
            return color;
        }
    }
    
    public class Square {  

        public Square(int x,int y) {
            this.X = x;
            this.Y = y;
            this.Color = SquareColor.Null;
        }
        
        public Square LeftOverSquare { get; internal set; }
        public Square OverSquare { get; internal set; }
        public Square RightOverSquare { get; internal set; }
        public Square RightSquare { get; internal set; }
        public Square RightUnderSquare { get; internal set; }
        public Square UnderSquare { get; internal set; }
        public Square LeftUnderSquare { get; internal set; }
        public Square LeftSquare { get; internal set; }

        public int X { get; private set; }
        public int Y { get; private set; }

        public SquareColor Color { get; set; }

        private List<Square> GetColorableSquare(SquareColor putColor,Func<Square,Square> nextSquare) {
            SquareColor findColor = putColor.TurnColor();
            var list = new List<Square>();
            Square v = nextSquare(this);
            if(v != null && v.Color == findColor) {
                while(v != null) {
                    if(v.Color == putColor) {
                        return list;
                    } else if(v.Color == SquareColor.Null) {
                        list.Clear();
                        return list;
                    }
                    list.Add(v);
                    v = nextSquare(v);
                }
                list.Clear();
            }
            return list;
        }

        public List<Square> GetLeftOverColorableSquare(SquareColor putColor){
            return GetColorableSquare(putColor,s => s.LeftOverSquare);
        }

        public List<Square> GetOverColorableSquare(SquareColor putColor) {
            return GetColorableSquare(putColor,s => s.OverSquare);
        }

        public List<Square> GetRightOverColorableSquare(SquareColor putColor) {
            return GetColorableSquare(putColor,s => s.RightOverSquare);
        }

        public List<Square> GetRightColorableSquare(SquareColor putColor) {
            return GetColorableSquare(putColor,s => s.RightSquare);
        }

        public List<Square> GetRightUnderColorableSquare(SquareColor putColor) {
            return GetColorableSquare(putColor,s => s.RightUnderSquare);
        }

        public List<Square> GetUnderColorableSquare(SquareColor putColor) {
            return GetColorableSquare(putColor,s => s.UnderSquare);
        }

        public List<Square> GetLeftUnderColorableSquare(SquareColor putColor) {
            return GetColorableSquare(putColor,s => s.LeftUnderSquare);
        }

        public List<Square> GetLeftColorableSquare(SquareColor putColor) {
            return GetColorableSquare(putColor,s => s.LeftSquare);
        }

        public bool IsSideSquare() {
            return LeftSquare == null || OverSquare == null || RightSquare == null || UnderSquare == null;
        }

        public bool IsCornerSquare() {
            return IsSideSquare() == true && (LeftOverSquare == null || RightOverSquare == null
                || RightUnderSquare == null || LeftUnderSquare == null);
        }

        public override bool Equals(object obj) {
            return base.Equals(obj) && obj is Square && (obj as Square).X == X && (obj as Square).Y == Y;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
