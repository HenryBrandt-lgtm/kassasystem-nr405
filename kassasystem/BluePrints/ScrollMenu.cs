using System;

namespace kassasystem
{
    internal class ScrollMenu
    {
        public int ScrollMenuOptionOf4WithoutExit(KeyMenu options)
        {
            ConsoleKeyInfo key;
            int option = 1;
            bool isSelected = false;
            string choiceIndicator = "\u001b[32m-> ";
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.CursorVisible = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == 1 ? choiceIndicator : "   ")}\u001b[0m{options.Option1}");
                Console.WriteLine($"{(option == 2 ? choiceIndicator : "   ")}\u001b[0m{options.Option2}");
                Console.WriteLine($"{(option == 3 ? choiceIndicator : "   ")}\u001b[0m{options.Option3}");
                Console.WriteLine($"{(option == 4 ? choiceIndicator : "   ")}\u001b[0m{options.Option4}");

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = option == 4 ? 1 : option + 1;
                        break;

                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 4 : option - 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            return option;
        }
        public int ScrollMenuOptionOf4(KeyMenu options)
        {
            ConsoleKeyInfo key;
            int option = 1;
            bool isSelected = false;
            string choiceIndicator = "\u001b[32m-> ";
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.CursorVisible = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == 1 ? choiceIndicator : "   ")}\u001b[0m{options.Option1}");
                Console.WriteLine($"{(option == 2 ? choiceIndicator : "   ")}\u001b[0m{options.Option2}");
                Console.WriteLine($"{(option == 3 ? choiceIndicator : "   ")}\u001b[0m{options.Option3}");
                Console.WriteLine($"{(option == 4 ? choiceIndicator : "   ")}\u001b[0m{options.Option4}");
                Console.WriteLine($"{(option == 4 ? choiceIndicator : "   ")}\u001b[0mExit");


                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = option == 4 ? 1 : option + 1;
                        break;

                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 4 : option - 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            return option;
        }
        public int ScrollMenuOptionOf3(KeyMenu options)
        {
            ConsoleKeyInfo key;
            int option = 1;
            bool isSelected = false;
            string choiceIndicator = "\u001b[32m-> ";
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.CursorVisible = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? choiceIndicator : "   ")}\u001b[0m{options.Option1}");
                Console.WriteLine($"{(option == 2 ? choiceIndicator : "   ")}\u001b[0m{options.Option2}");
                Console.WriteLine($"{(option == 3 ? choiceIndicator : "   ")}\u001b[0m{options.Option3}");
                Console.WriteLine($"{(option == 4 ? choiceIndicator : "   ")}\u001b[0mExit");

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = option == 4 ? 1 : option + 1;
                        break;

                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 4 : option - 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            return option;
        }
        public int ScrollMenuOptionOf3WithoutExit(KeyMenu options)
        {
            ConsoleKeyInfo key;
            int option = 1;
            bool isSelected = false;
            string choiceIndicator = "\u001b[32m-> ";
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.CursorVisible = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? choiceIndicator : "   ")}\u001b[0m{options.Option1}");
                Console.WriteLine($"{(option == 2 ? choiceIndicator : "   ")}\u001b[0m{options.Option2}");
                Console.WriteLine($"{(option == 3 ? choiceIndicator : "   ")}\u001b[0m{options.Option3}");

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = option == 4 ? 1 : option + 1;
                        break;

                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 4 : option - 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            return option;
        }
        public int ScrollMenuOptionOf2(KeyMenu options)
        {
            ConsoleKeyInfo key;
            int option = 1;
            bool isSelected = false;
            string choiceIndicator = "\u001b[32m-> ";
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.CursorVisible = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == 1 ? choiceIndicator : "   ")}\u001b[0m{options.Option1}");
                Console.WriteLine($"{(option == 2 ? choiceIndicator : "   ")}\u001b[0m{options.Option2}");
                Console.WriteLine($"{(option == 4 ? choiceIndicator : "   ")}\u001b[0mExit");

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = option == 3 ? 1 : option + 1;
                        break;

                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 3 : option - 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            return option;
        }
        public int ScrollMenuOptionOf2WithoutExit(KeyMenu options)
        {
            ConsoleKeyInfo key;
            int option = 1;
            bool isSelected = false;
            string choiceIndicator = "\u001b[32m-> ";
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.CursorVisible = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == 1 ? choiceIndicator : "   ")}\u001b[0m{options.Option1}");
                Console.WriteLine($"{(option == 2 ? choiceIndicator : "   ")}\u001b[0m{options.Option2}");

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = option == 2 ? 1 : option + 1;
                        break;

                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 2 : option - 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            return option;
        }
    }
}
