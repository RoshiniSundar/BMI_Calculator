using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI_Calculator
{
    public partial class BMI : UserControl
    {
        IList<int> generalLineWidthRange = new List<int>();
        int currentLineWidth = 50;
        public int maxVal = 500;

        public BMI()
        {
            for (int i = 1; i < maxVal; i++)
                generalLineWidthRange.Add(i);
            DataContext = this;
        }

        public IList<int> GeneralLineWidthRange
        {
            get
            {
                return generalLineWidthRange;
            }
            set
            {
                generalLineWidthRange = value;
            }
        }

        public int CurrentLineWidth
        {
            get
            {
                return currentLineWidth;
            }
            set
            {
                currentLineWidth = value;
            }
        }
    }
}
