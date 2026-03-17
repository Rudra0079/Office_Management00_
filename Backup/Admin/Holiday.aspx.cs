using System;
using System.Web.UI.WebControls;
using System.Collections;

namespace Orient
{
    public partial class Holiday : System.Web.UI.Page
    {
        Hashtable HolidayList;
        protected void Page_Load(object sender, EventArgs e)
        {
            HolidayList = Getholiday();
            Calendar1.FirstDayOfWeek = FirstDayOfWeek.Sunday;
            Calendar1.NextPrevFormat = NextPrevFormat.FullMonth;
            Calendar1.TitleFormat = TitleFormat.MonthYear;
            Calendar1.ShowGridLines = true;
            Calendar1.DayStyle.Height = new Unit(50);
            Calendar1.DayStyle.Width = new Unit(50);
            Calendar1.DayStyle.HorizontalAlign = HorizontalAlign.Center;
            Calendar1.DayStyle.VerticalAlign = VerticalAlign.Middle;
            Calendar1.OtherMonthDayStyle.BackColor = System.Drawing.Color.AliceBlue;
            //LabelAction.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //LabelAction.Text = "Date changed to :" + Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (HolidayList[e.Day.Date.ToShortDateString()] != null)
            {
                Literal literal1 = new Literal();
                literal1.Text = "<br/>";
                e.Cell.Controls.Add(literal1);
                Label label1 = new Label();
                label1.Text = (string)HolidayList[e.Day.Date.ToShortDateString()];
                label1.Font.Size = new FontUnit(FontSize.Small);
                label1.Font.Bold = true;
                e.Cell.Controls.Add(label1);
            }

        }

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            //LabelAction.Text = "Month changed to :" + e.NewDate.ToShortDateString();
        }
        private Hashtable Getholiday()
        {
            Hashtable holiday = new Hashtable();
            holiday["1/1/2017"] = "New Year";
            holiday["1/26/2017"] = "Republic Day";
            holiday["3/13/2017"] = "Holi";
            holiday["8/15/2017"] = "Independence Day";
            holiday["9/30/2017"] = "Dussehra";
            holiday["10/2/2017"] = "Gandhi Jayanti";
            holiday["10/19/2017"] = "Diwali";
            holiday["12/25/2017"] = "Christmas Day";
            return holiday;
        }
    }
}