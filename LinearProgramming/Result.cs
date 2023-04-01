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
    public partial class Result : Form
    {
        public Result(double[] Func, double[,] matrix, double[] bi)
        {
            InitializeComponent();

            List<int> iUnitMatrix = new List<int>();
            List<int> jUnitMatrix = new List<int>();
            double[] DeltaJT;
            double[] DeltaJM;

            bool IsQurUnit = true; // переменная отвечает за проверку: содержит ли текущий столбец только одну 1
                                   //для получения единичной подматрицы
                                   // так же если единичной подматрицы нет добавляем исскуственные переменные
            int m = matrix.GetLength(1);
            int n = matrix.GetLength(0);

            int countOfY = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        // перебераем остальные элементы стобца и проверяем равны ли они 0
                        for (int ii = 0; ii < n; ii++)
                            if (matrix[ii, j] != 0 && ii != i)
                                IsQurUnit = false;

                        if (IsQurUnit)
                        {
                            iUnitMatrix.Add(i);
                            jUnitMatrix.Add(j);
                            break;
                        }
                        else if (j != m - 1) //проверка не является ли это послдним столбцом, если нет, то сбрасываем переменную отвечающую за это
                            IsQurUnit = true;
                        else //если нет столбца единичной подматрицы с 1 в текуще строки, то вводим исскуственную переменную
                        {
                            IsQurUnit = true; //присваеваем значение по умолчанию
                            double[,] newMatrix = new double[n, m + 1];
                            for (int ii = 0; ii < n; ii++)
                                for (int jj = 0; jj <= m; jj++)
                                    if (jj < m) //записываем исходную матрицу
                                        newMatrix[ii, jj] = matrix[ii, jj];
                                    else if (ii == i) // если текщая строка, то добовляем в исскуственный столбец 1
                                    {
                                        newMatrix[ii, jj] = 1;
                                        countOfY++;
                                    }
                                    else // в остальные строки, записываем 0
                                        newMatrix[ii, jj] = 0;

                            matrix = newMatrix;
                            m = matrix.GetLength(1);
                        }

                    }
                    else if (j == m - 1) // если во всей  строке нет 1, то вводим исскуственную переменную
                    {
                        double[,] newMatrix = new double[n, m + 1];
                        for (int ii = 0; ii < n; ii++)
                            for (int jj = 0; jj <= m; jj++)
                                if (jj < m) //записываем исходную матрицу
                                    newMatrix[ii, jj] = matrix[ii, jj];
                                else if (ii == i) // если текщая строка, то добовляем в исскуственный столбец 1
                                {
                                    newMatrix[ii, jj] = 1;
                                    countOfY++;
                                }
                                else
                                    newMatrix[ii, jj] = 0;

                        matrix = newMatrix;
                        m = matrix.GetLength(1);
                    }
                }
            }
            string[] valOfC = new string[matrix.GetLength(1)];

            double[] funcM = new double[matrix.GetLength(1)]; // Коэфиценты функции М'чек
            double[] funcX = new double[matrix.GetLength(1)]; // Коэфиценты функции Х'ов


            for (int i = 0; i < valOfC.Length; i++)
            {
                if (i < Func.Length)
                {
                    valOfC[i] = Func[i].ToString();
                    funcM[i] = 0;
                    funcX[i] = Func[i];
                }
                else
                { 
                    funcM[i] = -1;
                    funcX[i] = 0; //?
                    valOfC[i] = "-1M";

                }
            }


            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "X" + (i + 1),
                    HeaderText = "X" + (i + 1) + " (" + valOfC[i] + ")",
                    Width = 50
                });
            }
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "tet",
                HeaderText = "θi",
                Width = 50
            });

            DeltaJT = new double[matrix.GetLength(1)];
            DeltaJM = new double[matrix.GetLength(1)];
            int qurentCountOfY = countOfY;
            int tableNum = 0;
            int qurrentRow = 0;
            int[] basis = new int[matrix.GetLength(0)]; // набор индексов базиса
            for (int i = 0; i < basis.Length; i++)
                basis[i] = jUnitMatrix[i]; // задаем базисы, взятые по единичной матрице

            while (true)
            {
                int shiftI = qurrentRow; // задает ввертикальный сдвиг для корректной подстановки данных в dataGridView1
                int shiftJ = 4;         // задает горизонталный сдвиг для корректной подстановки данных в dataGridView1

                for (int i = 0; i < matrix.GetLength(0); i++) // вероятно вывод данных в таблицу
                {
                    dataGridView1.Rows.Add();

                    dataGridView1.Rows[i + shiftI].Cells[0].Value = tableNum; //Записываем номер текущей таблицы
                    dataGridView1.Rows[i + shiftI].Cells[1].Value = valOfC[basis[i]]; // значения базисов
                    dataGridView1.Rows[i + shiftI].Cells[2].Value = "X" + (basis[i] + 1);
                    dataGridView1.Rows[i + shiftI].Cells[3].Value = bi[i];

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        dataGridView1.Rows[i + shiftI].Cells[j + shiftJ].Value = matrix[i, j];
                    }

                    qurrentRow++;
                }
                dataGridView1.Rows.Add();


                double bSum = 0;
                double mSum = 0;

                for (int i = 0; i < matrix.GetLength(0); i++) // подсчет deltaB = Ci(ci/j)[i]*Bi[i]
                {
                    mSum += funcM[basis[i]] * bi[i];
                    bSum += funcX[basis[i]] * bi[i];
                }


                // корректный вывод deltaJ в bi столбце
                dataGridView1.Rows[qurrentRow].Cells[3].Value = "";
                if (bSum != 0)
                    dataGridView1.Rows[qurrentRow].Cells[3].Value += bSum.ToString();
                else if (mSum != 0)
                    if (mSum > 0)
                        dataGridView1.Rows[qurrentRow].Cells[3].Value += "+" + mSum + "M";
                    else
                        dataGridView1.Rows[qurrentRow].Cells[3].Value += mSum + "M";
                else
                    dataGridView1.Rows[qurrentRow].Cells[3].Value = "0";


                int deltaJMaxJ = 0;
                double deltaJMaxX = 0;
                double deltaJMaxM = 0;

                double[] deltaJX = new double[matrix.GetLength(1)];
                double[] deltaJM = new double[matrix.GetLength(1)];



                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    bSum = 0;
                    mSum = 0;

                    for (int i = 0; i < matrix.GetLength(0); i++) //подсчет суммы (Ci/j*Xij) 
                    {
                        mSum += funcM[basis[i]] * matrix[i, j];
                        bSum += funcX[basis[i]] * matrix[i, j];


                    }


                    //подсчет дельта j
                    double mRes = funcM[j] - mSum;
                    double xRes = funcX[j] - bSum;

                    deltaJM[j] = mRes;
                    deltaJX[j] = xRes;


                    // корректный вывод deltaJ в столбцах с X'ми
                    if (xRes != 0)
                        dataGridView1.Rows[qurrentRow].Cells[4 + j].Value += xRes.ToString();
                    if (mRes != 0)
                        if (mRes > 0)
                            dataGridView1.Rows[qurrentRow].Cells[4 + j].Value += "+" + mRes + "M";
                        else
                            dataGridView1.Rows[qurrentRow].Cells[4 + j].Value += mRes + "M";

                    if (deltaJMaxM < mRes)
                    {
                        deltaJMaxM = mRes;
                        deltaJMaxX = xRes;
                        deltaJMaxJ = j;
                    }
                    else if (deltaJMaxM == mRes)
                    {
                        if (deltaJMaxX < xRes)
                        {
                            deltaJMaxX = xRes;
                            deltaJMaxJ = j;
                        }
                        else if (deltaJMaxX == xRes)
                        {
                                deltaJMaxJ = j;
                        }
                    }
                }

                qurrentRow++;

                bool end = true;

                for (int i = 0; i < deltaJX.Length; i++) // проверка все ли дельта j <= 0
                    if (deltaJX[i] > 0 ||  deltaJM[i] > 0)
                        end = false;

                if (end) // заканчиваем алгоритм
                    break;


                double minTet = Int32.MaxValue;
                int minTetI = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                    if (matrix[i, deltaJMaxJ] > 0)
                    {
                        double tet = bi[i] / matrix[i, deltaJMaxJ];
                        dataGridView1.Rows[qurrentRow - matrix.GetLength(0) + i - 1].Cells[matrix.GetLength(1) + 4 + countOfY - qurentCountOfY].Value = tet;
                        // х = кол-во х + кол-во столбцов перед Х ами т.е. 4
                        if (tet < minTet)
                        {
                            minTet = tet;
                            minTetI = i;
                        }
                    }
                    else
                        dataGridView1.Rows[qurrentRow - matrix.GetLength(0) + i - 1].Cells[matrix.GetLength(1) + 4 + countOfY - qurentCountOfY].Value = "---";


                double[,] temporaryMatrix = new double[matrix.GetLength(0), matrix.GetLength(1) - 1];
                if (qurentCountOfY != 0)
                {
                    qurentCountOfY--;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                        for (int j = 0; j < temporaryMatrix.GetLength(1); j++)
                            if (basis[minTetI] != j)
                                temporaryMatrix[i, j] = matrix[i, j];

                    matrix = temporaryMatrix;
                }


                basis[minTetI] = deltaJMaxJ; // заменяем базис на другой



                bi[minTetI] = bi[minTetI] / matrix[minTetI, deltaJMaxJ];


                for (int i = 0; i < matrix.GetLength(0); i++) // подсчет Bi
                    if (i != minTetI)
                        bi[i] = bi[i] - bi[minTetI] * matrix[i, deltaJMaxJ];



                double mainEl = matrix[minTetI, deltaJMaxJ];
                for (int j = 0; j < matrix.GetLength(1); j++) //делем главную строку на X главной строки и главного столбца
                {
                    matrix[minTetI, j] = matrix[minTetI, j] / mainEl;
                }

                for (int i = 0; i < basis.Length; i++) // считаем оставшиеся строки матрицы
                {
                    if (i != minTetI)
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            double asd = double.Parse(dataGridView1.Rows[qurrentRow - matrix.GetLength(0) + i - 1].Cells[4 + deltaJMaxJ].Value.ToString());
                            matrix[i, j] = matrix[i, j] - matrix[minTetI, j] * asd;
                        }
                }

                tableNum++;
                if (tableNum > 5)
                    break;
            }




        }
    }
}
