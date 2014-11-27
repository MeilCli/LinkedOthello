using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedOthello {
    
    public enum SquareColor { White, Black, Null}
    
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

        public List<Square> GetLeftOverColorableSquare(SquareColor putColor){
            SquareColor findColor = putColor == SquareColor.Black ? SquareColor.White : SquareColor.Black;
            var list = new List<Square>();
            Square v = LeftOverSquare;
            if(v != null && v.Color == findColor) {           
                while(v != null) {
                    if(v.Color == putColor) {
                        return list;
                    } else if(v.Color == SquareColor.Null) {
                        list.Clear();
                        return list;
                    }
                    list.Add(v);
                    v = v.LeftOverSquare;
                }
                list.Clear();
            }
            return list;
        }

        public List<Square> GetOverColorableSquare(SquareColor putColor) {
            SquareColor findColor = putColor == SquareColor.Black ? SquareColor.White : SquareColor.Black;
            var list = new List<Square>();
            Square v = OverSquare;
            if(v != null && v.Color == findColor) {
                while(v != null) {
                    if(v.Color == putColor) {
                        return list;
                    } else if(v.Color == SquareColor.Null) {
                        list.Clear();
                        return list;
                    }
                    list.Add(v);
                    v = v.OverSquare;
                }
                list.Clear();
            }
            return list;
        }

        public List<Square> GetRightOverColorableSquare(SquareColor putColor) {
            SquareColor findColor = putColor == SquareColor.Black ? SquareColor.White : SquareColor.Black;
            var list = new List<Square>();
            Square v = RightOverSquare;
            if(v != null && v.Color == findColor) {
                while(v != null) {
                    if(v.Color == putColor) {
                        return list;
                    } else if(v.Color == SquareColor.Null) {
                        list.Clear();
                        return list;
                    }
                    list.Add(v);
                    v = v.RightOverSquare;
                }
                list.Clear();
            }
            return list;
        }

        public List<Square> GetRightColorableSquare(SquareColor putColor) {
            SquareColor findColor = putColor == SquareColor.Black ? SquareColor.White : SquareColor.Black;
            var list = new List<Square>();
            Square v = RightSquare;
            if(v != null && v.Color == findColor) {
                while(v != null) {
                    if(v.Color == putColor) {
                        return list;
                    } else if(v.Color == SquareColor.Null) {
                        list.Clear();
                        return list;
                    }
                    list.Add(v);
                    v = v.RightSquare;
                }
                list.Clear();
            }
            return list;
        }

        public List<Square> GetRightUnderColorableSquare(SquareColor putColor) {
            SquareColor findColor = putColor == SquareColor.Black ? SquareColor.White : SquareColor.Black;
            var list = new List<Square>();
            Square v = RightUnderSquare;
            if(v != null && v.Color == findColor) {
                while(v != null) {
                    if(v.Color == putColor) {
                        return list;
                    } else if(v.Color == SquareColor.Null) {
                        list.Clear();
                        return list;
                    }
                    list.Add(v);
                    v = v.RightUnderSquare;
                }
                list.Clear();
            }
            return list;
        }

        public List<Square> GetUnderColorableSquare(SquareColor putColor) {
            SquareColor findColor = putColor == SquareColor.Black ? SquareColor.White : SquareColor.Black;
            var list = new List<Square>();
            Square v = UnderSquare;
            if(v != null && v.Color == findColor) {
                while(v != null) {
                    if(v.Color == putColor) {
                        return list;
                    } else if(v.Color == SquareColor.Null) {
                        list.Clear();
                        return list;
                    }
                    list.Add(v);
                    v = v.UnderSquare;
                }
                list.Clear();
            }
            return list;
        }

        public List<Square> GetLeftUnderColorableSquare(SquareColor putColor) {
            SquareColor findColor = putColor == SquareColor.Black ? SquareColor.White : SquareColor.Black;
            var list = new List<Square>();
            Square v = LeftUnderSquare;
            if(v != null && v.Color == findColor) {
                while(v != null) {
                    if(v.Color == putColor) {
                        return list;
                    } else if(v.Color == SquareColor.Null) {
                        list.Clear();
                        return list;
                    }
                    list.Add(v);
                    v = v.LeftUnderSquare;
                }
                list.Clear();
            }
            return list;
        }

        public List<Square> GetLeftColorableSquare(SquareColor putColor) {
            SquareColor findColor = putColor == SquareColor.Black ? SquareColor.White : SquareColor.Black;
            var list = new List<Square>();
            Square v = LeftSquare;
            if(v != null && v.Color == findColor) {
                while(v != null) {
                    if(v.Color == putColor) {
                        return list;
                    } else if(v.Color == SquareColor.Null) {
                        list.Clear();
                        return list;
                    }
                    list.Add(v);
                    v = v.LeftSquare;
                }
                list.Clear();
            }
            return list;
        }

        public override bool Equals(object obj) {
            return base.Equals(obj) && obj is Square && (obj as Square).X == X && (obj as Square).Y == Y;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
