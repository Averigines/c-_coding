using System;
using System.Collections.Generic;

namespace Snake {
    class Program {

        private static bool _inPlay = true;
        private static int _score = 0;

        private Snake _snake = new Snake();
        private Food _food = new Food();

        static void Main(string[] args) {
            Console.Write("Snake running");
            /*while (_inPlay) {
                if(AcceptInput() || UpdateGame()) {
                    DrawScreen();
                }
            }*/
        }

        private static bool AcceptInput() {

            return true;
        }

        private static bool UpdateGame() {

            return true;
        }

        private static void DrawScreen() {
            Console.Clear();
            
        }
    }

    public class Position {
        public int left;
        public int top;
    }

    public class Snake {
        private int _length = 6;
        private List<Position> _points = new List<Position>();

        public int Length {
            get {
                return _length;
            }
            set {
                _length = value;
            }
        }

        public List<Position> Points {
            get {
                return _points;
            }
            set {
                _points = value;
            }
        }
    }

    public class Food {
        private Position? _position = null;
        private Random _rnd = new Random();

        public Position? Position {
            get {
                return _position;
            }
            set {
                _position = value;
            }
        }
    }

}