using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        // Создаем рандомный объект с именем randomizer 
        // для генерации случайных чисел.
        Random randomizer = new Random();

        int addend1, addend2;


        public void StartTheQuiz()
        {
            //Генерируем в переменные случайные значения
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);


        }

        public Form1()
        {
            InitializeComponent();
        }

       
    }
}
