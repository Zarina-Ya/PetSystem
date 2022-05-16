using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetSystem
{
    public partial class ExpertSystem : Form
    {
        private String[] _question;
        private int _index = 0;

        private Tuple<String, int>[] _variables;

        private Tuple<int, int>[] _vertexes;

        private List<Tuple<String, int>> _way = new List<Tuple<String, int>>();
        List<Tuple<String, int>> _BaseWay = new List<Tuple<String, int>>();
        List<Tuple<String, String>> _Result = new List<Tuple<String, String>>();

        enum CHARACTER
        {
            /// <summary>
            /// преданность
            /// ласка
            /// внимание
            /// </summary>
            devotion, //0
            affection,//1
            attention //2
        }

        enum HAIR
        {
            Long,//0
            Short//1
        }

        enum RENT
        {
            hotel,//0
            relatives//1
        }

        enum WORK
        {
            atNight,//0
            duringTheDay//1
        }

       public ExpertSystem()   
        {
            InitializeComponent();

            DopButton.Visible = false;
            ReadFile();
            KnowledgeBase();
            UpdateQuestion();

        }

       private void ExpertSystem_Load(object sender, EventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }

       private void UpdateQuestion()
        {
            if (_index < _question.Length)
            {
                if(_index == 12 || _index == 22 || _index == 24 || _index == 10)
                {
                    UpdateButton();
                }
                else
                {
                    FirstQuestion.Text = "Да";
                    NegativeAnswer.Text = "Нет";
                    DopButton.Visible = false;
                }
                Question.Text = _question[_index];
                //_index++;
               
            }
            else
            {
                Question.Text = "The end";
                FirstQuestion.Visible = false;
                NegativeAnswer.Visible = false;
            }


        }

       private void UpdateButton()
        {
            switch (_index)
            {
                case 10:
                    FirstQuestion.Text = "Короткие";
                    NegativeAnswer.Text = "Длинные";
                    break;
                case 12:
                    FirstQuestion.Text = "Днем";
                    NegativeAnswer.Text = "Ночью";
                    break;
                case 22:
                    DopButton.Visible = true;
                    FirstQuestion.Text = "Ласка";
                    NegativeAnswer.Text = "Преданность";
                    DopButton.Text = "Внимание";
                    break;
                case 24:
                    FirstQuestion.Text = "Родственники";
                    NegativeAnswer.Text = "Отель";
                    break;
                default:
                    break;
            }
        }

       private void ReadFile()
        {
            int count = 0;
            string[] lines = File.ReadAllLines("C:\\Users\\zarin\\source\\repos\\PetSystem\\PetSystem\\Question.txt", Encoding.GetEncoding(1251));
            _question = new String[lines.Length];
            _vertexes = new Tuple<int, int>[lines.Length];
            _variables = new Tuple<string, int>[lines.Length];

            foreach (string s in lines)
            {
                //_question[count] = s;
                TrimLines(count, s);
                count++;
            }
        }
       private void TrimLines(int count, String s)
       {
            string[] words = s.Split(':');
            _variables[count] = Tuple.Create(words[0],-1);
            _question[count] = words[1];
            if (words[2].Length > 2)
            {
                string[] num = words[2].Split(',');
                _vertexes[count] = Tuple.Create(int.Parse(num[0]), int.Parse(num[1]));
            }
            else
            {
                _vertexes[count] = Tuple.Create(int.Parse(words[2]), -1);
            }



        }


       private void FirstQuestion_Click(object sender, EventArgs e)// положительный ответ
        {

            _variables[_index ] = Tuple.Create(_variables[_index].Item1, 1);
            _way.Add(_variables[_index ]);

            CheckWay();
            UpdateQuestion();
        }

       private void NegativeAnswer_Click(object sender, EventArgs e)// отрицательнвй ответ
        {


            //_variables[_index - 1] = Tuple.Create(_variables[_index - 1].Item1, 0);
            //_way.Add(_variables[_index - 1]);
            _variables[_index ] = Tuple.Create(_variables[_index].Item1, 0);
            _way.Add(_variables[_index ]);

            CheckWay();
            UpdateQuestion();
        }

       private void KnowledgeBase()
        {
            
            string[] lines = File.ReadAllLines("C:\\Users\\zarin\\source\\repos\\PetSystem\\PetSystem\\knowbase.txt", Encoding.GetEncoding(1251));
            foreach (string s in lines)
            {
                string[] words = s.Split(';');
                foreach (string w in words)
                {
                    string[] words_2 = w.Split('=');
                    _BaseWay.Add(Tuple.Create(words_2[0], int.Parse(words_2[1])));
                }
                _BaseWay.Add(Tuple.Create("NULL", -1));
            }

        }
       private void DopButton_Click(object sender, EventArgs e)
        {
            //_vertexes[_index - 1] = Tuple.Create(_vertexes[_index - 1].Item1, 2);
            //_way.Add(_vertexes[_index - 1]);
            _variables[_index ] = Tuple.Create(_variables[_index].Item1, 2);
            _way.Add(_variables[_index ]);
            DopButton.Visible = false;
            CheckWay();
            UpdateQuestion();
        }


        

        void DELETEALL86 (int index)
        {
            List<Tuple<String, int>> tmp = new List<Tuple<String, int>>();
            int count = 0;
            for ( int i = 0 ; i < index ; i++)
            {
                tmp.Add(_BaseWay[i]);

            }
            _BaseWay.Clear();
            _BaseWay = tmp;
        }

        void DELETEALLundo86()
        {
            List<Tuple<String, int>> tmp = new List<Tuple<String, int>>();
            int count = 0;
            for (int i = 86; i < 183; i++)
            {
                tmp.Add(_BaseWay[i]);

            }
            _BaseWay.Clear();
            _BaseWay = tmp;
        }


        private void CheckWay()
        {
            Tuple<String, int> _nextpoint;
            if (_way.Count == 1)
            {
                if (_way[0].Item2 == 0)
                {
                    DELETEALL86(86);
                }
                else
                {
                    DELETEALLundo86();
                }

            }
            List<Tuple<String, int>> tmp = new List<Tuple<String, int>>();

            for(int i = 0; i < _way.Count ; i++)
            {
                for( int k = 0; k < _BaseWay.Count; k++)
                {
                    if (_BaseWay[k].Item1 == _way[i].Item1 && _BaseWay[k].Item2 == _way[i].Item2)
                    {
                        for (int j = k + 1; j < _BaseWay.Count; j++)
                        {
                            if (_BaseWay[j].Item1 == "NULL") break;
                            else tmp.Add(_BaseWay[j]);
                           
                        }
                        tmp.Add(Tuple.Create("NULL", -1));
                    }
                }
               
            }
            if (tmp.Count == 0)
            {
                tmp.Add(Tuple.Create("NULL", -1));
                _BaseWay.Clear();
                _BaseWay = tmp;
            }
            else
            {
                _BaseWay.Clear();
                _BaseWay = tmp;
            }
           
            if(_BaseWay[0].Item1 != "NULL" )
            {
                _nextpoint = Tuple.Create(_BaseWay[0].Item1, -1);
                CheckVar(_nextpoint);
            }
            else AddResult();



        }


        private void AddResult()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\zarin\\source\\repos\\PetSystem\\PetSystem\\knowbase2.txt", Encoding.GetEncoding(1251));
            foreach (string s in lines)
            {
                string[] words = s.Split('=');
                
                   _Result.Add(Tuple.Create(words[0], (words[1])));
                
                
            }
            _BaseWay.Clear();
            int count = 0;
            string[] lines2 = File.ReadAllLines("C:\\Users\\zarin\\source\\repos\\PetSystem\\PetSystem\\knowbase.txt", Encoding.GetEncoding(1251));
            foreach (string s in lines2)
            {
               
                string[] words = s.Split(';');
                
                foreach (string w in words)
                {
                    string[] words_2 = w.Split('=');
                    _BaseWay.Add(Tuple.Create(words_2[0], int.Parse(words_2[1])));
                    
                }
                count++;

                if (_way.Count == _BaseWay.Count)
                {
                    for(int i =0 ; i < _way.Count; i++)
                    {
                        if(_way[i].Item1 == _BaseWay[i].Item1 && _way[i].Item2 == _BaseWay[i].Item2)
                        {
                            if(i == _way.Count - 1)
                            {
                                

                                Form resultForm = new ResultForm(_Result[count - 1].Item2);
                                resultForm.ShowDialog();
                                Application.Exit();
                                break;
                            }
                        }
                        else
                        {
                            _BaseWay.Clear();
                            break;
                        }
                    }
                }
                else
                {
                    _BaseWay.Clear();

                }
            }
        }

        private void CheckVar(Tuple<String, int> _nextpoint)
        {
            int count = 0;
            foreach(var var in _variables)
            {
                if(var.Item1 == _nextpoint.Item1)
                {
                    _index = count;
                    break;
                }
                //if(count == 22)
                //{
                //    _index = count;
                //    break;
                //}
                count++;
            }
        }
    }
}
