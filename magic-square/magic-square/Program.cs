using System;
using System.Collections.Generic;

namespace magic_square
{
    class Program
    {
        public static int hasil(int[,]temp,int[,]mat,int sum)
        {
            temp[1, 1] = 5;
            for(int i=0;i<3;i++)
            {
                for (int j = 0; j < 3; j++)
                    sum += (int)Math.Abs(mat[i, j] - temp[i, j]);
            }
            return sum;
        }
        static List<int> arahMatriksCLockwise (int[,]mat, int[] matAcuan, List<int>listSum)
        {
            int[,] temp = (int[,])mat.Clone();

            //1
            int count = 2;
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                temp[0, i] = matAcuan[i];
                temp[i, 2] = matAcuan[i + 3];
                temp[2, count] = matAcuan[i + 6];
                temp[count, 0] = matAcuan[i + 9];
                count -= 1;
            }
            sum = hasil(temp, mat, sum);
            listSum.Add(sum);

            //2
            temp = (int[,])mat.Clone();
            count = 2;
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                temp[i, 2] = matAcuan[i];
                temp[2, count] = matAcuan[i + 3];
                temp[count, 0] = matAcuan[i + 6];
                temp[0, i] = matAcuan[i + 9];
                count -= 1;
            }
            sum = hasil(temp, mat, sum);
            listSum.Add(sum);

            //3
            temp = (int[,])mat.Clone();
            count = 2;
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                temp[2, count] = matAcuan[i];
                temp[count, 0] = matAcuan[i + 3];
                temp[0, i] = matAcuan[i + 6];
                temp[i, 2] = matAcuan[i + 9];
                count -= 1;
            }
            sum = hasil(temp, mat, sum);
            listSum.Add(sum);

            //4
            temp = (int[,])mat.Clone();
            count = 2;
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                temp[count, 0] = matAcuan[i];
                temp[0, i] = matAcuan[i + 3];
                temp[i, 2] = matAcuan[i + 6];
                temp[2, count] = matAcuan[i + 9];
                count -= 1;
            }
            sum = hasil(temp, mat, sum);
            listSum.Add(sum);

            return listSum;
        }
        static List<int> arahMatriksCountercLockwise(int[,] mat, int[] matAcuan, List<int> listSum)
        {
            //1
            int[,] temp = (int[,])mat.Clone();
            int count = 2;
            int sum = 0;
            for (int i=0;i<3;i++)
            {
                temp[0, count] = matAcuan[i];
                temp[i, 0] = matAcuan[i + 3];
                temp[2, i] = matAcuan[i + 6];
                temp[count, 2] = matAcuan[i + 9];
                count -= 1;
            }
            sum = hasil(temp, mat, sum);
            listSum.Add(sum);

            //2
            temp = (int[,])mat.Clone();
            count = 2;
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                temp[i, 0] = matAcuan[i];
                temp[2, i] = matAcuan[i + 3];
                temp[count, 2] = matAcuan[i + 6];
                temp[0, count] = matAcuan[i+9];
                count -= 1;
            }
            sum = hasil(temp, mat, sum);
            listSum.Add(sum);

            //3
            temp = (int[,])mat.Clone();
            count = 2;
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                temp[2, i] = matAcuan[i];
                temp[count, 2] = matAcuan[i+3];
                temp[0, count] = matAcuan[i + 6];
                temp[i, 0] = matAcuan[i+9];
                count -= 1;
            }
            sum = hasil(temp, mat, sum);
            listSum.Add(sum);

            //4
            temp = (int[,])mat.Clone();
            count = 2;
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                temp[count, 2] = matAcuan[i];
                temp[0, count] = matAcuan[i + 3];
                temp[i, 0] = matAcuan[i + 6];
                temp[2, i] = matAcuan[i+9];
                count -= 1;
            }
            sum = hasil(temp, mat, sum);
            listSum.Add(sum);

            return listSum;
        }
        static int getMin (List<int> hasilSum, int min)
        {
            for (int i = 0; i < hasilSum.Count; i++)
                if (hasilSum[i] < min)
                    min = hasilSum[i];
            return min;
        }
        static void Main(string[] args)
        {
            int[] acuanClockwise = { 2, 9, 4, 4, 3, 8, 8, 1, 6, 6, 7, 2 };
            int[] acuanCounterclockwise = { 4, 9, 2, 2, 7, 6, 6, 1, 8, 8, 3, 4 };

            int[,] mat = {{4,8,2 }, {4,5,7 }, { 6,1,6 } };
            int[,] temp = (int[,])mat.Clone();

            //clockwise clockwise
            List<int> hasilClockwise = new List<int>();
            hasilClockwise = arahMatriksCLockwise(mat, acuanClockwise, hasilClockwise);

            //clockwise counter_clockwise
            List<int> hasilClockwiseCampur = new List<int>();
            hasilClockwiseCampur = arahMatriksCLockwise(mat, acuanCounterclockwise, hasilClockwiseCampur);

            //counter_clockwise counter_clockwise
            List<int> hasilCounterClockwise = new List<int>();
            hasilCounterClockwise = arahMatriksCountercLockwise(mat, acuanCounterclockwise, hasilCounterClockwise);

            //counter_clockwise clockwise
            List<int> hasilCounterClockwiseCampur = new List<int>();
            hasilCounterClockwiseCampur = arahMatriksCountercLockwise(mat, acuanClockwise, hasilCounterClockwiseCampur);


            //get min
            int min = 99999999;

            //1
            min = getMin(hasilClockwise, min);
            //2
            min = getMin(hasilClockwiseCampur, min);
            //3
            min = getMin(hasilCounterClockwise, min);
            //4
            min = getMin(hasilCounterClockwiseCampur, min);

            Console.WriteLine(min);

        }
    }
}
