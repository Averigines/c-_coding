using System;
using System.Collections.Generic;

namespace Snake {
    class Program {

        private static bool _inPlay = true;
        private static int _score = 0;

        private static Snake _snake = new Snake();
        private static Food _food = new Food();

        static void Main(string[] args) {
            while (_inPlay) {
                if(AcceptInput() || UpdateGame()) {
                    DrawScreen();
                }
            }
        }

        static ConsoleKeyInfo? _lastKey;

        private static bool AcceptInput() {

            if (!Console.KeyAvailable) return false;

            _lastKey = Console.ReadKey();
            return true;
        }

        private static DateTime nextUpdate = DateTime.MinValue;
        private static bool UpdateGame() {

            if(DateTime.Now < nextUpdate) return false;

            if (_food.Position == null) {
                _food.Position = new Position() {
                    left = _food.Rnd.Next(Console.WindowWidth),
                    top = _food.Rnd.Next(Console.WindowHeight)
                };
            }

            if (_lastKey.HasValue) {
                MoveSnake(_lastKey.Value);
            }

            nextUpdate = DateTime.Now.AddMilliseconds(500/(_score+1));

            return true;
        }

        private static void MoveSnake(ConsoleKeyInfo key) {
            Position currentPos;

            if (_snake.Points.Count != 0) {
                currentPos = new Position() {
                    left = _snake.Points.Last().left,
                    top = _snake.Points.Last().top
                };
            }
            else {
                currentPos = _snake.SetInitialPosition();
            }

            switch(key.Key) {
                case ConsoleKey.LeftArrow:
                currentPos.left--;
                    break;
                case ConsoleKey.RightArrow:
                currentPos.left++;
                    break;
                case ConsoleKey.UpArrow:
                currentPos.top--;
                    break;
                case ConsoleKey.DownArrow:
                currentPos.top++;
                    break;
                default:
                    break;
            }

            if(DetectCollision(currentPos) == false) {
                _snake.Points.Add(currentPos);
                _snake.CleanUp();
            }
            else GameOver();
        }

        private static bool DetectCollision(Position currentPos) {

            if (currentPos.top < 0 || currentPos.top > Console.WindowHeight-1 ||
                currentPos.left < 0 || currentPos.left > Console.WindowWidth-1) {
                //GameOver();
                return true;
            }

            if (_snake.IfOverlapped(currentPos)) {
                return true;
            }

            if ((_food.Position != null) && (_food.Position.left == currentPos.left) && (_food.Position.top == currentPos.top)) {
                _snake.Length++;
                _score++;
                _food.Position = null;
            }

            return false;
        }

        private static void DrawScreen() {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth-3, Console.WindowHeight-1);
            Console.Write(_score);

            for(int i = 0; i<_snake.Points.Count; i++) {
                Console.SetCursorPosition(_snake.Points[i].left, _snake.Points[i].top);
                Console.Write("*");
            }

            if(_food.Position != null) {
                Console.SetCursorPosition(_food.Position.left, _food.Position.top);
                Console.Write("a");
            }
        }

        private static void GameOver() {
            _inPlay = false;
            Console.Clear();
            Console.WriteLine("Game Over! Your score was: " + _score);
            Console.ReadLine();
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

        public bool IfOverlapped(Position currentPos) {

            for(int i = 0; i < _points.Count; i++) {
                if ((_points[i].left == currentPos.left) && (_points[i].top == currentPos.top)) {
                    return true;
                }
            }

            return false;
        }

        public Position SetInitialPosition() {
            return new Position() {
                left = 0,
                top = 0
            };
         }

         public void CleanUp() {
            while(_points.Count > _length) {
                _points.Remove(_points.First());
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

        public Random Rnd {
            get { return _rnd; }
            set { _rnd = value; }
        }
    }

}