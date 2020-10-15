using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if(txt1.Text!="0")
            {
                txt1.Text += 0;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txt1.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txt1.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txt1.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txt1.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txt1.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txt1.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txt1.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txt1.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txt1.Text += "9";
        }

        private void btnAyirish_Click(object sender, EventArgs e)
        {
            int len = txt1.Text.Length;
            if (len != 0)
            {
                if (txt1.Text[len - 1].ToString() != "^" || txt1.Text[len - 1].ToString() != "." || txt1.Text[len - 1].ToString() != "*" && txt1.Text[len - 1].ToString() != "/" && txt1.Text[len - 1].ToString() != "+" && txt1.Text[len - 1].ToString() != "-")
                {
                    txt1.Text += "-";
                    alfa = false;
                }

            }
        }

        private void btnQushish_Click(object sender, EventArgs e)
        {
            int len = txt1.Text.Length;
            if(len != 0)
            {
                if (txt1.Text[len - 1].ToString() != "^" || txt1.Text[len - 1].ToString() != "." || txt1.Text[len - 1].ToString() != "*" && txt1.Text[len - 1].ToString() != "/" && txt1.Text[len - 1].ToString() != "+" && txt1.Text[len - 1].ToString() != "-")
                {
                    txt1.Text += "+";
                    alfa = false;
                }
                
            }
        }

        private void btnKupaytiruv_Click(object sender, EventArgs e)
        {
            int len = txt1.Text.Length;
            if (len != 0)
            {
                if (txt1.Text[len-1].ToString() != "^" || txt1.Text[len - 1].ToString() != "." || txt1.Text[len - 1].ToString() != "*" && txt1.Text[len - 1].ToString() != "/" && txt1.Text[len - 1].ToString() != "+" && txt1.Text[len - 1].ToString() != "-")
                {
                    txt1.Text += "*";
                    alfa = false;
                }

            }
        }

        private void btnBuluv_Click(object sender, EventArgs e)
        {
            int len = txt1.Text.Length;
            if (len != 0)
            {
                if (txt1.Text[len - 1].ToString() != "^" || txt1.Text[len - 1].ToString() != "." || txt1.Text[len - 1].ToString() != "*" && txt1.Text[len - 1].ToString() != "/" && txt1.Text[len - 1].ToString() != "+" && txt1.Text[len - 1].ToString() != "-")
                {
                    txt1.Text += "/";
                    alfa = false;
                }

            }
        }

        int qavsOchish = 0;
        int qavsYopish = 0;

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            qavsOchish = 0;
            qavsYopish = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int len = txt1.Text.Length;
            if(len != 0)
            {
                if(txt1.Text[len-1].ToString() == "(")
                {
                    qavsOchish--;
                }
                else if(txt1.Text[len-1].ToString() == ")")
                {
                    qavsYopish--;
                }
                string m = "";
                for(int i=0;i<len-1;i++)
                {
                    m += txt1.Text[i];
                }

                txt1.Text = m;
            }
        }

        private void btnResult4_Click(object sender, EventArgs e)
        {
            bool check = true;
            int len = txt1.Text.Length;
            if(txt1.Text[len-1].ToString() =="+" || txt1.Text[len - 1].ToString() == "-" || txt1.Text[len - 1].ToString() == "*" || txt1.Text[len - 1].ToString() == "/")
            {
                check = false;
            }
            if(qavsOchish != qavsYopish || check == false)
            {
                MessageBox.Show("Error");
            }
            else
            {
                txt2.Text = RPN.Calculate(txt1.Text).ToString();
            }
        }
        class RPN
        {
            //Метод Calculate принимает выражение в виде строки и возвращает результат, в своей работе использует другие методы класса
            static public double Calculate(string input)
            {
                string output = GetExpression(input); //Преобразовываем выражение в постфиксную запись
                double result = Counting(output); //Решаем полученное выражение
                return result; //Возвращаем результат
            }
            static private string GetExpression(string input)
            {
                string output = string.Empty; //Строка для хранения выражения
                Stack<char> operStack = new Stack<char>(); //Стек для хранения операторов

                for (int i = 0; i < input.Length; i++) //Для каждого символа в входной строке
                {
                    //Разделители пропускаем
                    if (IsDelimeter(input[i]))
                        continue; //Переходим к следующему символу

                    //Если символ - цифра, то считываем все число
                    if (Char.IsDigit(input[i])) //Если цифра
                    {
                        //Читаем до разделителя или оператора, что бы получить число
                        while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                        {
                            output += input[i]; //Добавляем каждую цифру числа к нашей строке
                            i++; //Переходим к следующему символу

                            if (i == input.Length) break; //Если символ - последний, то выходим из цикла
                        }

                        output += " "; //Дописываем после числа пробел в строку с выражением
                        i--; //Возвращаемся на один символ назад, к символу перед разделителем
                    }

                    //Если символ - оператор
                    if (IsOperator(input[i])) //Если оператор
                    {
                        if (input[i] == '(') //Если символ - открывающая скобка
                            operStack.Push(input[i]); //Записываем её в стек
                        else
                        if (input[i] == ')') //Если символ - закрывающая скобка
                        {
                            //Выписываем все операторы до открывающей скобки в строку
                            char s = operStack.Pop();

                            while (s != '(')
                            {
                                output += s.ToString() + ' ';
                                s = operStack.Pop();
                            }
                        }
                        else //Если любой другой оператор
                        {
                            if (operStack.Count > 0) //Если в стеке есть элементы
                                if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                                    output += operStack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением
                            operStack.Push(char.Parse(input[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека

                        }
                    }
                }

                //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
                while (operStack.Count > 0)
                    output += operStack.Pop() + " ";

                return output; //Возвращаем выражение в постфиксной записи
            }
            static private double Counting(string input)
            {
                double result = 0; //Результат
                Stack<double> temp = new Stack<double>(); //Dhtvtyysq стек для решения

                for (int i = 0; i < input.Length; i++) //Для каждого символа в строке
                {
                    //Если символ - цифра, то читаем все число и записываем на вершину стека
                    if (Char.IsDigit(input[i]))
                    {
                        string a = string.Empty;

                        while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Пока не разделитель
                        {
                            a += input[i]; //Добавляем
                            i++;
                            if (i == input.Length) break;
                        }
                        temp.Push(double.Parse(a)); //Записываем в стек
                        i--;
                    }
                    else if (IsOperator(input[i])) //Если символ - оператор
                    {
                        //Берем два последних значения из стека
                        double a = temp.Pop();
                        double b = temp.Pop();

                        switch (input[i]) //И производим над ними действие, согласно оператору
                        {
                            case '+': result = b + a; break;
                            case '-': result = b - a; break;
                            case '*': result = b * a; break;
                            case '/': result = b / a; break;
                            case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                        }
                        temp.Push(result); //Результат вычисления записываем обратно в стек
                    }
                }
                return temp.Peek(); //Забираем результат всех вычислений из стека и возвращаем его
            }
            static private bool IsDelimeter(char c)
            {
                if ((" =".IndexOf(c) != -1))
                    return true;
                return false;
            }

            static private bool IsOperator(char с)
            {
                if (("+-/*^()".IndexOf(с) != -1))
                    return true;
                return false;
            }

            static private byte GetPriority(char s)
            {
                switch (s)
                {
                    case '(': return 0;
                    case ')': return 1;
                    case '+': return 2;
                    case '-': return 3;
                    case '*': return 4;
                    case '/': return 4;
                    case '^': return 5;
                    default: return 6;
                }
            }
        }
        
        private void btnQavsChap_Click(object sender, EventArgs e)
        {
            txt1.Text += "(";
            qavsOchish++;
            alfa = false;
        }

        private void btnQavsUng_Click(object sender, EventArgs e)
        {
            if(qavsYopish<qavsOchish)
            {
                txt1.Text += ")";
                qavsYopish++;
                alfa = false;
            }         
        }

        private void btnDaraja_Click(object sender, EventArgs e)
        {
            int len = txt1.Text.Length;
            if (len != 0)
            {
                if (txt1.Text[len - 1].ToString() != "^" || txt1.Text[len - 1].ToString() != "." || txt1.Text[len - 1].ToString() != "*" && txt1.Text[len - 1].ToString() != "/" && txt1.Text[len - 1].ToString() != "+" && txt1.Text[len - 1].ToString() != "-")
                {
                    txt1.Text += "^";
                }
            }
        }
        bool alfa = false;
        private void btnVergul_Click(object sender, EventArgs e)
        {
            int len = txt1.Text.Length;
            if (len != 0 && alfa == false)
            {
                if (txt1.Text[len - 1].ToString() != "^" || txt1.Text[len - 1].ToString() != "." || txt1.Text[len - 1].ToString() != "*" && txt1.Text[len - 1].ToString() != "/" && txt1.Text[len - 1].ToString() != "+" && txt1.Text[len - 1].ToString() != "-")
                {
                    txt1.Text += ".";
                    alfa = true;
                }
            }
        }
    }
}
