using System.Diagnostics;

namespace AnalizadorLexico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Guardar el contenido del TextBox en un archivo temporal
            string inputFile = Path.GetTempFileName();
            File.WriteAllText(inputFile, inputTextBox.Text);

            // Ejecutar el analizador léxico
            ProcessStartInfo psi = new ProcessStartInfo(@"C:\Users\Laem0\Desktop\Cursos\utesa\C#\AnalizadorLexico\AnalizadorLexico\lexer\lexer.exe", inputFile)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process? process = Process.Start(psi);
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // Mostrar los resultados en el TextBox de salida
            outputTextBox.Text = output;

            // Limpiar el archivo temporal
            File.Delete(inputFile);
        }
    }
}
