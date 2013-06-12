using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LoanPayoff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PayoffModel()
        {
            const byte weeks = 29;
            const byte fallDue = 7;
            const double startAmount = 1528.29 + 6440.29;
            const short endAmount = 5500;
            const short fallAmount = 1500;
            const short weeklyExpenses = 80;
            const int monthyPayoff = 1184;
            const int wages = 1080;

            double[] weeklyBalance = new double[weeks];
            var payoffAmount = 8282.56 ;

            var balance = startAmount;

            for(int week=1;week<weeks;week++)
            {
                balance -= weeklyExpenses;

                if (week % 4 == 0)
                {
                    balance -= monthyPayoff;
                    payoffAmount -= monthyPayoff;

                    if (payoffAmount <= 0)
                        break;
                }

                if (week == fallDue)
                    balance -= fallAmount;

                if (week == weeks - 8)
                    balance -= 1500;

                if (week % 2 == 0)
                    balance += wages;

                chart1.Series["Series1"].Points.AddXY(week, balance);
                weeklyBalance[week] = balance;
            }
            balance -= 5500;
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);

            // ...
        }
    }
}
