using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinearProgramming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            maxOrMinComboBox.SelectedIndex = 0;

        }
        TextBox[]   boxesFuncX;     // Поля для ввода коэфицентов x в функции
        TextBox[,]  boxesLimits;    // Поля для ввода коэф. ограниичений
        ComboBox[]  sign;           // массив знаков неравенста/равенства в ограничениях
        TextBox[]   boxValOfLimit;  // правая часть уравнений ограничений

        double[]    funcT;          // параметры T в целевой функции
        double[]    func;           // целевая функция
        double[,]   matrix;         // матрица ограничений
        double[]    bi;             // правая часть уравнений ограничений

        int         heightMatrix;   // высота матрицы 
        int         withMatrix;     // ширина матрицы 



        private void DrawInputsBoxes(object sender, EventArgs e)
        {
            // записываем размерность матрицы, дабы если пользователь поменял значения в ComboBox'ах наша программа не полетела на небеса)))
            withMatrix = (int)CounOfX.Value;
            heightMatrix = (int)countOfLimit.Value;

            // очищаем панели для ввода уравнений/ограничений

            funcPanel.Controls.Clear();
            limitPanel.Controls.Clear();

            // Рисуем уровнение для пользователя в зависимости от кол-ва x
            Label funcLabel = new Label()
            {
                Location = new Point(15, 10),
                Width = 55,
                Height = 15

            };

            if (maxOrMinComboBox.SelectedIndex == 0)
                funcLabel.Text = "max f(x) =";
            else
                funcLabel.Text = "min f(x) =";

            Label[] labelsX = new Label[withMatrix];
            boxesFuncX = new TextBox[withMatrix];

            for (int i = 0; i < withMatrix; i++) // Отрисовываем labelsX, boxesFuncX, boxesT
            {
                labelsX[i] = new Label()
                {
                    Text = "X" + (i + 1),
                    Location = new Point(100 + i * 70, 10),
                    Height = 15,
                    Width = 20
                };

                boxesFuncX[i] = new TextBox()
                {
                    Location = new Point(70 + i * 70, 8),
                    Height = 30,
                    Width = 30
                };


                funcPanel.Controls.Add(labelsX[i]);
                funcPanel.Controls.Add(boxesFuncX[i]);
            }
                funcPanel.Controls.Add(funcLabel);




            //Отрисовываем ограничения
           
            Label[] labels = new Label[withMatrix];
            boxesLimits = new TextBox[heightMatrix, withMatrix];
            sign = new ComboBox[heightMatrix];
            boxValOfLimit = new TextBox[heightMatrix];

            bi = new double[heightMatrix];

            for (int j = 0; j < heightMatrix; j++)
            {

                for (int i = 0; i < withMatrix; i++)
                {
                    labels[i] = new Label()
                    {
                        Text = "X" + (i + 1),
                        Location = new Point(35 + i * 70, 2+j * 40),
                        Height = 25,
                        Width = 25
                    };


                    boxesLimits[j, i] = new TextBox()
                    {
                        Location = new Point(10 + i * 70, j * 40),
                        Height = 25,
                        Width = 25
                    };

                    limitPanel.Controls.Add(labels[i]);
                    limitPanel.Controls.Add(boxesLimits[j, i]);
                }

                sign[j] = new ComboBox()
                {
                    Location = new Point(10 + withMatrix * 70, j * 40),
                    Items = { ">=", "<=", "=", },
                    Height = 25,
                    Width = 50,
                    DropDownStyle = ComboBoxStyle.DropDownList

                };
                boxValOfLimit[j] = new TextBox()
                {
                    Location = new Point(65 + withMatrix * 70, j * 40),
                    Height = 25,
                    Width = 25
                };

                limitPanel.Controls.Add(sign[j]);
                limitPanel.Controls.Add(boxValOfLimit[j]);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            func = new double[withMatrix];
            funcT = new double[withMatrix];

            bool isAllEqually = true; // если все условия ограничений - равенства, то вводить балансовые переменные не требуется

            var balnceVarArray = new List<int>();
            var balanceIPos = new List<int>();



            for (int i = 0; i < withMatrix; i++)
                try // проверка корректности ввода пользователя
                {
                    if (maxOrMinComboBox.SelectedIndex == 1) // дана функция на min 
                    {   // преобразовываем на max
                        func[i] = -1 * double.Parse(boxesFuncX[i].Text);

                    }
                    else // дана функция на max
                    {   // записываем как есть
                        func[i] = double.Parse(boxesFuncX[i].Text);
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка: в функции допускается ввод только цифр пример -3,14");
                    return;
                }



            for (int i = 0; i < heightMatrix; i++) // проверка все ли ограниения - равенства
                if (sign[i].SelectedIndex != 2)
                    isAllEqually = false;


            if (isAllEqually) // проверка все ли ограничения равенства
            {   // если да, то записываем в матрицу все ограниеченя

                matrix = new double[heightMatrix, withMatrix];

                for (int i = 0; i < heightMatrix; i++)
                    for (int j = 0; j < withMatrix; j++)
                        try // проверка корректности ввода пользователя
                        {
                            matrix[i, j] = double.Parse(boxesLimits[i, j].Text);
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка: в ограничениях допускается ввод только цифр пример -3,14");
                            return;
                        }

            }
            else
            {   // если нет, то вводим балансовые переменные

                // перебираем список ограничений и добавляем балансовые переменные в зависимости от знака 
                // так же записываем правую часть получившегося равенства 
                for (int i = 0; i < heightMatrix; i++)
                {
                    if (sign[i].SelectedIndex == 0) // больше равно | -x
                    {
                        balnceVarArray.Add(-1);
                        balanceIPos.Add(i);
                    }
                    else if (sign[i].SelectedIndex == 1) // меньше равно | +x
                    {
                        balnceVarArray.Add(1);
                        balanceIPos.Add(i);
                    }
                    else if (sign[i].SelectedIndex == -1) // проверяем выбрал ли пользователь зак для уравнения/нераввенства 
                    {
                        //сообщение об ошибке
                        MessageBox.Show("Невыбран знак равенства/неравенства!");
                        return;
                    }
                    

                }
                matrix = new double[heightMatrix, withMatrix + balnceVarArray.Count];

               

                int qurListPos = 0;
                for (int i = 0; i < heightMatrix; i++)
                {
                    for (int j = 0; j < withMatrix + balnceVarArray.Count; j++)
                    {
                        if (boxesLimits.GetLength(1) <= j)
                            if (qurListPos == j - boxesLimits.GetLength(1) && balanceIPos[qurListPos] == i)
                            // добавляем балансовые переменные в матрицу
                            {
                                matrix[i, j] = balnceVarArray[qurListPos++];
                            }
                            else
                            {
                                matrix[i, j] = 0;
                            }
                        else
                        {
                            try
                            {   // проверка корректности ввода пользователя
                                matrix[i, j] = double.Parse(boxesLimits[i, j].Text);
                            }
                            catch
                            {
                                MessageBox.Show("Ошибка: в ограничениях допускается ввод только цифр, например -3,14");
                                return;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < heightMatrix; i++)
                try
                {
                    bi[i] = double.Parse(boxValOfLimit[i].Text);
                }
                catch
                {
                    MessageBox.Show("Ошибка: в  правой части ограничения допускается ввод только цифр пример -3,14");
                    return;
                }

            Result f = new Result(func, matrix, bi);
            f.Show();
        }

    }
}
