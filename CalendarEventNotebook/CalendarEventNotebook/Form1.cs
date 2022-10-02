using System.Drawing.Imaging;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int sayar = 0;
        string[] date=new string[100];
        string[] eventname = new string[100];
        string[] eventdesc = new string[100];
        string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public Form1()
        {
            InitializeComponent();
            monthCalendar1.SetDate(monthCalendar1.TodayDate);
        }
        public void adder(bool forbutton) {
            if (forbutton) {
                date[sayar] = monthCalendar1.SelectionRange.Start.ToShortDateString(); 
                eventdesc[sayar] = EventDesc.Text.ToString();
                eventname[sayar] = EventName.Text.ToString();

                string indexstr = date[sayar] + Environment.NewLine + eventname[sayar] + Environment.NewLine + eventdesc[sayar] + Environment.NewLine;

                textBox1.Text = indexstr + textBox1.Text;
                sayar++;
            }
            else
            {
                
            }
           

        }


        private void button1_Click(object sender, EventArgs e)
        {
            adder(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {//writer
            StreamWriter writer = new StreamWriter(filepath+"/savepath.txt",false);//date-name-desc/0-1-2*3-4-5
            for(int i = 0; i< date.Length; i++)
            {
                writer.Write(date[i] + Environment.NewLine + eventname[i] + Environment.NewLine + eventdesc[i]+Environment.NewLine);
            }
            writer.Close();
        


        }

        private void button3_Click(object sender, EventArgs e)
        {//loader
            StreamReader reader =new StreamReader(filepath + "/savepath.txt");//date-name-desc/0-1-2*3-4-5
            for (int i = 0; i < 100; i++)
            {
                var pattern = @"(?<=_)(.*?)(?=-1)";
                var input = reader.ReadLine();
                if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
                {
                    var dateStr = System.Text.RegularExpressions.Regex.Match(input, pattern);
                    var datex = DateTime.ParseExact(dateStr.Value, "MM-dd-yyyy", null);
                    date[i] = datex.ToString();
                }
              
                eventname[i] = reader.ReadLine();
                eventdesc[i] = reader.ReadLine();

            }
            reader.Close();


            for (int i = 0; i < 100; i++)
            {
                if (eventname[i] == null || eventname[i] == "")
                {

                }
                else
                {
                    string indexstr = date[i] + Environment.NewLine + eventname[i] + Environment.NewLine + eventdesc[i] + Environment.NewLine;

                    textBox1.Text = indexstr + textBox1.Text;
                    sayar++;
                }
            }

        }

     
        private void button4_Click(object sender, EventArgs e)
        {
          
            textBox1.Text = null;
        }
    }
}