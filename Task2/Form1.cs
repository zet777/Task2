using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Task2
{
    public partial class Form1 : Form
    {
        // Создаем рандомный объект с именем randomizer 
        // для генерации случайных чисел.
        Random randomizer = new Random();
        
        // Сложение 
        int addend1, addend2;
        
        // Вычетание
        int minuend;
        int subtrahend;

        // Умножение
        int multiplicand;
        int multiplier;

        // Деление
        int dividend;
        int divisor;




        // Таймер
        int timeLeft;


        public void StartTheQuiz()
        {
            // При старте сбрасываем цвета на White 
            timeLabel.BackColor = Color.White;
            sum.BackColor = Color.White;
            difference.BackColor = Color.White;
            product.BackColor = Color.White;
            quotient.BackColor = Color.White;

            // Генерируем в переменные случайные числа 
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Приводим числа в строки и присваиваем в нужные метки
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // Присваиваем 0 к переменной
            sum.Value = 0;


            // Заполнение задачи на вычитание
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Заполнение задачи на умножение
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in the division problem.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;


            // Старт таймера
            timeLeft = 30;
            timeLabel.Text = "30 секунд";
            timer1.Start();
            
        }
        //Проверяем правильность ответа 
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
        && (minuend - subtrahend == difference.Value)
        && (multiplicand * multiplier == product.Value)
        && (dividend / divisor == quotient.Value))
                return true;
            else
             return false;
        }


        // Обратный отчет
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft <= 6)
            {
                timeLabel.BackColor = Color.Red;
            }
            // Если в методе true, то таймер останавливается и выводит сообщение
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("Поздравляю, все верно!");
                startButton.Enabled = true;

            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " секунд";
            }
           
            else
            {
                timer1.Stop();
                timeLabel.Text = "Время вышло!";
                MessageBox.Show("Вы не успели вовремя");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

            StartTheQuiz();
            startButton.Enabled = false;
            
            
        }

        private void Sum_ValueChanged(object sender, EventArgs e)
        {
            if (addend1 + addend2 == sum.Value)
            {
                sum.BackColor = Color.Green;
               
            }
        }

        private void Difference_ValueChanged(object sender, EventArgs e)
        {
            if (minuend - subtrahend == difference.Value)
            {
                difference.BackColor = Color.Green;
                
            }
        }

        private void Product_ValueChanged(object sender, EventArgs e)
        {
            if (multiplicand * multiplier == product.Value)
            {
                product.BackColor = Color.Green;
            }
        }

        private void Quotient_ValueChanged(object sender, EventArgs e)
        {
            if (dividend / divisor == quotient.Value)
            {
                quotient.BackColor = Color.Green;
            }
        }

        public Form1()
        {
            InitializeComponent();
            

        }


    }
    
}
