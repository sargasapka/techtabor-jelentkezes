using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Diagnostics;

namespace csvgraf
{
    public partial class Form1 : Form
    {
        //Variables opt = new Variables();
        //Form2 f2 = Variables.f2;
        
        /*public Options opt = new Options();
        public Form2 f2 = new Form2();*/
        List<double> dx = new List<double>() {1,2,3};
        List<double> dy1 = new List<double>() {2,4,6};
        List<double> dy2 = new List<double>() {3,6,9};
        
        public Form1()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "mailto:david.apagyi@gmail.com";
            linkLabel1.Links.Add(link);


        }
        private void totalload()
        {
            if (Variables.FilePath != "")
            {

                nincsfajl.Visible = false;
                chart1.Visible = true;
                file.Text = Path.GetFileName(Variables.FilePath);
                file.Visible = true;
                adatgyujt();

                

                /*dx.Clear();
                for (int i=0; i<dy1.Count; i++)
                {
                    dx.Add(i + 1);
                }*/

                chart1.Series.Clear();

                Series fogyasztas = new Series("Vízmennyiség");
                fogyasztas.Color = System.Drawing.Color.DarkBlue;
                fogyasztas.ChartType = SeriesChartType.Spline;
                fogyasztas.YAxisType = AxisType.Primary;
                datatoseries(chart1, dx, dy1, fogyasztas);
                chart1.Series.Add(fogyasztas);

                

                Series aramerosseg = new Series("Áramerősség");
                aramerosseg.ChartType = SeriesChartType.Spline;
                aramerosseg.YAxisType = AxisType.Secondary;
                datatoseries(chart1, dx, dy2, aramerosseg);
                chart1.Series.Add(aramerosseg);
                //Refresh(chart1, dx, dy2, aramerosseg);
                chart1.ChartAreas["ChartArea1"].AxisX.Title = "Idő";
                chart1.ChartAreas["ChartArea1"].AxisY.Title = "Vízmennyiség";
                chart1.ChartAreas["ChartArea1"].AxisY2.Title = "Áramerősség";
                /*chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 45;
                chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 45;*/
            }
            else
            {
                Console.WriteLine("Hiba: Nincs fájl megadva!");
            }
        }
        private void datatoseries(Chart givenchart, List<double> xtengely, List<double> ytengely, Series sorozat)
        {
            for (int i=0; i< xtengely.Count; i++)
            {
                sorozat.Points.AddXY((xtengely[i]), ytengely[i]);
            }
        }

        private void adatgyujt()
        {
            if (!File.Exists(Variables.FilePath))
            {

            }
            else {
                using (var fs = File.OpenRead(Variables.FilePath))
                using (var reader = new StreamReader(fs))
                {
                    dx.Clear();
                    dy1.Clear();
                    dy2.Clear();
                    string[] lines = File.ReadAllLines(Variables.FilePath);
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        /*Console.WriteLine("1");var values1 = line.Trim(new char[] { '"', ' ' });Console.WriteLine("2");var values2 = values1.Split('A');//var values = line.Split(';');Console.WriteLine(values2[0]);*/
                        var values = line.Replace("\"", string.Empty).Replace(".",",").Split(new string[] { Variables.key }, StringSplitOptions.None)[1].Split(';');
                        //Console.WriteLine(values[0] + values[1] + values[2]);
                        double x;
                        double y;
                        double z;
                        double.TryParse(values[0], out x);
                        double.TryParse(values[1], out y);
                        double.TryParse(values[2], out z);
                        dx.Add(x);
                        dy1.Add(y);
                        dy2.Add(z);
                        //Console.WriteLine("X" + i + "=" + x + ", Y" + i + "=" + y + ", Z" + i + "=" + z);
                    }
                    //while (!reader.EndOfStream) {}

                }
            }
        }
        private void openfile(object sender, EventArgs e)
        {
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            myOpenFileDialog.Filter = "CSV fájlok|*.csv";

            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Variables.FilePath = myOpenFileDialog.FileName;
                totalload();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            totalload();
        }

        private void emailme(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutform = new AboutBox1();
            aboutform.ShowDialog();
        }
        private void beállításokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Variables.F2.ShowDialog();
        }
    }
}