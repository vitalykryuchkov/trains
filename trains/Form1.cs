using System.IO;
using System.Text.RegularExpressions;

namespace trains
{
    public partial class Form1 : Form
    {
        string path = "tr.txt";
        public string[] place = { "Brooklyn", "London", "Tomsk", "Berlin", "Riga" };
        public Form1()
        {
            InitializeComponent();
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) //правое окно
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //левое окно
        {

        }
        private void button1_Click(object sender, EventArgs e) //сгенерировать
        {
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine($"Destination: {place[random.Next(0, 5)]}, train number: {random.Next(100, 1000)}, departure time: {random.Next(0, 24)}:{random.Next(0, 60)}:{random.Next(0, 60)}");
                }
            }
            using (StreamReader reader = new StreamReader(path))
            {
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        listBox1.Items.Add(line);
                    }
                    textBox1.Text = "The generation was successful";
                }
                else
                {
                    textBox1.Text = "The generation was not succsessful ";
                }
            }
        }
        private void button2_Click(object sender, EventArgs e) //Отсортировать
        {
            List<string> sortedItems = new List<string>();
            foreach (string item in listBox1.Items)
            {
                sortedItems.Add(item);
            }
            sortedItems.Sort((x, y) =>
            {
                int trainNumberX = int.Parse(Regex.Match(x, @"\d+").Value);
                int trainNumberY = int.Parse(Regex.Match(y, @"\d+").Value);
                return trainNumberX.CompareTo(trainNumberY);
            });
            listBox2.Items.Clear();
            foreach (string item in sortedItems)
            {
                listBox2.Items.Add(item);
            }
            textBox1.Text = "The sorting was successful";
        }
        private void button3_Click(object sender, EventArgs e) //Очистить
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }
        private void textBox2_TextChanged(object sender, EventArgs e) //ввод номера поезда
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e) //вывод текста об операциях
        {

        }
        private void button4_Click(object sender, EventArgs e) //поиск поезда
        {
            string[] text = File.ReadAllLines(path);
            foreach (string item in text)
            {
                if (item.Contains(textBox2.Text))
                {
                    listBox2.Items.Add((string)item);
                }
            }
        }
    }
}