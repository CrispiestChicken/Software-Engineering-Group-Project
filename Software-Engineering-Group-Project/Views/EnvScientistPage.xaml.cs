﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class EnvScientistPage : ContentPage
{
    public EnvScientistPage()
    {
        this.BindingContext = new EnvScientistViewModel();
        InitializeComponent();
    }
}