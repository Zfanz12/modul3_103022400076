using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul3_103022400076
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            // ==================== VALIDASI COMBOBOX SATUAN AWAL ====================
            if (cmbSatuan.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih satuan awal terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSatuan.Focus();
                return;
            }

            // ==================== VALIDASI COMBOBOX SATUAN AKHIR ====================
            if (cmbAkhir.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih satuan akhir terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAkhir.Focus();
                return;
            }

            // ==================== VALIDASI TEXTBOX ====================
            if (!double.TryParse(txtNilaiAwal.Text, out double nilai))
            {
                MessageBox.Show("Masukkan angka yang valid!", "Error Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNilaiAwal.Focus();
                txtNilaiAwal.SelectAll();
                return;
            }

            // ==================== KONVERSI SUHU ====================
            try
            {
                string satuanAwal = cmbSatuan.SelectedItem.ToString();
                string satuanAkhir = cmbAkhir.SelectedItem.ToString();
                double hasil = 0;

                // STEP 1: Konversi satuan awal ke Celsius
                double celsius = 0;

                if (satuanAwal == "Celsius")
                {
                    celsius = nilai;
                }
                else if (satuanAwal == "Fahrenheit")
                {
                    celsius = (nilai - 32) * 5 / 9;
                }
                else if (satuanAwal == "Kelvin")
                {
                    celsius = nilai - 273.15;
                }
                else if (satuanAwal == "Reamur")
                {
                    celsius = nilai * 5 / 4;
                }

                // STEP 2: Konversi dari Celsius ke satuan akhir
                if (satuanAkhir == "Celsius")
                {
                    hasil = celsius;
                }
                else if (satuanAkhir == "Fahrenheit")
                {
                    // Rumus: F = (C × 9/5) + 32
                    hasil = (celsius * 9 / 5) + 32;
                }
                else if (satuanAkhir == "Kelvin")
                {
                    // Rumus: K = C + 273.15
                    hasil = celsius + 273.15;
                }
                else if (satuanAkhir == "Reamur")
                {
                    // Rumus: R = C × 4/5
                    hasil = celsius * 4 / 5;
                }

                // STEP 3: Tampilkan hasil di TextBox "Nilai Akhir"
                txtNilaiAkhir.Text = hasil.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
