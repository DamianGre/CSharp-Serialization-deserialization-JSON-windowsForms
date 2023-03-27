using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //obs³uga plików
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace DamianGrembocki_Zad2
{
    
    public partial class Form1 : Form
    {
        public class Person
        {
            public string name = "";
            public string age = "";
            public string weight = "";

            public override string ToString()
            {
                return name + " " + age + " " + weight + " ";
            }
        }

        Person person = new Person();

        public Form1()
        {
            InitializeComponent();                
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/pl-pl/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-6.0
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                label10.Text = openFileDialog1.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {                    
                    string person4 = reader.ReadToEnd(); 
                    Person person5 =JsonConvert.DeserializeObject<Person>(person4);
                    
                    textBox4.Text = person5.name;
                    textBox5.Text = person5.age;
                    textBox6.Text = person5.weight;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            var person1 = new Person
            {
                name = person.name,
                age = person.age,
                weight = person.weight
            };

            string jsonString = JsonConvert.SerializeObject(person1);

            //https://docs.microsoft.com/pl-pl/dotnet/api/system.windows.forms.savefiledialog?view=windowsdesktop-6.0
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, jsonString);
                label11.Text = saveFileDialog1.FileName;
            }
        }       

        private void button3_Click(object sender, EventArgs e)
        {            
            person.name = textBox1.Text;
            person.age = textBox2.Text;
            person.weight = textBox3.Text;
            textBox4.Text = person.name;
            textBox5.Text = person.age;
            textBox6.Text = person.weight;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }      
    }
}