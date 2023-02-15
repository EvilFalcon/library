﻿using System;
using System.Collections.Generic;

namespace library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.StartMenu();
        }
    }

    class Library
    {
        private List<Book> _books = new List<Book>();

        public Library()
        {
            CreateDefault();
        }

        public void StartMenu()
        {
            const string CommandShowInfoAboutAllBooks = "1";
            const string GenreInfoOutputCommand = "2";
            const string NameInfoOutputCommand = "3";
            const string DateOfCirculationInfoOutputCommand = "4";
            const string UniqueNumberInfoOutputCommand = "5";
            const string AuthorInfoOutputCommand = "6";
            const string CommandDeleteBook = "7";
            const string CommandAddNewBook = "8";
            const string ExitCommand = "9";

            bool isWork = true;

            while (isWork)
            {
                Console.Clear();

                Console.WriteLine($"Показать все книги  : {CommandShowInfoAboutAllBooks}");
                Console.WriteLine($"Поиск по жанру  : {GenreInfoOutputCommand}");
                Console.WriteLine($"Поиск по названию произведения  : {NameInfoOutputCommand}");
                Console.WriteLine($"Поиск по дате первой публикации : {DateOfCirculationInfoOutputCommand}");
                Console.WriteLine($"Поиск по индивидуальному номеру книги  : {UniqueNumberInfoOutputCommand}");
                Console.WriteLine($"Поиск по автору : {AuthorInfoOutputCommand}");
                Console.WriteLine($"Удалить книгу из библиотеки {CommandDeleteBook}");
                Console.WriteLine($"Добавить новую книгу в библиотеку : {CommandAddNewBook}");
                Console.WriteLine($"Выход из приложения {ExitCommand}");

                switch (Console.ReadLine())
                {
                    case CommandShowInfoAboutAllBooks:
                        ShowAllInfo();
                        break;

                    case GenreInfoOutputCommand:
                        SearchGenreInfo();
                        break;

                    case NameInfoOutputCommand:
                        SearchNameInfo();
                        break;

                    case DateOfCirculationInfoOutputCommand:
                        SearchDateOfCirculationInfo();
                        break;

                    case UniqueNumberInfoOutputCommand:
                        SearchUniqueNumberInfo();
                        break;

                    case AuthorInfoOutputCommand:
                        SearchAuthorInfo();
                        break;

                    case CommandDeleteBook:
                        DeleteBook();
                        break;

                    case CommandAddNewBook:
                        CreateNewBook();
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;
                }

                Console.ReadKey();
            }
        }

        private void ShowAllInfo()
        {
            foreach (Book book in _books)
            {
                book.ShowInfo();
            }
        }

        private void CreateNewBook()
        {
            Console.Write("Введите название книги");
            string name = GetUserInput();

            Console.Write("\nВведите жанр книги");
            string genre = GetUserInput();

            Console.Write("\nВведите дату издания книги");
            string dateOfCirculation = GetUserInput();

            Console.Write("\nВведите автора книги");
            string author = GetUserInput();

            if (name != "" && genre != "" && dateOfCirculation != "" && author != "")
            {
                Book newBook = new Book(name, genre, dateOfCirculation, author);
                _books.Add(newBook);
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }

        private void CreateDefault()
        {
            string[] name = { "Гарри Поттер и философский камень", "Гарри Поттер и Тайная комната", "Гарри Поттер и узник Азкабана", "Гарри Поттер и Кубок огня", "Гарри Поттер и Орден Феникса", "Гарри Поттер и Принц-полукровка ", "Гарри Поттер и Дары Смерти", "Гарри Поттер и Проклятое дитя ", "Буря мечей" };

            string[] author = { "Джоан Кэтлин Роулинг", "Джоан Кэтлин Роулинг", "Джоан Кэтлин Роулинг", "Джоан Кэтлин Роулинг", "Джоан Кэтлин Роулинг", "Джоан Кэтлин Роулинг", "Джоан Кэтлин Роулинг", "Джоан Кэтлин Роулинг", "Джордж Р. Мартин" };

            string[] genre = { "фэнтези", "фэнтези", "фэнтези", "фэнтези", "фэнтези", "фэнтези", "фэнтези", "фэнтези", "Роман" };

            string[] dateOfCirculation = { "26 июня 1997 года", "2 июля 1998", "8 июля 1999", "8 июля 2000", "21 июня 2003", "16 июля 2005", "21 июля 2007", "31 июля 2016 года", "8 августа 2000 года" };

            for (int i = 0; i < name.Length; i++)
            {
                Book book = new Book(name[i], genre[i], dateOfCirculation[i], author[i]);
                _books.Add(book);
            }
        }

        private void SearchGenreInfo()
        {
            string userInput = GetUserInput();

            foreach (Book book in _books)
            {
                if (book.Genre.ToLower().Contains(userInput))
                {
                    book.ShowInfo();
                }
            }
        }

        private static string GetUserInput()
        {
            return Console.ReadLine();
        }

        private void SearchNameInfo()
        {
            string userInput = GetUserInput();

            foreach (Book book in _books)
            {
                if (book.Name.ToLower().Contains(userInput))
                {
                    book.ShowInfo();
                }
            }
        }

        private void SearchDateOfCirculationInfo()
        {
            Console.WriteLine("Введите дату первой публикации ");
            string userInput = GetUserInput();

            foreach (Book book in _books)
            {
                if (book.DateOfCirculation.ToLower().Contains(userInput))
                {
                    book.ShowInfo();
                }
            }
        }

        private void SearchUniqueNumberInfo()
        {
            Console.WriteLine("Введите номер книги");

            int numberId = CheckNumber();

            foreach (Book book in _books)
            {
                if (book.UniqueNumber == numberId)
                {
                    book.ShowInfo();
                }
            }
        }

        private int CheckNumber()
        {
            int number;

            while (int.TryParse(GetUserInput(), out number) == false)
            {
                Console.WriteLine("неверный ввод");
            }

            return number;
        }

        private void SearchAuthorInfo()
        {
            Console.WriteLine("Напишите автора ");

            string text = GetUserInput();

            foreach (Book book in _books)
            {
                if (book.Author.ToLower().Contains(text))
                {
                    book.ShowInfo();
                }
            }
        }

        private void DeleteBook()
        {
            Console.Write("введите уникальный номер книги :");

            int number = CheckNumber();
            int index = number - 1;
            bool isSuchABook = false;
            foreach (Book book in _books)
            {
                if (book.UniqueNumber == number)
                {
                    isSuchABook = true;
                }
            }

            if (isSuchABook)
            {
                _books.RemoveAt(index);
                Console.WriteLine($"книга с номером  {number} удалина ");
            }
            else
            {
                Console.WriteLine("такой книги нет");
            }
        }
    }

    class Book
    {
        private static int _ids = 0;
        private string _name;
        private string _author;
        private string _genre;
        private string _dateOfCirculation;

        public Book(string name, string genre, string dateOfCirculation, string author)
        {
            _name = name;
            _genre = genre;
            _dateOfCirculation = dateOfCirculation;
            UniqueNumber = ++_ids;
            _author = author;
        }

        public int UniqueNumber { get; private set; }

        public string Name => _name;

        public string Author => _author;

        public string Genre => _genre;

        public string DateOfCirculation => _dateOfCirculation;

        public void ShowInfo()
        {
            Console.WriteLine($"|Индивидуальный номер книги: {UniqueNumber}|Название произведения: {_name}|ФИО автора: {_author}|Жанр: {_genre}|Дата первой публикации: {_dateOfCirculation}|");
        }
    }
}