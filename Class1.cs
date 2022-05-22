using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAY_Kurs_
{

    static class Class1
    {
        public static int n;
        public static double eps;

    }
    public class ZEIDEL
    {

        
        public int[,] a_a;// матрица а, коэффициенты при х
        public int[] b_b;//матрица в, значения 
        public double[] korni;//корни
        public bool diagonali;
        public double sum, XI, raznitha=10;
        public int k;
        
        //Form2 fm2; //= new Form2();
        public ZEIDEL(int[,] a_a, int[] b_b, int n, double[] korni  )
        {  
            this.a_a = a_a;
            this.b_b = b_b; 
            this.korni = korni;
            Class1.n = n;
        }
        public void RESHENIE()
        {
            k = 0;
            while (raznitha >= Class1.eps )
            {
                k = k + 1;
                for (int i = 0; i < Class1.n; i++)
                {
                    sum = 0;
                    for (int j = 0; j < Class1.n; j++)
                    {
                        if (i!= j)
                        {
                            sum += a_a[i,j] * korni[j];
                        }

                    }
                    XI = (b_b[i] - sum) / a_a[i, i];
                    raznitha = Math.Abs(XI - korni[i]);
                    korni[i] = XI;
                    
                }
            }
        }
        public bool Diagonali()
        {
            for (int i = 0; i <Class1.n;i++)
            { double sum = 0;
                for ( int j=0;j<Class1.n;j++)
                {
                    if (i != j)
                    {
                        sum += Math.Abs(a_a[j,i]);
                    }
                }
                if (Math.Abs( a_a[i, i])>sum)
                {
                    diagonali = true;
                    break;
                }
                else
                {
                    diagonali = false;
                }
            }
            return diagonali;
           
        }

    }

}
