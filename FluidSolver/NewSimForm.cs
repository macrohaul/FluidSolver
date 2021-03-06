﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FluidSolver
{
    public partial class NewSimForm : Form
    {
        public SolverParams Params;

        public NewSimForm(SolverParams Params)
        {
            InitializeComponent();
            this.Params = (Params != null) ? Params : new SolverParams();
            SetupFormFromParams();
        }

        private void SetupFormFromParams ()
        {
            WidthCtrl.Value = Params.Width;
            HeightCtrl.Value = Params.Height;
            DepthCtrl.Value = Params.Depth;
            ForceCtrl.Value = (decimal)Params.Force;
            SourceCtrl.Value = (decimal)Params.Source;
            VorticityCtrl.Checked = Params.Vorticity;
            dtCtrl.Value = (decimal)Params.Dt;
            TempCtrl.Value = (decimal)Params.Tamb;
            SimTempCtrl.Checked = Params.Temperature;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dtAutoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dtCtrl.Enabled = !dtAutoCheckBox.Checked;
        }

        private void SimTempCtrl_CheckedChanged(object sender, EventArgs e)
        {
            TempCtrl.Enabled = !SimTempCtrl.Checked;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Params.Width = (int)WidthCtrl.Value;
            Params.Height = (int)HeightCtrl.Value;
            Params.Depth = (int)DepthCtrl.Value;
            Params.Force = (float)ForceCtrl.Value;
            Params.Source = (float)SourceCtrl.Value;
            Params.Vorticity = VorticityCtrl.Checked;
            Params.Dt = (dtAutoCheckBox.Enabled) ? (60 / 1000f) : (float)dtCtrl.Value;
            Params.Tamb = (float)TempCtrl.Value;
            Params.Temperature = SimTempCtrl.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
