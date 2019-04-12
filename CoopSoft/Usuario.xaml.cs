﻿using CoopSoft.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoopSoft
{
    /// <summary>
    /// Interaction logic for Usuario.xaml
    /// </summary>
    public partial class Usuario : UserControl
    {
        public Usuario()
        {
            InitializeComponent();
            dataGrid1.ItemsSource = DataHelper.LoadData("Usuario");
        }
    }
}
