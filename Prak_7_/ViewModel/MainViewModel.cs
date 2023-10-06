using Prak_7_.ViewModel.Helpers;
using System;
using System.Data;
using System.Windows;
using System.Windows.Media.TextFormatting;

namespace Prak_7_.ViewModel
{
    internal class MainViewModel : BindingHelper
    {
        public string rezult;
        public string Rezult
        {
            get { return rezult; }
            set
            {
                if (rezult == "0")
                {
                    rezult = value;
                    OnPropertyChanged();
                    return;
                }
                if (rezult == null || rezult == "" || value == "")
                {
                    rezult = "0";
                    OnPropertyChanged();
                    return;
                }
                rezult += value;
                OnPropertyChanged();
            }
        }
        public BindableCommand Sqr { get; set; }
        public BindableCommand Minus { get; set; }
        public BindableCommand Plus { get; set; }
        public BindableCommand Umnoj { get; set; }
        public BindableCommand Delit { get; set; }
        public BindableCommand Back { get; set; }
        public BindableCommand One { get; set; }
        public BindableCommand Two { get; set; }
        public BindableCommand Three { get; set; }
        public BindableCommand Four { get; set; }
        public BindableCommand Five { get; set; }
        public BindableCommand Six { get; set; }
        public BindableCommand Seven { get; set; }
        public BindableCommand Eight { get; set; }
        public BindableCommand Nine { get; set; }
        public BindableCommand Zero { get; set; }
        public BindableCommand Plus_minus { get; set; }
        public BindableCommand Ravno { get; set; }
        public BindableCommand One_del { get; set; }
        public BindableCommand Clear { get; set; }
        public MainViewModel()
        {
            Sqr = new BindableCommand(_ => sqr());
            Minus = new BindableCommand(_ => minus());
            Umnoj = new BindableCommand(_ => umnoj());
            Plus = new BindableCommand(_ => plus());
            Delit = new BindableCommand(_ => delit());
            One = new BindableCommand(_ => one());
            Two = new BindableCommand(_ => two());
            Three = new BindableCommand(_ => three());
            Four = new BindableCommand(_ => four());
            Five = new BindableCommand(_ => five());
            Six = new BindableCommand(_ => six());
            Seven = new BindableCommand(_ => seven());
            Eight = new BindableCommand(_ => eight());
            Nine = new BindableCommand(_ => nine());
            Zero = new BindableCommand(_ => zero());
            Plus_minus = new BindableCommand(_ => plus_minus());
            Ravno = new BindableCommand(_ => ravno());
            One_del = new BindableCommand(_ => one_del());
            Clear = new BindableCommand(_ => clear());
            Back = new BindableCommand(_ => back());
            Rezult = "0";
        }

        private void back()
        {
            string tmp = rezult;
            Rezult = "";
            if (tmp.Length == 1)
                Rezult = "0";
            else
                Rezult = tmp[..^1];
        }

        private void clear() => Rezult = "";
        private void one_del()
        {
            string tmp = rezult;
            Rezult = "";
            Rezult = "1/" + tmp;

        }
        private void ravno()
        {
            string tmp = rezult;
            Rezult = "";
            try
            {
                if (!tmp.Contains("^"))
                {
                    Rezult = new DataTable().Compute(tmp, null).ToString();
                }
                else
                {
                    bool minus = false;
                    bool minus_ = false;
                    int a = 0;
                    int b = 0;
                    int c = 0;
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (tmp[i] == '^')
                        {
                            c = i + 1;
                            break;
                        }
                        if (tmp[i] == '-')
                            minus = true;
                        else
                        {
                            a *= 10;
                            a += int.Parse(tmp[i].ToString());
                        }
                    }
                    for (int i = c; i < tmp.Length; i++)
                    {
                        b *= 10;
                        if (tmp[i] == '-')
                            minus_ = true;
                        else
                        {
                            b += int.Parse(tmp[i].ToString());
                        }
                    }
                    if (minus)
                    {
                        if (minus_)
                            Rezult = Math.Pow(Convert.ToDouble(-a), Convert.ToDouble(-b)).ToString();
                        else
                            Rezult = Math.Pow(Convert.ToDouble(-a), Convert.ToDouble(b)).ToString();
                    }
                    else if (!minus)
                    {
                        if (minus_)
                            Rezult = Math.Pow(Convert.ToDouble(a), Convert.ToDouble(-b)).ToString();
                        else
                            Rezult = Math.Pow(Convert.ToDouble(a), Convert.ToDouble(b)).ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка ввода!");
                Rezult = "0";
            }
        }
        private void plus_minus()
        {
            string tmp = rezult;
            Rezult = "";
            if (tmp == "0")
                return;
            if (tmp[0] != '-')
                Rezult = tmp.Insert(0, "-");
            else Rezult = tmp.Substring(1, tmp.Length - 1);
        }
        private void zero() => Rezult = "0";
        private void nine() => Rezult = "9";

        private void eight() => Rezult = "8";
        private void seven() => Rezult = "7";
        private void six() => Rezult = "6";
        private void five() => Rezult = "5";
        private void four() => Rezult = "4";
        private void three() => Rezult = "3";
        private void two() => Rezult = "2";
        private void one() => Rezult = "1";
        private void delit() => Rezult = "/";
        private void plus() => Rezult = "+";
        private void umnoj() => Rezult = "*";
        private void minus() => Rezult = "-";
        private void sqr() => Rezult = "^2";
    }
}