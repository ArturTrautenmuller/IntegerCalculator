using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace IntegerCalculator
{
    public static class Integer
    {
        public static double Solve(string exp,List<string> variables, List<double> begin, List<double> end, double step)
        {
            double sum = 0;
            if(variables.Count == 1)
            {
                for(double i = begin[0]; i <= end[0]; i += step)
                {
                    string vExp = exp.Replace(variables[0],i.ToString().Replace(",","."));
                    sum += Convert.ToDouble(new DataTable().Compute(vExp, null)) * step;
                }

                return sum;
            }

            else
            {
                List<string> nVariables = RemoveFirst(variables.Cast<object>().ToList()).Cast<string>().ToList();
                List<double> nBegin = RemoveFirst(begin.Cast<object>().ToList()).Cast<double>().ToList();
                List<double> nEnd = RemoveFirst(end.Cast<object>().ToList()).Cast<double>().ToList();

                for (double i = begin[0]; i <= end[0]; i += step)
                {
                    string vExp = exp.Replace(variables[0], i.ToString().Replace(",","."));
                    sum += Solve(vExp,nVariables ,nBegin,nEnd,step) * step;
                }

                return sum;

            }



            
        }

        public static List<object> RemoveFirst(List<object> list)
        {
            List<object> newList = new List<object>();
            for(int i = 1; i < list.Count;i++)
            {
                newList.Add(list[i]);
            }

            return newList;
        }
    }
}
