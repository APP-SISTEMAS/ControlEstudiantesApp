﻿namespace AplicacionWinform.Estudiantes
{
    partial class frmEstudiantes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtNombre = new TextBox();
            button1 = new Button();
            txtId = new TextBox();
            label2 = new Label();
            txtIdentidad = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtFechaNacimiento = new DateTimePicker();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 85);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(137, 82);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(303, 23);
            txtNombre.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(137, 223);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(137, 44);
            txtId.Name = "txtId";
            txtId.Size = new Size(73, 23);
            txtId.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 47);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 3;
            label2.Text = "Id";
            // 
            // txtIdentidad
            // 
            txtIdentidad.Location = new Point(137, 121);
            txtIdentidad.Name = "txtIdentidad";
            txtIdentidad.Size = new Size(170, 23);
            txtIdentidad.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 124);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 5;
            label3.Text = "Identidad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 166);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 7;
            label4.Text = "Fecha Nac";
            // 
            // txtFechaNacimiento
            // 
            txtFechaNacimiento.Format = DateTimePickerFormat.Short;
            txtFechaNacimiento.Location = new Point(137, 166);
            txtFechaNacimiento.Name = "txtFechaNacimiento";
            txtFechaNacimiento.Size = new Size(170, 23);
            txtFechaNacimiento.TabIndex = 8;
            // 
            // button2
            // 
            button2.Location = new Point(218, 223);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(314, 223);
            button3.Name = "button3";
            button3.Size = new Size(96, 23);
            button3.TabIndex = 10;
            button3.Text = "Deshabilitar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(216, 44);
            button4.Name = "button4";
            button4.Size = new Size(53, 23);
            button4.TabIndex = 11;
            button4.Text = "buscar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // frmEstudiantes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 361);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(txtFechaNacimiento);
            Controls.Add(label4);
            Controls.Add(txtIdentidad);
            Controls.Add(label3);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "frmEstudiantes";
            Text = "frmEstudiantes";
            Load += frmEstudiantes_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Button button1;
        private TextBox txtId;
        private Label label2;
        private TextBox txtIdentidad;
        private Label label3;
        private Label label4;
        private DateTimePicker txtFechaNacimiento;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}