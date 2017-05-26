using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    class Program
    {

        [DllImport("msvcrt")]
        static extern int _getch();
        static string[] menu = new string[] { "\n Лаба 5  ", "  Лаба 6  ", "  Лаба 7  ", "  Лаба 8.1 ", "  Лаба 8.2 \n", "_________________________________________________\n\n" };
        static int menuselected = 0;
        static void drawmenu() //функция для отображения меню
        {
            for (int i = 0; i <= 5; i++)  //Вывод пунктов меню на экран
            {
                if (i == menuselected)  //переменная menuselect отвечает за выбранный пункт меню
                    Console.ForegroundColor = ConsoleColor.Red; //выбранный пункт меню выделяем цветом (красный)
                else
                    Console.ResetColor();
                Console.Write(menu[i]);
            }
        }
        static void kbhandler() //обработчик нажатий клавиш
        {
            //switch ((int)(Console.ReadKey(true).KeyChar))            {   //мусор
            switch (_getch())
            {
                case 224: // нажатие стрелок(при нажатии стрелок передается 2 кода, первый из них 224)
                    {
                        switch (_getch())
                        {
                            case 75: //стрелка влево - переключаем пункт меню
                                {
                                    menuselected = (menuselected + 4) % 5; //уменьшаем menuselected на 1
                                    break;
                                }
                            case 77: //стрелка вправо - переключаем пункт меню
                                {
                                    menuselected = (menuselected + 1) % 5; //увеличиваем menuselected на 1
                                    break;
                                }
                        }
                        break;
                    }
                case 13:  // нажатие Enter - выполняем фукнцию, соответствующую выбранному пункту меню
                    {
                        switch (menuselected)
                        {
                            case 0:
                                lab5.lab5.Main();
                                _getch();
                                break;

                            case 1:
                                lab6.lab6.Main();
                                _getch();
                                break;

                            case 2:
                                lab7.lab7.Main();
                                _getch();
                                break;

                            case 3:
                                
                                FileReader.lab8e1.Main();
                                _getch();
                                break;

                            case 4:

                                timerEvent.lab8e2.Main();
                                _getch();
                                break;
                        }
                        break;
                    }
            }

            Console.Clear();//очистка экрана
            drawmenu();  // вывод меню
        }
        static void Main(string[] args)
        {

            drawmenu(); // вывод меню
            for (;;) kbhandler(); //зацикливаем обработчик клавиатуры чтобы меню всегда работало

        }
    }
}
