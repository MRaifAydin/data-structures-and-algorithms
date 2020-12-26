using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veriyapilari
{
    public partial class Form1 : Form
    {
        public Node head; // head of list  
        bool nullEnd;
        int sayici;
        static readonly Random random = new Random();
        int num = random.Next(1000);
        int adet = 0;

        public class Node
        {
            public int veri;

            public Node eski;
            
            public Node yeni;                
                public Node(int d)
                {
                    veri = d;
                }
        }   
        
        void ittir(int new_data)
        {           
            Node new_node = new Node(new_data);

            Node last = head; 

            new_node.yeni = null;
                        
            if (head == null)
            {
                new_node.eski = null;
                head = new_node;
                return;
            }

            while (last.yeni != null)
                last = last.yeni;

            last.yeni = new_node;
                        
            new_node.eski = last;
        }

        public void ekle(int prevnodedata, int new_data)
        {
            Node new_node = new Node(new_data);

            Node last = head;

            if (last.yeni == null)
            {
                return;
            }
            while (last.yeni != null)
            {
                if (last.veri != prevnodedata)
                {
                    last = last.yeni;
                }
                else
                {
                    new_node.yeni = last.yeni;
                    last.yeni = new_node;
                    new_node.eski = last;
                    if (new_node.yeni == null)
                    {
                        new_node.yeni = last;
                        break;
                    }
                    else
                    {
                        new_node.yeni.eski = new_node;
                        break;
                    }
                }

            }
            if (last.yeni == null)
            {
                new_node.yeni = last.yeni;

                last.yeni = new_node;
                
                new_node.eski = last;
                
                if (new_node.yeni == null)
                {
                    new_node.yeni = last;
                }
                else
                {
                    new_node.yeni.eski = new_node;
                }
            }
        }

        public String TerstenYolla(Node node, int index)
        {
            Node last = null;

            Node end = null;
            
            end = head;
            
            int count2 = 0;

            last = node;
           
            for (int i = 0; i < index; i++)
            {
                if (last.yeni != null)
                    last = last.yeni;

            }
            while (end.yeni != null)
            {
                count2++;
                end = end.yeni;
                if (count2 >= index)
                {
                    nullEnd = false;
                    break;
                }
            }
            return last.veri.ToString();
        }
            public Form1()
        {
            InitializeComponent();
        }

        void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Graphics g = canvas.CreateGraphics();
            Pen redPen = new Pen(Color.Red, 1);
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 11);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();

            string textbox1 = textBox1.Text;
            adet = int.Parse(textbox1);



            for (int i = 1; i < adet + 1; i++)
            {
                sayici++;
                int num = random.Next(1000);
                string drawString = num.ToString();
                g.DrawString(drawString, drawFont, drawBrush, i * 57, 32, drawFormat);
                g.DrawRectangle(redPen, i * 57, 32, 32, 20);
                ittir(num);                               
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Drawing.Graphics g = canvas.CreateGraphics();
            Pen redPen = new Pen(Color.Red, 1);
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 11);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();

            g.Clear(Color.FromArgb(255, 240, 255, 240));

            string deger = textBox2.Text;
            string kontrol = textBox3.Text;
            ekle(int.Parse(kontrol), int.Parse(deger));
            sayici++;
            string donence;

            for (int i = 1; i < sayici+1; i++)
            {
                donence = TerstenYolla(head, i-1);
                g.DrawString(donence, drawFont, drawBrush, i * 57, 32, drawFormat);
                g.DrawRectangle(redPen, i * 57, 32, 32, 20);                    
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Drawing.Graphics g = canvas.CreateGraphics();
            g.Clear(Color.FromArgb(255, 240, 255, 240));
        }
    }
}
