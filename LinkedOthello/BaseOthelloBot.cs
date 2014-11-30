using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedOthello {
    public class BaseOthelloBot {

        protected Othello Othello { get; set; }
        protected SquareColor PutColor { get; set; }

        public BaseOthelloBot(Othello othello,SquareColor putColor) {
            this.Othello = othello;
            this.PutColor = putColor;
        }

        public virtual Square PutNextSquare() {
            var colorableSquare = Othello.GetColorableSquare(PutColor);
            var nextSquares = new List<Square>();
            int nextSquarePoint = -100;
            int p = 0;
            foreach(Square s in colorableSquare) {
                p = SquarePoint(s);
                if(p > nextSquarePoint) {
                    nextSquarePoint = p;
                    nextSquares.Clear();
                    nextSquares.Add(s);
                } else if(p == nextSquarePoint) {
                    nextSquares.Add(s);
                }
            }
            Random r = new Random();
            return nextSquares[r.Next(nextSquares.Count)];
        }

        protected virtual int SquarePoint(Square s) {
            int p = Othello.GetTurnableSquare(s.X,s.Y,PutColor).Count;
            if(s.IsCornerSquare() == true) {
                p = p + 6;
            }
            if(s.IsSideSquare() == true) {
                p = p + 2;
            }
            if((s.LeftOverSquare != null && s.LeftOverSquare.IsCornerSquare() == true)
                || (s.RightOverSquare != null && s.RightOverSquare.IsCornerSquare() == true)
                || (s.RightUnderSquare != null && s.RightUnderSquare.IsCornerSquare() == true)
                || (s.LeftUnderSquare != null && s.LeftUnderSquare.IsCornerSquare() == true)) {
                p = p - 4;
            }
            if((s.LeftSquare != null && s.LeftSquare.IsCornerSquare() == true)
                || (s.OverSquare != null && s.OverSquare.IsCornerSquare() == true)
                || (s.RightSquare != null && s.RightSquare.IsCornerSquare() == true)
                || (s.UnderSquare != null && 
                s.UnderSquare.IsCornerSquare() == true)) {
                p = p - 2;
            }
            return p;
        }
    }
}
